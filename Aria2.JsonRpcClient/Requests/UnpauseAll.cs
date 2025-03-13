namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to unpause all downloads.
    /// </summary>
    public sealed record UnpauseAll : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.UnpauseAll"/>
        public UnpauseAll() : base("aria2.unpauseAll", JsonRpcParameters.Empty)
        {
        }
    }
}
