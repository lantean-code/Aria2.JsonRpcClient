namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents information about the torrent.
    /// </summary>
    public record Aria2TorrentInfo
    {
        /// <summary>
        /// name in info dictionary. name.utf-8 is used if available.
        /// </summary>
        public string? Name { get; init; }
    }
}
