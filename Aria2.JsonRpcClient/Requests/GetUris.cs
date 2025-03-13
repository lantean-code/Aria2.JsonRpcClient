using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the URIs of a download.
    /// </summary>
    public sealed record GetUris : JsonRpcRequest<IReadOnlyList<Aria2Uri>>
    {
        /// <inheritdoc cref="IAria2Client.GetUris(string)"/>
        public GetUris(string gid) : base("aria2.getUris", gid)
        {
        }
    }
}
