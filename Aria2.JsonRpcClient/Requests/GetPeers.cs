using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the peers of a download.
    /// </summary>
    public sealed record GetPeers : JsonRpcRequest<IReadOnlyList<Aria2Peer>>
    {
        /// <inheritdoc cref="IAria2Client.GetPeers"/>
        public GetPeers(string gid, string? id = null) : base("aria2.getPeers", gid, id)
        {
        }
    }
}
