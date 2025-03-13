using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to add a download from a list of URIs.
    /// </summary>
    public sealed record AddUri : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.AddUri(string[], Aria2DownloadOptions?, int?)"/>
        public AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null) : base("aria2.addUri", [uris, options, position])
        {
        }
    }
}
