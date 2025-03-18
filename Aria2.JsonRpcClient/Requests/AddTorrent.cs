using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to add a torrent download.
    /// </summary>
    public sealed record AddTorrent : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.AddTorrent"/>
        public AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null) : base("aria2.addTorrent", [torrent, options, position], id)
        {
        }
    }
}
