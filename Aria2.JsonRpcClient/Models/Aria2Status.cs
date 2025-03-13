using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the detailed status information of a download.
    /// </summary>
    public record Aria2Status
    {
        /// <summary>
        /// Gets the unique GID of the download.
        /// </summary>
        [JsonPropertyName("gid")]
        public string? Gid { get; init; }

        /// <summary>
        /// Gets the current status (e.g. active, waiting, paused, error, complete, removed).
        /// </summary>
        [JsonPropertyName("status")]
        public Status? Status { get; init; }

        /// <summary>
        /// Gets the total length of the download in bytes.
        /// </summary>
        [JsonPropertyName("totalLength")]
        public string? TotalLength { get; init; }

        /// <summary>
        /// Gets the completed length in bytes.
        /// </summary>
        [JsonPropertyName("completedLength")]
        public string? CompletedLength { get; init; }

        /// <summary>
        /// Gets the upload length in bytes.
        /// </summary>
        [JsonPropertyName("uploadLength")]
        public string? UploadLength { get; init; }

        /// <summary>
        /// Gets the hexadecimal representation of the download progress.
        /// </summary>
        [JsonPropertyName("bitfield")]
        public string? Bitfield { get; init; }

        /// <summary>
        /// Gets the current download speed in bytes/sec.
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public string? DownloadSpeed { get; init; }

        /// <summary>
        /// Gets the current upload speed in bytes/sec.
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public string? UploadSpeed { get; init; }

        /// <summary>
        /// Gets the info hash (for BitTorrent downloads).
        /// </summary>
        [JsonPropertyName("infoHash")]
        public string? InfoHash { get; init; }

        /// <summary>
        /// Gets the number of seeders connected (for BitTorrent).
        /// </summary>
        [JsonPropertyName("numSeeders")]
        public string? NumSeeders { get; init; }

        /// <summary>
        /// Gets a value indicating whether the local endpoint is a seeder.
        /// </summary>
        [JsonPropertyName("seeder")]
        public string? Seeder { get; init; }

        /// <summary>
        /// Gets the piece length in bytes.
        /// </summary>
        [JsonPropertyName("pieceLength")]
        public string? PieceLength { get; init; }

        /// <summary>
        /// Gets the total number of pieces.
        /// </summary>
        [JsonPropertyName("numPieces")]
        public string? NumPieces { get; init; }

        /// <summary>
        /// Gets the number of connections (peers or servers) used.
        /// </summary>
        [JsonPropertyName("connections")]
        public string? Connections { get; init; }

        /// <summary>
        /// Gets the error code as a string (if any).
        /// </summary>
        [JsonPropertyName("errorCode")]
        public string? ErrorCode { get; init; }

        /// <summary>
        /// Gets the human-readable error message.
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; init; }

        /// <summary>
        /// Gets the list of GIDs generated as a result of this download.
        /// </summary>
        [JsonPropertyName("followedBy")]
        public IReadOnlyList<string>? FollowedBy { get; init; }

        /// <summary>
        /// Gets the reverse link from auto-generated downloads.
        /// </summary>
        [JsonPropertyName("following")]
        public string? Following { get; init; }

        /// <summary>
        /// Gets the parent GID for downloads that are part of another download.
        /// </summary>
        [JsonPropertyName("belongsTo")]
        public string? BelongsTo { get; init; }

        /// <summary>
        /// Gets the directory where the files are saved.
        /// </summary>
        [JsonPropertyName("dir")]
        public string? Dir { get; init; }

        /// <summary>
        /// Gets the list of files associated with this download.
        /// </summary>
        [JsonPropertyName("files")]
        public IReadOnlyList<Aria2File>? Files { get; init; }

        /// <summary>
        /// Gets the number of verified bytes while hash checking.
        /// </summary>
        [JsonPropertyName("verifiedLength")]
        public string? VerifiedLength { get; init; }

        /// <summary>
        /// Gets a value indicating whether the download is pending integrity verification.
        /// </summary>
        [JsonPropertyName("verifyIntegrityPending")]
        public string? VerifyIntegrityPending { get; init; }
    }
}
