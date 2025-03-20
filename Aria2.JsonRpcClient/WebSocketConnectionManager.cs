using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Registry;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// An implementation of <see cref="IRequestHandler"/> that sends JSON‑RPC requests to aria2 using WebSockets.
    /// This implementation maintains a persistent WebSocket connection and matches responses to requests by the "id" field.
    /// </summary>
    internal class WebSocketConnectionManager : IRequestHandler, INotificationHandler, IDisposable
    {
        private readonly IClientWebSocket _webSocket;
        private CancellationTokenSource _cts = new();

        private readonly Uri _uri;
        private readonly string _secret;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<JsonElement>> _pendingRequests = new();
        private readonly SemaphoreSlim _connectionLock = new(1, 1);
        private Task? _receiveTask;
        private bool _disposedValue;

        private readonly IAsyncPolicy _retryPolicy;

        /// <inheritdoc />
        public event Action<string>? OnDownloadStarted;

        /// <inheritdoc />
        public event Action<string>? OnDownloadPaused;

        /// <inheritdoc />
        public event Action<string>? OnDownloadStopped;

        /// <inheritdoc />
        public event Action<string>? OnDownloadComplete;

        /// <inheritdoc />
        public event Action<string>? OnDownloadError;

        /// <inheritdoc />
        public event Action<string>? OnBtDownloadComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSocketConnectionManager"/> class.
        /// </summary>
        /// <param name="clientWebSocket"></param>
        /// <param name="clientOptions"></param>
        /// /// <param name="policyRegistry"></param>
        public WebSocketConnectionManager(IClientWebSocket clientWebSocket, IOptions<Aria2ClientOptions> clientOptions, IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _webSocket = clientWebSocket;
            clientOptions.Value.WebSocketOptions?.Invoke(_webSocket.Options);
            _uri = new Uri($"ws://{clientOptions.Value.Host}:{clientOptions.Value.Port}/jsonrpc");
            _secret = clientOptions.Value.Secret;

            _retryPolicy = policyRegistry.Get<IAsyncPolicy>("WebSocketPolicy");
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse<TResponse>> SendRequest<TResponse>(JsonRpcRequest request)
        {
            var rawResponse = await SendWebSocketRequestAsync(request);

            return Serializer.Deserialize<JsonRpcResponse<TResponse>>(rawResponse);
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse> SendRequest(JsonRpcRequest request)
        {
            var rawResponse = await SendWebSocketRequestAsync(request);

            return Serializer.Deserialize<JsonRpcResponse>(rawResponse);
        }

        /// <summary>
        /// Sends the JSON‑RPC request over the WebSocket and returns the parsed JSON response as a JsonElement.
        /// Ensures the connection is open before sending.
        /// </summary>
        /// <param name="request">The JSON‑RPC request to be sent.</param>
        /// <returns>The parsed JSON response as a JsonElement.</returns>
        private async Task<JsonElement> SendWebSocketRequestAsync(JsonRpcRequest request)
        {
            await EnsureConnectedAsync();

            var tcs = new TaskCompletionSource<JsonElement>(TaskCreationOptions.RunContinuationsAsynchronously);
            if (!_pendingRequests.TryAdd(request.Id, tcs))
            {
                throw new InvalidOperationException("A request with the same ID is already pending.");
            }

            request.EnsureSecret(_secret);

            var jsonRequest = Serializer.Serialize(request);
            var requestBytes = Encoding.UTF8.GetBytes(jsonRequest);
            await _webSocket.SendAsync(
                new ArraySegment<byte>(requestBytes),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);

            return await tcs.Task;
        }

        /// <summary>
        /// Ensures the WebSocket connection is open. If not, connects via ConnectInternalAsync.
        /// Also ensures the receive loop is started.
        /// </summary>
        private async Task EnsureConnectedAsync()
        {
            if (_webSocket.State != WebSocketState.Open)
            {
                await ConnectInternalAsync();
            }
            _receiveTask ??= Task.Run(ReceiveLoop);
        }

        /// <summary>
        /// Wraps all connection attempts in a semaphore to prevent concurrent connection operations.
        /// Checks for Aborted or Closed states and recreates the WebSocket if necessary.
        /// </summary>
        private async Task ConnectInternalAsync()
        {
            await _connectionLock.WaitAsync();
            try
            {
                await _retryPolicy.ExecuteAsync(async () =>
                {
                    // If the current _webSocket is disposed or in a terminal state,
                    // cancel and recreate the CTS and the ClientWebSocket instance.
                    if (_webSocket.State == WebSocketState.Aborted || _webSocket.State == WebSocketState.Closed)
                    {
                        _cts.Cancel();
                        _cts.Dispose();
                        _cts = new CancellationTokenSource();

                        _webSocket.Refresh();
                    }

                    await _webSocket.ConnectAsync(_uri, _cts.Token);
                });
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        /// <summary>
        /// Continuously receives messages from the WebSocket and dispatches them to the matching pending request based on the "id" field.
        /// </summary>
        private async Task ReceiveLoop()
        {
            var buffer = new byte[8192];
            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    var segment = new ArraySegment<byte>(buffer);
                    var result = await _webSocket.ReceiveAsync(segment, _cts.Token);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        break;
                    }

                    var count = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                            throw new Exception("Buffer too small for message.");
                        }
                        segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        result = await _webSocket.ReceiveAsync(segment, _cts.Token);
                        count += result.Count;
                    }

                    var memory = new ReadOnlyMemory<byte>(buffer, 0, count);
                    using var document = JsonDocument.Parse(memory);
                    // Clone the root element so it can outlive the JsonDocument.
                    var root = document.RootElement.Clone();

                    if (root.TryGetProperty("id", out var idElement))
                    {
                        var id = idElement.GetString();
                        if (id is not null && _pendingRequests.TryRemove(id, out var tcs))
                        {
                            tcs.SetResult(root);
                        }
                    }
                    else
                    {
                        HandleNotification(root);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    foreach (var kvp in _pendingRequests)
                    {
                        kvp.Value.TrySetException(ex);
                    }
                    _pendingRequests.Clear();
                    break;
                }
            }
        }

        private void HandleNotification(JsonElement root)
        {
            var response = Serializer.Deserialize<JsonRpcNotification>(root);
            if (response is null || response.Parameters.Count == 0)
            {
                return;
            }

            var gid = response.Parameters[0].Gid;

            switch (response.Method)
            {
                case "aria2.onDownloadStart":
                    OnDownloadStarted?.Invoke(gid);
                    break;
                case "aria2.onDownloadPause":
                    OnDownloadPaused?.Invoke(gid);
                    break;
                case "aria2.onDownloadStop":
                    OnDownloadStopped?.Invoke(gid);
                    break;
                case "aria2.onDownloadComplete":
                    OnDownloadComplete?.Invoke(gid);
                    break;
                case "aria2.onDownloadError":
                    OnDownloadError?.Invoke(gid);
                    break;
                case "aria2.onBtDownloadComplete":
                    OnBtDownloadComplete?.Invoke(gid);
                    break;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _webSocket.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
