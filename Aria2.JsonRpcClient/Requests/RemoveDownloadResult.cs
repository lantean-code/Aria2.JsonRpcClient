namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to remove a download result.
    /// </summary>
    public sealed record RemoveDownloadResult : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.RemoveDownloadResult(string)"/>/>
        public RemoveDownloadResult(string gid) : base("aria2.removeDownloadResult", gid)
        {
        }
    }
}
