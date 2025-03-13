using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the peers of a download.
    /// </summary>
    public sealed record GetPeers : JsonRpcRequest<IReadOnlyList<Aria2Peer>>
    {
        /// <inheritdoc cref="IAria2Client.GetPeers(string)"/>
        public GetPeers(string gid) : base("aria2.getPeers", gid)
        {
        }
    }
}
