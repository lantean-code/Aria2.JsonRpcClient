using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents information retrieved from the .torrent (file).
    /// </summary>
    public record Aria2Bittorrent
    {
        /// <summary>
        /// List of lists of announce URIs. If the torrent contains announce and no announce-list, announce is converted to the announce-list format.
        /// </summary>
        [JsonPropertyName("announceList")]
        public IReadOnlyList<string[]>? AnnounceList { get; init; }

        /// <summary>
        /// The comment of the torrent. comment.utf-8 is used if available.
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; init; }

        /// <summary>
        /// The creation date of the torrent. The value is an integer since the epoch, measured in seconds.
        /// </summary>
        [JsonPropertyName("creationDate")]
        public long? CreationDate { get; init; }

        /// <summary>
        /// File mode of the torrent.
        /// </summary>
        [JsonPropertyName("mode")]
        public TorrentModeOptions Mode { get; init; }

        /// <summary>
        /// Contains data from Info dictionary.
        /// </summary>
        [JsonPropertyName("info")]
        public Aria2TorrentInfo? Info { get; init; }
    }
}
