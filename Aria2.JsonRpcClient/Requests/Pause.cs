namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to pause a download.
    /// </summary>
    public sealed record Pause : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.Pause"/>
        public Pause(string gid, string? id = null) : base("aria2.pause", gid, id)
        {
        }
    }
}
