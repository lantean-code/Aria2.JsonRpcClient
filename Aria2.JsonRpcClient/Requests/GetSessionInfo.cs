using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the session information of the aria2 client.
    /// </summary>
    public sealed record GetSessionInfo : JsonRpcRequest<Aria2SessionInfo>
    {
        /// <inheritdoc cref="IAria2Client.GetSessionInfo"/>
        public GetSessionInfo(string? id = null) : base("aria2.getSessionInfo", JsonRpcParameters.Empty, id)
        {
        }
    }
}
