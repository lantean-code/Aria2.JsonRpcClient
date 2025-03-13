using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the status of a download.
    /// </summary>
    public sealed record TellStatus : JsonRpcRequest<Aria2Status>
    {
        /// <inheritdoc cref="IAria2Client.TellStatus(string, string[])"/>
        public TellStatus(string gid, string[]? keys = null) : base("aria2.tellStatus", [gid, keys])
        {
        }
    }
}
