using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Aria2.JsonRpcClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IRequestHandler"/> that sends JSON‑RPC requests to aria2 using WebSockets.
    /// This implementation maintains a persistent WebSocket connection and matches responses to requests by the "id" field.
    /// </summary>
    internal class WebSocketConnectionManager : IRequestHandler, INotificationHandler, IDisposable
    {
        private readonly IClientWebSocketManager _webSocketClientManager;

        private readonly string _secret;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<JsonElement>> _pendingRequests = new();
        private bool _disposedValue;


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
        /// <param name="clientWebSocketManager"></param>
        /// <param name="clientOptions"></param>
        public WebSocketConnectionManager(IClientWebSocketManager clientWebSocketManager, IOptions<Aria2ClientOptions> clientOptions)
        {
            _webSocketClientManager = clientWebSocketManager;
            _webSocketClientManager.OnMessageReceived += OnMessageReceived;
            _secret = clientOptions.Value.Secret;
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse<TResponse>> SendRequest<TResponse>(JsonRpcRequest jsonRpcRequest)
        {
            var rawResponse = await SendWebSocketRequestAsync(jsonRpcRequest);

            return Serializer.Deserialize<JsonRpcResponse<TResponse>>(rawResponse);
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse> SendRequest(JsonRpcRequest jsonRpcRequest)
        {
            var rawResponse = await SendWebSocketRequestAsync(jsonRpcRequest);

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
            var tcs = new TaskCompletionSource<JsonElement>(TaskCreationOptions.RunContinuationsAsynchronously);
            if (!_pendingRequests.TryAdd(request.Id, tcs))
            {
                throw new InvalidOperationException("A request with the same ID is already pending.");
            }

            request.EnsureSecret(_secret);

            await _webSocketClientManager.SendWebSocketRequestAsync(request);

            return await tcs.Task;
        }

        private bool _exceptionBefore;
        private bool _exceptionAfter;

        /// <summary>
        /// This is for unit testing only.
        /// </summary>
        /// <param name="before"></param>
        /// <param name="after"></param>
        internal void SetFailure(bool before, bool after)
        {
            _exceptionBefore = before;
            _exceptionAfter = after;
        }

        private void OnMessageReceived(JsonElement root)
        {
            string? id = null;
            TaskCompletionSource<JsonElement>? tcs = null;

            try
            {
                if (root.TryGetProperty("id", out var idElement))
                {
                    id = idElement.GetString();
                    if (_exceptionBefore)
                    {
                        throw new InvalidOperationException("THIS SHOULD FAIL");
                    }
                    if (id is not null && _pendingRequests.TryRemove(id, out tcs))
                    {
                        if (_exceptionAfter)
                        {
                            throw new InvalidOperationException("THIS SHOULD FAIL");
                        }
                        tcs.SetResult(root);
                    }
                }
                else
                {
                    HandleNotification(root);
                }
            }
            catch (Exception ex)
            {
                if (tcs is not null)
                {
                    tcs.SetException(ex);
                }
                else
                {
                    if (id is not null && _pendingRequests.TryRemove(id, out tcs))
                    {
                        tcs.SetException(ex);
                    }
                }
            }
        }

        private void HandleNotification(JsonElement root)
        {
            var response = Serializer.Deserialize<JsonRpcNotification>(root);
            if (response.Parameters.Count == 0)
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
                    foreach (var item in _pendingRequests.Values)
                    {
                        item.SetCanceled();
                    }
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
