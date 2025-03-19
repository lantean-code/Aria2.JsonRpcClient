using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient
{
    /// <inheritdoc cref="IAria2Client"/>
    internal class Aria2Client : IAria2Client
    {
        private readonly IRequestHandler _requestHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Aria2Client"/> class.
        /// </summary>
        /// <param name="requestHandler">An instance of a request handler for JSON‑RPC communication.</param>
        /// <param name="notificationHandler">An instance of a notification handler.</param>
        public Aria2Client(IRequestHandler requestHandler, INotificationHandler notificationHandler)
        {
            _requestHandler = requestHandler;

            notificationHandler.OnDownloadStarted += gid => DownloadStarted?.Invoke(gid);
            notificationHandler.OnDownloadPaused += gid => DownloadPaused?.Invoke(gid);
            notificationHandler.OnDownloadStopped += gid => DownloadStopped?.Invoke(gid);
            notificationHandler.OnDownloadComplete += gid => DownloadComplete?.Invoke(gid);
            notificationHandler.OnDownloadError += gid => DownloadError?.Invoke(gid);
            notificationHandler.OnBtDownloadComplete += gid => BtDownloadComplete?.Invoke(gid);
        }

        #region Download Adding Methods

        /// <inheritdoc/>
        public Task<string> AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null, string? id = null)
        {
            var request = new AddUri(uris, options, position, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task<string> AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null)
        {
            var request = new AddTorrent(torrent, options, position, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task<string> AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null, string? id = null)
        {
            var request = new AddMetalink(metalink, options, position, id);
            return ExecuteRequest<string>(request);
        }

        #endregion Download Adding Methods

        #region Download Removal & Pause Methods

        /// <inheritdoc/>
        public Task<string> Remove(string gid, string? id = null)
        {
            var request = new Remove(gid, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task<string> ForceRemove(string gid, string? id = null)
        {
            var request = new ForceRemove(gid, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task<string> Pause(string gid, string? id = null)
        {
            var request = new Pause(gid, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task PauseAll(string? id = null)
        {
            var request = new PauseAll(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task<string> ForcePause(string gid, string? id = null)
        {
            var request = new ForcePause(gid, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task ForcePauseAll(string? id = null)
        {
            var request = new ForcePauseAll(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task<string> Unpause(string gid, string? id = null)
        {
            var request = new Unpause(gid, id);
            return ExecuteRequest<string>(request);
        }

        /// <inheritdoc/>
        public Task UnpauseAll(string? id = null)
        {
            var request = new UnpauseAll(id);
            return ExecuteRequest(request);
        }

        #endregion Download Removal & Pause Methods

        #region Download Status & Information Methods

        /// <inheritdoc/>
        public Task<Aria2Status> TellStatus(string gid, string[]? keys = null, string? id = null)
        {
            var request = new TellStatus(gid, keys, id);
            return ExecuteRequest<Aria2Status>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Uri>> GetUris(string gid, string? id = null)
        {
            var request = new GetUris(gid, id);
            return ExecuteRequest<IReadOnlyList<Aria2Uri>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2File>> GetFiles(string gid, string? id = null)
        {
            var request = new GetFiles(gid, id);
            return ExecuteRequest<IReadOnlyList<Aria2File>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Peer>> GetPeers(string gid, string? id = null)
        {
            var request = new GetPeers(gid, id);
            return ExecuteRequest<IReadOnlyList<Aria2Peer>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Server>> GetServers(string gid, string? id = null)
        {
            var request = new GetServers(gid, id);
            return ExecuteRequest<IReadOnlyList<Aria2Server>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Status>> TellActive(string[]? keys = null, string? id = null)
        {
            var request = new TellActive(keys, id);
            return ExecuteRequest<IReadOnlyList<Aria2Status>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Status>> TellWaiting(int offset, int num, string[]? keys = null, string? id = null)
        {
            var request = new TellWaiting(offset, num, keys, id);
            return ExecuteRequest<IReadOnlyList<Aria2Status>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Aria2Status>> TellStopped(int offset, int num, string[]? keys = null, string? id = null)
        {
            var request = new TellStopped(offset, num, keys, id);
            return ExecuteRequest<IReadOnlyList<Aria2Status>>(request);
        }

        #endregion Download Status & Information Methods

        #region Download Modification Methods

        /// <inheritdoc/>
        public Task<int> ChangePosition(string gid, int pos, string how, string? id = null)
        {
            var request = new ChangePosition(gid, pos, how, id);
            return ExecuteRequest<int>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<int>> ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null, string? id = null)
        {
            var request = new ChangeUri(gid, fileIndex, delUris, addUris, position, id);
            return ExecuteRequest<IReadOnlyList<int>>(request);
        }

        #endregion Download Modification Methods

        #region Option Methods

        /// <inheritdoc/>
        public Task<Aria2Options> GetOption(string gid, string? id = null)
        {
            var request = new GetOption(gid, id);
            return ExecuteRequest<Aria2Options>(request);
        }

        /// <inheritdoc/>
        public Task ChangeOption(string gid, Aria2DownloadOptions options, string? id = null)
        {
            var request = new ChangeOption(gid, options, id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyDictionary<string, string?>> GetGlobalOption(string? id = null)
        {
            var request = new GetGlobalOption(id);
            return ExecuteRequest<IReadOnlyDictionary<string, string?>>(request);
        }

        /// <inheritdoc/>
        public Task ChangeGlobalOption(Aria2DownloadOptions options, string? id = null)
        {
            var request = new ChangeGlobalOption(options, id);
            return ExecuteRequest(request);
        }

        #endregion Option Methods

        #region Global Status & Miscellaneous Methods

        /// <inheritdoc/>
        public Task<Aria2GlobalStat> GetGlobalStat(string? id = null)
        {
            var request = new GetGlobalStat(id);
            return ExecuteRequest<Aria2GlobalStat>(request);
        }

        /// <inheritdoc/>
        public Task<Aria2Version> GetVersion(string? id = null)
        {
            var request = new GetVersion(id);
            return ExecuteRequest<Aria2Version>(request);
        }

        /// <inheritdoc/>
        public Task<Aria2SessionInfo> GetSessionInfo(string? id = null)
        {
            var request = new GetSessionInfo(id);
            return ExecuteRequest<Aria2SessionInfo>(request);
        }

        /// <inheritdoc/>
        public Task Shutdown(string? id = null)
        {
            var request = new Shutdown(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task ForceShutdown(string? id = null)
        {
            var request = new ForceShutdown(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task SaveSession(string? id = null)
        {
            var request = new SaveSession(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task PurgeDownloadResult(string? id = null)
        {
            var request = new PurgeDownloadResult(id);
            return ExecuteRequest(request);
        }

        /// <inheritdoc/>
        public Task RemoveDownloadResult(string gid, string? id = null)
        {
            var request = new RemoveDownloadResult(gid, id);
            return ExecuteRequest(request);
        }

        #endregion Global Status & Miscellaneous Methods

        #region System Methods

        /// <inheritdoc/>
        public Task<IReadOnlyList<object?>> SystemMulticall(params JsonRpcRequest[] methods)
        {
            return SystemMulticall(methods, null);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<object?>> SystemMulticall(JsonRpcRequest[] methods, string? id = null)
        {
            var request = new MultiCall(methods);
            var results = await ExecuteRequest<IReadOnlyList<JsonElement[]>>(request);

            var responses = new List<object?>();
            for (var i = 0; i < methods.Length; i++)
            {
                var method = methods[i];
                var response = results[i];
                object? value;
                if (response.Length == 0 || method.ReturnType == typeof(void))
                {
                    value = null;
                }
                else
                {
#if NET8_0_OR_GREATER
                    var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(method.ReturnType);
                    if (typeInfo is null)
                    {
                        throw new InvalidOperationException($"The JsonTypeInfo for '{method.ReturnType}' is has not been registered.");
                    }
                    value = response[0].Deserialize(typeInfo);
#else
                    value = response[0].Deserialize(method.ReturnType, Aria2ClientSerialization.Options);
#endif
                }
                responses.Add(value);
            }

            return responses.AsReadOnly();
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<string>> SystemListMethods(string? id = null)
        {
            var request = new ListMethods(id);
            return ExecuteRequest<IReadOnlyList<string>>(request);
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<string>> SystemListNotifications(string? id = null)
        {
            var request = new ListNotifications(id);
            return ExecuteRequest<IReadOnlyList<string>>(request);
        }

#endregion System Methods

        #region Execute Request Methods

        public async Task<T> ExecuteRequest<T>(JsonRpcRequest request)
        {
            if (typeof(T) != request.ReturnType)
            {
                throw new ArgumentException("The return type of the request does not match the specified type.", nameof(request));
            }
            var response = await _requestHandler.SendRequest<T>(request);
            return EnsureSuccessResponse(response);
        }

        public async Task ExecuteRequest(JsonRpcRequest request)
        {
            if (request.ReturnType != typeof(void))
            {
                throw new ArgumentException("The return type of the request is not void.", nameof(request));
            }
            var response = await _requestHandler.SendRequest(request);
            EnsureSuccessResponse(response);
        }

        #endregion Execute Request Methods

        #region Notification Events

        /// <inheritdoc/>
        public event Action<string>? DownloadStarted;

        /// <inheritdoc/>
        public event Action<string>? DownloadPaused;

        /// <inheritdoc/>
        public event Action<string>? DownloadStopped;

        /// <inheritdoc/>
        public event Action<string>? DownloadComplete;

        /// <inheritdoc/>
        public event Action<string>? DownloadError;

        /// <inheritdoc/>
        public event Action<string>? BtDownloadComplete;

        #endregion Notification Events

        #region Private Helper Methods

        private static void EnsureSuccessResponse(JsonRpcResponse response)
        {
            if (response.Error is not null)
            {
                throw new Aria2Exception(response.Error.Code, response.Error.Message);
            }
        }

        private static T EnsureSuccessResponse<T>(JsonRpcResponse<T> response)
        {
            if (response.Error is not null)
            {
                throw new Aria2Exception(response.Error.Code, response.Error.Message);
            }

            if (response.Result is null)
            {
                throw new InvalidOperationException("Invalid JSON-RPC response.");
            }

            return response.Result;
        }

        #endregion Private Helper Methods
    }
}
