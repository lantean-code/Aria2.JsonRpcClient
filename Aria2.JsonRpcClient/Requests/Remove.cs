namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to remove a download.
    /// </summary>
    public sealed record Remove : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.Remove(string)"/>
        public Remove(string gid) : base("aria2.remove", gid)
        {
        }
    }
}
