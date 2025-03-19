using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the list of stopped downloads.
    /// </summary>
    public sealed record TellStopped : JsonRpcRequest<IReadOnlyList<Aria2Status>>
    {
        /// <inheritdoc cref="IAria2Client.TellStopped"/>
        public TellStopped(int offset, int num, string[]? keys = null, string? id = null) : base("aria2.tellStopped", [offset, num, keys], id)
        {
        }
    }
}
