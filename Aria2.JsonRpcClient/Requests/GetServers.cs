using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the servers of a download.
    /// </summary>
    public sealed record GetServers : JsonRpcRequest<IReadOnlyList<Aria2Server>>
    {
        /// <inheritdoc cref="IAria2Client.GetServers(string)"/>
        public GetServers(string gid) : base("aria2.getServers", gid)
        {
        }
    }
}
