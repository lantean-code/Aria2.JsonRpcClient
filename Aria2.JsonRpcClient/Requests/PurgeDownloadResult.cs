namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to purge the download result of a completed/error/removed download.
    /// </summary>
    public sealed record PurgeDownloadResult : JsonRpcRequest
    {
        /// <inheritdoc cref="IAria2Client.PurgeDownloadResult"/>/>
        public PurgeDownloadResult() : base("aria2.purgeDownloadResult", JsonRpcParameters.Empty)
        {
        }
    }
}
