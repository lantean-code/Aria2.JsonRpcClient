using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the list of waiting downloads.
    /// </summary>
    public sealed record TellWaiting : JsonRpcRequest<IReadOnlyList<Aria2Status>>
    {
        /// <inheritdoc cref="IAria2Client.TellWaiting"/>
        public TellWaiting(int offset, int num, string[]? keys = null, string? id = null) : base("aria2.tellWaiting", [offset, num, keys], id)
        {
        }
    }
}
