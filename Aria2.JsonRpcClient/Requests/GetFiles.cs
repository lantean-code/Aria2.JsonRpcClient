using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the files of a download.
    /// </summary>
    public sealed record GetFiles : JsonRpcRequest<IReadOnlyList<Aria2File>>
    {
        /// <inheritdoc cref="IAria2Client.GetFiles"/>
        public GetFiles(string gid, string? id = null) : base("aria2.getFiles", gid, id)
        {
        }
    }
}
