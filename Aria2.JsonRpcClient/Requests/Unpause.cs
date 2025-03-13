namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to unpause a download.
    /// </summary>
    public sealed record Unpause : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.Unpause(string)"/>
        public Unpause(string gid) : base("aria2.unpause", gid)
        {
        }
    }
}
