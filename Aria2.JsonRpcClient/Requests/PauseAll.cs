namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to pause all downloads.
    /// </summary>
    public sealed record PauseAll : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.PauseAll"/>
        public PauseAll(string? id = null) : base("aria2.pauseAll", JsonRpcParameters.Empty, id)
        {
        }
    }
}
