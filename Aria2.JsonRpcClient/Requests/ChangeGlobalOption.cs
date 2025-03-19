using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to change the global options of the aria2 client.
    /// </summary>
    public sealed record ChangeGlobalOption : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.ChangeGlobalOption"/>
        public ChangeGlobalOption(Aria2DownloadOptions options, string? id = null) : base("aria2.changeGlobalOption", [options], id)
        {
        }
    }
}
