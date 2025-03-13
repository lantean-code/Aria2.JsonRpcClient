using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a peer for a BitTorrent download.
    /// </summary>
    public record Aria2Peer
    {
        /// <summary>
        /// Gets the percent-encoded peer ID.
        /// </summary>
        [JsonPropertyName("peerId")]
        public string? PeerId { get; init; }

        /// <summary>
        /// Gets the IP address of the peer.
        /// </summary>
        [JsonPropertyName("ip")]
        public required string Ip { get; init; }

        /// <summary>
        /// Gets the port number of the peer (as a string).
        /// </summary>
        [JsonPropertyName("port")]
        public required string Port { get; init; }

        /// <summary>
        /// Gets the hexadecimal representation of the peer's download progress.
        /// </summary>
        [JsonPropertyName("bitfield")]
        public string? Bitfield { get; init; }

        /// <summary>
        /// Gets whether aria2 is choking the peer.
        /// </summary>
        [JsonPropertyName("amChoking")]
        public required string AmChoking { get; init; }

        /// <summary>
        /// Gets whether the peer is choking aria2.
        /// </summary>
        [JsonPropertyName("peerChoking")]
        public required string PeerChoking { get; init; }

        /// <summary>
        /// Gets the download speed from the peer in bytes/sec.
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public required string DownloadSpeed { get; init; }

        /// <summary>
        /// Gets the upload speed to the peer in bytes/sec.
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public required string UploadSpeed { get; init; }

        /// <summary>
        /// Gets whether the peer is a seeder.
        /// </summary>
        [JsonPropertyName("seeder")]
        public required string Seeder { get; init; }
    }
}
