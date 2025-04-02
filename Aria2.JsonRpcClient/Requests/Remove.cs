namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to remove a download.
    /// </summary>
    public sealed record Remove : JsonRpcRequest<string>
    {
        /// <inheritdoc cref="IAria2Client.Remove"/>
        public Remove(string gid, string? id = null) : base("aria2.remove", gid, id)
        {
        }
    }
}
