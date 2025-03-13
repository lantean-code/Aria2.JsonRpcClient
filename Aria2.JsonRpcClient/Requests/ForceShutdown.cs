namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force shutdown the aria2 server.
    /// </summary>
    public sealed record ForceShutdown : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.ForceShutdown"/>/>
        public ForceShutdown() : base("aria2.forceShutdown", JsonRpcParameters.Empty)
        {
        }
    }
}
