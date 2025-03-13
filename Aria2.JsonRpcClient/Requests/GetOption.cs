using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the options of a download.
    /// </summary>
    public sealed record GetOption : JsonRpcRequest<Aria2Option>
    {
        /// <inheritdoc cref="IAria2Client.GetOption(string)"/>
        public GetOption(string gid) : base("aria2.getOption", gid)
        {
        }
    }
}
