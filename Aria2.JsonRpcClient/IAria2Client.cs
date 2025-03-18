using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Provides methods for interacting with aria2 via its JSON‑RPC interface.
    /// </summary>
    public interface IAria2Client
    {
        #region Download Adding Methods

        /// <summary>
        /// Adds a new download. <paramref name="uris"/> is an array of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource.
        /// If you mix URIs pointing to different resources, the download may fail or be corrupted.
        /// For BitTorrent Magnet URIs, <paramref name="uris"/> must have only one element.
        /// <paramref name="options"/> is a struct with option name/value pairs. If <paramref name="position"/> is given (an integer starting at 0),
        /// the new download is inserted at that position in the waiting queue; if omitted or out of range, it is appended to the end.
        /// Returns the GID of the newly registered download.
        /// </summary>
        /// <param name="uris">An array of URIs pointing to the same resource.</param>
        /// <param name="options">Download options.</param>
        /// <param name="position">The position in the waiting queue to insert the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri"/>
        /// <returns>The GID of the newly registered download.</returns>
        Task<string> AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null, string? id = null);

        /// <summary>
        /// Adds a new BitTorrent download by uploading a torrent file (base64 encoded).
        /// <paramref name="options"/> is a struct with option name/value pairs.
        /// If <paramref name="position"/> is provided, the new download is inserted at that position in the waiting queue; otherwise, appended.
        /// Returns the GID of the newly registered download.
        /// </summary>
        /// <param name="torrent">A base64 encoded torrent file.</param>
        /// <param name="options">Download options.</param>
        /// <param name="position">The position in the waiting queue to insert the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.addTorrent"/>
        /// <returns>The GID of the newly registered download.</returns>
        Task<string> AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null);

        /// <summary>
        /// Adds new downloads from a Metalink file (base64 encoded).
        /// <paramref name="options"/> is a struct with option name/value pairs.
        /// If <paramref name="position"/> is provided, the downloads are inserted at that position; otherwise, appended.
        /// Returns the GID of the newly registered download.
        /// </summary>
        /// <param name="metalink">A base64 encoded Metalink file.</param>
        /// <param name="options">Download options.</param>
        /// <param name="position">The position in the waiting queue to insert the downloads.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.addMetalink"/>
        /// <returns>The GID of the newly registered download.</returns>
        Task<string> AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null, string? id = null);

        #endregion Download Adding Methods

        #region Download Removal & Pause Methods

        /// <summary>
        /// Removes the download denoted by <paramref name="gid"/> from the download queue.
        /// If the download is in progress, it is stopped first.
        /// Returns the GID of the removed download.
        /// </summary>
        /// <param name="gid">The GID of the download to remove.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.remove"/>
        /// <returns>The GID of the removed download.</returns>
        Task<string> Remove(string gid, string? id = null);

        /// <summary>
        /// Forcefully removes the download denoted by <paramref name="gid"/> from the download queue without performing time‑consuming actions.
        /// Returns the GID of the removed download.
        /// </summary>
        /// <param name="gid">The GID of the download to forcefully remove.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceRemove"/>
        /// <returns>The GID of the removed download.</returns>
        Task<string> ForceRemove(string gid, string? id = null);

        /// <summary>
        /// Pauses the download denoted by <paramref name="gid"/>.
        /// Returns the GID of the paused download.
        /// </summary>
        /// <param name="gid">The GID of the download to pause.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.pause"/>
        /// <returns>The GID of the paused download.</returns>
        Task<string> Pause(string gid, string? id = null);

        /// <summary>
        /// Pauses all active and waiting downloads.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.pauseAll"/>
        Task PauseAll(string? id = null);

        /// <summary>
        /// Forcefully pauses the download denoted by <paramref name="gid"/> without performing extra actions.
        /// Returns the GID of the paused download.
        /// </summary>
        /// <param name="gid">The GID of the download to forcefully pause.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePause"/>
        /// <returns>The GID of the paused download.</returns>
        Task<string> ForcePause(string gid, string? id = null);

        /// <summary>
        /// Forcefully pauses all active and waiting downloads without extra actions.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePauseAll"/>
        Task ForcePauseAll(string? id = null);

        /// <summary>
        /// Unpauses the download denoted by <paramref name="gid"/>, changing its status to waiting.
        /// Returns the GID of the unpaused download.
        /// </summary>
        /// <param name="gid">The GID of the download to unpause.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpause"/>
        /// <returns>The GID of the unpaused download.</returns>
        Task<string> Unpause(string gid, string? id = null);

        /// <summary>
        /// Unpauses all paused downloads.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpauseAll"/>
        Task UnpauseAll(string? id = null);

        #endregion Download Removal & Pause Methods

        #region Download Status & Information Methods

        /// <summary>
        /// Returns the status of the download denoted by <paramref name="gid"/>.
        /// The returned object includes various properties describing the download's progress, speed, and other details.
        /// If <paramref name="keys"/> is specified, only those keys are returned.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="keys">An optional array of keys to filter the response.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus"/>
        /// <returns>An <see cref="Aria2Status"/> object describing the download's status.</returns>
        Task<Aria2Status> TellStatus(string gid, string[]? keys = null, string? id = null);

        /// <summary>
        /// Returns an array of URI objects used by the download denoted by <paramref name="gid"/>.
        /// Each URI object contains the URI and its status.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getUris"/>
        /// <returns>A read-only list of <see cref="Aria2Uri"/> objects.</returns>
        Task<IReadOnlyList<Aria2Uri>> GetUris(string gid, string? id = null);

        /// <summary>
        /// Returns an array of file objects associated with the download denoted by <paramref name="gid"/>.
        /// Each file object includes details such as file path, size, and progress.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getFiles"/>
        /// <returns>A read-only list of <see cref="Aria2File"/> objects.</returns>
        Task<IReadOnlyList<Aria2File>> GetFiles(string gid, string? id = null);

        /// <summary>
        /// Returns an array of peer objects associated with the download denoted by <paramref name="gid"/>.
        /// Each peer object contains details such as IP address, port, and speed information.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getPeers"/>
        /// <returns>A read-only list of <see cref="Aria2Peer"/> objects.</returns>
        Task<IReadOnlyList<Aria2Peer>> GetPeers(string gid, string? id = null);

        /// <summary>
        /// Returns a list of currently connected servers for the download denoted by <paramref name="gid"/>.
        /// Each server object contains the original URI, current URI, and download speed.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getServers"/>
        /// <returns>A read-only list of <see cref="Aria2Server"/> objects.</returns>
        Task<IReadOnlyList<Aria2Server>> GetServers(string gid, string? id = null);

        /// <summary>
        /// Returns a list of active downloads.
        /// Each download's status is represented as an <see cref="Aria2Status"/> object.
        /// </summary>
        /// <param name="keys">Optional keys to filter the status objects.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellActive"/>
        /// <returns>A read-only list of active downloads.</returns>
        Task<IReadOnlyList<Aria2Status>> TellActive(string[]? keys = null, string? id = null);

        /// <summary>
        /// Returns a list of waiting downloads.
        /// <paramref name="offset"/> specifies the starting index (can be negative) and <paramref name="num"/> specifies the maximum number to return.
        /// </summary>
        /// <param name="offset">The starting index in the waiting queue.</param>
        /// <param name="num">The maximum number of downloads to return.</param>
        /// <param name="keys">Optional keys to filter the status objects.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellWaiting"/>
        /// <returns>A read-only list of waiting downloads.</returns>
        Task<IReadOnlyList<Aria2Status>> TellWaiting(int offset, int num, string[]? keys = null, string? id = null);

        /// <summary>
        /// Returns a list of stopped downloads.
        /// <paramref name="offset"/> specifies the starting index (can be negative) and <paramref name="num"/> specifies the maximum number to return.
        /// </summary>
        /// <param name="offset">The starting index in the stopped queue.</param>
        /// <param name="num">The maximum number of downloads to return.</param>
        /// <param name="keys">Optional keys to filter the status objects.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped"/>
        /// <returns>A read-only list of stopped downloads.</returns>
        Task<IReadOnlyList<Aria2Status>> TellStopped(int offset, int num, string[]? keys = null, string? id = null);

        #endregion Download Status & Information Methods

        #region Download Modification Methods

        /// <summary>
        /// Changes the position of the download denoted by <paramref name="gid"/> in the queue.
        /// <paramref name="pos"/> is an integer, and <paramref name="how"/> specifies the mode: 'POS_SET', 'POS_CUR', or 'POS_END'.
        /// Returns the new position as an integer.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="pos">The position value.</param>
        /// <param name="how">The mode of repositioning.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.changePosition"/>
        /// <returns>The new position.</returns>
        Task<int> ChangePosition(string gid, int pos, string how, string? id = null);

        /// <summary>
        /// Removes URIs specified in <paramref name="delUris"/> and appends URIs in <paramref name="addUris"/> for the download (and file index) denoted by <paramref name="gid"/>.
        /// <paramref name="fileIndex"/> is 1-based. <paramref name="position"/> specifies the insertion position after deletion.
        /// Returns an array with two integers: the number of URIs deleted and the number of URIs added.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="fileIndex">The 1-based file index.</param>
        /// <param name="delUris">List of URIs to remove.</param>
        /// <param name="addUris">List of URIs to add.</param>
        /// <param name="position">Optional insertion position (0-based) after deletion.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeUri"/>
        /// <returns>An array of two integers: [number deleted, number added].</returns>
        Task<IReadOnlyList<int>> ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null, string? id = null);

        #endregion Download Modification Methods

        #region Option Methods

        /// <summary>
        /// Returns the options of the download denoted by <paramref name="gid"/> as a struct.
        /// Only options that have been set or have defaults are returned.
        /// </summary>
        /// <param name="gid">The GID of the download.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getOption"/>
        /// <returns>An <see cref="Aria2Option"/> object with the download's options.</returns>
        Task<Aria2Option> GetOption(string gid, string? id = null);

        /// <summary>
        /// Changes the options for the download denoted by <paramref name="gid"/>.
        /// <paramref name="options"/> is a struct containing option name/value pairs.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="gid">The GID of the download to modify.</param>
        /// <param name="options">The options to change.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeOption"/>
        Task ChangeOption(string gid, Aria2DownloadOptions options, string? id = null);

        /// <summary>
        /// Returns the global options as a struct.
        /// Only options that have been set or have defaults are returned.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalOption"/>
        /// <returns>A dictionary of global options.</returns>
        Task<IReadOnlyDictionary<string, string?>> GetGlobalOption(string? id = null);

        /// <summary>
        /// Changes the global options dynamically.
        /// <paramref name="options"/> is a struct containing option name/value pairs.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="options">The global options to change.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeGlobalOption"/>
        Task ChangeGlobalOption(Aria2DownloadOptions options, string? id = null);

        #endregion Option Methods

        #region Global Status & Miscellaneous Methods

        /// <summary>
        /// Returns global statistics for the aria2 session.
        /// The returned struct includes overall download/upload speeds and counts of active, waiting, and stopped downloads.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalStat"/>
        /// <returns>An <see cref="Aria2GlobalStat"/> object with global statistics.</returns>
        Task<Aria2GlobalStat> GetGlobalStat(string? id = null);

        /// <summary>
        /// Returns version information of aria2, including enabled features.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getVersion"/>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <returns>An <see cref="Aria2Version"/> object with version information.</returns>
        Task<Aria2Version> GetVersion(string? id = null);

        /// <summary>
        /// Returns session information of the current aria2 session, including the session ID.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.getSessionInfo"/>
        /// <returns>An <see cref="Aria2SessionInfo"/> object with session information.</returns>
        Task<Aria2SessionInfo> GetSessionInfo(string? id = null);

        /// <summary>
        /// Gracefully shuts down aria2, allowing active downloads to complete.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.shutdown"/>
        Task Shutdown(string? id = null);

        /// <summary>
        /// Forcefully shuts down aria2 immediately without waiting for active downloads.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceShutdown"/>
        Task ForceShutdown(string? id = null);

        /// <summary>
        /// Saves the current session to a file specified by the --save-session option.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.saveSession"/>
        Task SaveSession(string? id = null);

        /// <summary>
        /// Purges completed, error, or removed downloads from memory.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.purgeDownloadResult"/>
        Task PurgeDownloadResult(string? id = null);

        /// <summary>
        /// Removes a download result (completed/error/removed) from memory, identified by <paramref name="gid"/>.
        /// Returns "OK" upon success.
        /// </summary>
        /// <param name="gid">The GID of the download result to remove.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#aria2.removeDownloadResult"/>
        Task RemoveDownloadResult(string gid, string? id = null);

        #endregion Global Status & Miscellaneous Methods

        #region System Methods

        /// <summary>
        /// Encapsulates multiple method calls in a single request.
        /// <paramref name="methods"/> is an array of <see cref="JsonRpcRequest"/>.
        /// Returns an array of responses.
        /// </summary>
        /// <param name="methods">A list of method calls to execute.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#system.multicall"/>
        /// <returns>A list of responses for the method calls.</returns>
        Task<IReadOnlyList<object?>> SystemMulticall(params JsonRpcRequest[] methods);

        /// <summary>
        /// Encapsulates multiple method calls in a single request.
        /// <paramref name="methods"/> is an array of <see cref="JsonRpcRequest"/>.
        /// Returns an array of responses.
        /// </summary>
        /// <param name="methods">A list of method calls to execute.</param>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#system.multicall"/>
        /// <returns>A list of responses for the method calls.</returns>
        Task<IReadOnlyList<object?>> SystemMulticall(JsonRpcRequest[] methods, string? id = null);

        /// <summary>
        /// Returns an array of all available RPC method names.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#system.listMethods"/>
        /// <returns>A list of method names.</returns>
        Task<IReadOnlyList<string>> SystemListMethods(string? id = null);

        /// <summary>
        /// Returns an array of all available RPC notification names.
        /// </summary>
        /// <param name="id">The tracking id for the request. If this is omitted it will be generated automatically.</param>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#system.listNotifications"/>
        /// <returns>A list of notification names.</returns>
        Task<IReadOnlyList<string>> SystemListNotifications(string? id = null);

        #endregion System Methods

        #region Execute Request Methods

        /// <inheritdoc/>
        Task<T> ExecuteRequest<T>(JsonRpcRequest request);

        /// <inheritdoc/>
        Task ExecuteRequest(JsonRpcRequest request);

        #endregion Execute Request Methods

        #region Notification Events

        /// <summary>
        /// This notification will be sent when a download is started.
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> DownloadStarted;

        /// <summary>
        /// This notification will be sent when a download is paused. 
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> DownloadPaused;

        /// <summary>
        /// This notification will be sent when a download is stopped by the user.
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> DownloadStopped;

        /// <summary>
        /// This notification will be sent when a download is complete.For
        /// BitTorrent downloads, this notification is sent when the download is
        /// complete and seeding is over.
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> DownloadComplete;

        /// <summary>
        /// This notification will be sent when a download is stopped due to an error.
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> DownloadError;

        /// <summary>
        /// This notification will be sent when a torrent download is complete but seeding
        /// is still going on.
        /// The paramter is the GID of the download.
        /// </summary>
        event Action<string> BtDownloadComplete;

        #endregion Notification Events
    }
}
