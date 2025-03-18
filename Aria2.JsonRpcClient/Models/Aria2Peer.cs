using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a peer for a BitTorrent download.
    /// </summary>
    public record Aria2Peer
    {
        /// <summary>
        /// Percent-encoded peer ID.
        /// </summary>
        [JsonPropertyName("peerId")]
        public string? PeerId { get; init; }

        /// <summary>
        /// IP address of the peer.
        /// </summary>
        [JsonPropertyName("ip")]
        public required string Ip { get; init; }

        /// <summary>
        /// Port number of the peer.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; init; }

        /// <summary>
        /// Hexadecimal representation of the download progress of the peer. The highest bit corresponds to the piece at index 0. Set bits indicate the piece is available and unset bits indicate the piece is missing. Any spare bits at the end are set to zero.
        /// </summary>
        [JsonPropertyName("bitfield")]
        public string? Bitfield { get; init; }

        /// <summary>
        /// true if aria2 is choking the peer. Otherwise false.
        /// </summary>
        [JsonPropertyName("amChoking")]
        public bool AmChoking { get; init; }

        /// <summary>
        /// true if the peer is choking aria2. Otherwise false.
        /// </summary>
        [JsonPropertyName("peerChoking")]
        public bool PeerChoking { get; init; }

        /// <summary>
        /// Download speed (byte/sec) that this client obtains from the peer.
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public long DownloadSpeed { get; init; }

        /// <summary>
        /// Upload speed(byte/sec) that this client uploads to the peer.
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public long UploadSpeed { get; init; }

        /// <summary>
        /// true if this peer is a seeder. Otherwise false.
        /// </summary>
        [JsonPropertyName("seeder")]
        public bool Seeder { get; init; }
    }
}
