namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to force pause all downloads.
    /// </summary>
    public sealed record ForcePauseAll : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.ForcePauseAll"/>
        public ForcePauseAll(string? id = null) : base("aria2.forcePauseAll", JsonRpcParameters.Empty, id)
        {
        }
    }
}
