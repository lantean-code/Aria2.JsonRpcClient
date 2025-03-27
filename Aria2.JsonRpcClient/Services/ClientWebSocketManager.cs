using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Registry;

namespace Aria2.JsonRpcClient.Services
{
    internal class ClientWebSocketManager : IDisposable, IClientWebSocketManager
    {
        private readonly IClientWebSocket _webSocket;
        private CancellationTokenSource _cts = new();

        private readonly Uri _uri;
        private readonly SemaphoreSlim _connectionLock = new(1, 1);
        private Task? _receiveTask;
        private bool _disposedValue;

        private readonly IAsyncPolicy _retryPolicy;

        public event Action<JsonElement>? OnMessageReceived;

        /// <summary>a
        /// Initializes a new instance of the <see cref="ClientWebSocketManager"/> class.
        /// </summary>
        /// <param name="clientWebSocket"></param>
        /// <param name="clientOptions"></param>
        /// /// <param name="policyRegistry"></param>
        public ClientWebSocketManager(IClientWebSocket clientWebSocket, IOptions<Aria2ClientOptions> clientOptions, IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _webSocket = clientWebSocket;
            clientOptions.Value.WebSocketOptions?.Invoke(_webSocket.Options);
            _uri = new Uri($"ws://{clientOptions.Value.Host}:{clientOptions.Value.Port}/jsonrpc");

            _retryPolicy = policyRegistry.Get<IAsyncPolicy>("WebSocketPolicy");
        }

        /// <summary>
        /// Sends the JSON‑RPC request over the WebSocket and returns the parsed JSON response as a JsonElement.
        /// Ensures the connection is open before sending.
        /// </summary>
        /// <param name="request">The JSON‑RPC request to be sent.</param>
        /// <returns>The parsed JSON response as a JsonElement.</returns>
        public async Task SendWebSocketRequestAsync<T>(T request)
        {
            await EnsureConnectedAsync();

            var jsonRequest = Serializer.Serialize(request);
            var requestBytes = Encoding.UTF8.GetBytes(jsonRequest);

            await _webSocket.SendAsync(
                new ArraySegment<byte>(requestBytes),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
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
#if NET8_0_OR_GREATER
                        await _cts.CancelAsync();
#else
                        _cts.Cancel();
#endif
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

                    OnMessageReceived?.Invoke(root);
                }
                catch
                {
                }
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
