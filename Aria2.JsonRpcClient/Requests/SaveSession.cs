namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to save the current session of the aria2 client.
    /// </summary>
    public sealed record SaveSession : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.SaveSession"/>/>
        public SaveSession() : base("aria2.saveSession", JsonRpcParameters.Empty)
        {
        }
    }
}
