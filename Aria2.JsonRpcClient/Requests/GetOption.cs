using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the options of a download.
    /// </summary>
    public sealed record GetOption : JsonRpcRequest<Aria2Options>
    {
        /// <inheritdoc cref="IAria2Client.GetOption"/>
        public GetOption(string gid, string? id = null) : base("aria2.getOption", gid, id)
        {
        }
    }
}
