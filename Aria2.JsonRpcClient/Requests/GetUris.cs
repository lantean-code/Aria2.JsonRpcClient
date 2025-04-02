using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the URIs of a download.
    /// </summary>
    public sealed record GetUris : JsonRpcRequest<IReadOnlyList<Aria2Uri>>
    {
        /// <inheritdoc cref="IAria2Client.GetUris"/>
        public GetUris(string gid, string? id = null) : base("aria2.getUris", gid, id)
        {
        }
    }
}
