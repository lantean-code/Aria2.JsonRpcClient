namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force remove a download.
    /// </summary>
    public sealed record ForceRemove : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.ForceRemove(string)"/>
        public ForceRemove(string gid) : base("aria2.forceRemove", gid)
        {
        }
    }
}
