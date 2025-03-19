namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force remove a download.
    /// </summary>
    public sealed record ForceRemove : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.ForceRemove"/>
        public ForceRemove(string gid, string? id = null) : base("aria2.forceRemove", gid, id)
        {
        }
    }
}
