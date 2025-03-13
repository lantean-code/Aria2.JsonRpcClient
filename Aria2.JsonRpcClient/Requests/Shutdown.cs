namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to shutdown the aria2 client.
    /// </summary>
    public sealed record Shutdown : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.Shutdown"/>/>
        public Shutdown() : base("aria2.shutdown", JsonRpcParameters.Empty)
        {
        }
    }
}
