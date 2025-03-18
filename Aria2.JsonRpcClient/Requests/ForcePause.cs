namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force pause a download.
    /// </summary>
    public sealed record ForcePause : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.ForcePause"/>
        public ForcePause(string gid, string? id = null) : base("aria2.forcePause", gid, id)
        {
        }
    }
}
