using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to add a Metalink download.
    /// </summary>
    public sealed record AddMetalink : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.AddMetalink(string, Aria2DownloadOptions?, int?)"/>
        public AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null) : base("aria2.addMetalink", [metalink, options, position])
        {
        }
    }
}
