namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force pause a download.
    /// </summary>
    public sealed record ForcePause : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.ForcePause(string)"/>
        public ForcePause(string gid) : base("aria2.forcePause", gid)
        {
        }
    }
}
