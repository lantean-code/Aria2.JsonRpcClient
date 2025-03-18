using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the global statistics of the aria2 client.
    /// </summary>
    public sealed record GetGlobalStat : JsonRpcRequest<Aria2GlobalStat>
    {
        /// <inheritdoc cref="IAria2Client.GetGlobalStat"/>
        public GetGlobalStat(string? id = null) : base("aria2.getGlobalStat", JsonRpcParameters.Empty, id)
        {
        }
    }
}
