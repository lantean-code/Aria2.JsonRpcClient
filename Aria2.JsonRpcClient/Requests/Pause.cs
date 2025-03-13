namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to pause a download.
    /// </summary>
    public sealed record Pause : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.Pause(string)"/>
        public Pause(string gid) : base("aria2.pause", gid)
        {
        }
    }
}
