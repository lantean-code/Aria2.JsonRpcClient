using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to change the options of a download.
    /// </summary>
    public sealed record ChangeOption : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.ChangeOption(string, Aria2DownloadOptions)"/>
        public ChangeOption(string gid, Aria2DownloadOptions options) : base("aria2.changeOption", [gid, options])
        {
        }
    }
}
