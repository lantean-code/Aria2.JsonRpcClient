using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the active downloads.
    /// </summary>
    public sealed record TellActive : JsonRpcRequest<IReadOnlyList<Aria2Status>>
    {
        /// <inheritdoc cref="IAria2Client.TellActive"/>
        public TellActive(string[]? keys = null, string? id = null) : base("aria2.tellActive", [keys], id)
        {
        }
    }
}
