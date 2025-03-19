using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to change the options of a download.
    /// </summary>
    public sealed record ChangeOption : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.ChangeOption"/>
        public ChangeOption(string gid, Aria2DownloadOptions options, string? id = null) : base("aria2.changeOption", [gid, options], id)
        {
        }
    }
}
