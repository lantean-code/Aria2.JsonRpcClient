namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to change the URIs of a download.
    /// </summary>
    public sealed record ChangeUri : JsonRpcRequest<IReadOnlyList<int>>
    {
        /// <inheritdoc cref="IAria2Client.ChangeUri(string, int, IEnumerable{string}, IEnumerable{string}, int?)"/>
        public ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null) : base("aria2.changeUri", [gid, fileIndex, delUris, addUris, position])
        {
        }
    }
}
