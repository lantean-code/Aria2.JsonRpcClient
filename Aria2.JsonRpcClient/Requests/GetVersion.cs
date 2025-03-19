using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the version of the aria2 client.
    /// </summary>
    public sealed record GetVersion : JsonRpcRequest<Aria2Version>
    {
        /// <inheritdoc cref="IAria2Client.GetVersion"/>
        public GetVersion(string? id = null) : base("aria2.getVersion", JsonRpcParameters.Empty, id)
        {
        }
    }
}
