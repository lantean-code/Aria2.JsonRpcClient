using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the detailed status information of a download.
    /// </summary>
    public record Aria2Status
    {
        /// <summary>
        /// GID of the download.
        /// </summary>
        [JsonPropertyName("gid")]
        public string? Gid { get; init; }

        /// <summary>
        /// <see cref="StatusOptions.Active"/> for currently downloading/seeding downloads.
        /// <see cref="StatusOptions.Waiting"/> for downloads in the queue; download is not started.
        /// <see cref="StatusOptions.Paused"/> for paused downloads.
        /// <see cref="StatusOptions.Error"/> for downloads that were stopped because of error.
        /// <see cref="StatusOptions.Complete"/> for stopped and completed downloads.
        /// <see cref="StatusOptions.Removed"/> for the downloads removed by user.
        /// </summary>
        [JsonPropertyName("status")]
        public StatusOptions? Status { get; init; }

        /// <summary>
        /// Total length of the download in bytes.
        /// </summary>
        [JsonPropertyName("totalLength")]
        public long? TotalLength { get; init; }

        /// <summary>
        /// Completed length of the download in bytes.
        /// </summary>
        [JsonPropertyName("completedLength")]
        public long? CompletedLength { get; init; }

        /// <summary>
        /// Uploaded length of the download in bytes.
        /// </summary>
        [JsonPropertyName("uploadLength")]
        public long? UploadLength { get; init; }

        /// <summary>
        /// Hexadecimal representation of the download progress. The highest bit corresponds to the piece at index 0. Any set bits indicate loaded pieces, while unset bits indicate not yet loaded and/or missing pieces. Any overflow bits at the end are set to zero. When the download was not started yet, this key will not be included in the response.
        /// </summary>
        [JsonPropertyName("bitfield")]
        public string? Bitfield { get; init; }

        /// <summary>
        /// Download speed of this download measured in bytes/sec.
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public long? DownloadSpeed { get; init; }

        /// <summary>
        /// Upload speed of this download measured in bytes/sec.
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public long? UploadSpeed { get; init; }

        /// <summary>
        /// InfoHash. BitTorrent only.
        /// </summary>
        [JsonPropertyName("infoHash")]
        public string? InfoHash { get; init; }

        /// <summary>
        /// The number of seeders aria2 has connected to. BitTorrent only.
        /// </summary>
        [JsonPropertyName("numSeeders")]
        public int? NumSeeders { get; init; }

        /// <summary>
        /// true if the local endpoint is a seeder. Otherwise false. BitTorrent only.
        /// </summary>
        [JsonPropertyName("seeder")]
        public bool? Seeder { get; init; }

        /// <summary>
        /// Piece length in bytes.
        /// </summary>
        [JsonPropertyName("pieceLength")]
        public long? PieceLength { get; init; }

        /// <summary>
        /// The number of pieces.
        /// </summary>
        [JsonPropertyName("numPieces")]
        public int? NumPieces { get; init; }

        /// <summary>
        /// The number of peers/servers aria2 has connected to.
        /// </summary>
        [JsonPropertyName("connections")]
        public int? Connections { get; init; }

        /// <summary>
        /// The code of the last error for this item, if any. This value is only available for stopped/completed downloads.
        /// </summary>
        [JsonPropertyName("errorCode")]
        public Aria2ErrorCode? ErrorCode { get; init; }

        /// <summary>
        /// The (hopefully) human readable error message associated to <see cref="ErrorCode"/>.
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; init; }

        /// <summary>
        /// List of GIDs which are generated as the result of this download. For example, when aria2 downloads a Metalink file, it generates downloads described in the Metalink (see the <see cref="Aria2DownloadOptions.FollowMetalink"/> option). This value is useful to track auto-generated downloads. If there are no such downloads, this will be null.
        /// </summary>
        [JsonPropertyName("followedBy")]
        public IReadOnlyList<string>? FollowedBy { get; init; }

        /// <summary>
        /// The reverse link for <see cref="FollowedBy"/>. A download included in <see cref="FollowedBy"/> has this object's GID in its following value.
        /// </summary>
        [JsonPropertyName("following")]
        public string? Following { get; init; }

        /// <summary>
        /// GID of a parent download. Some downloads are a part of another download. For example, if a file in a Metalink has BitTorrent resources, the downloads of ".torrent" files are parts of that parent. If this download has no parent, this key will not be included in the response.
        /// </summary>
        [JsonPropertyName("belongsTo")]
        public string? BelongsTo { get; init; }

        /// <summary>
        /// Directory to save files.
        /// </summary>
        [JsonPropertyName("dir")]
        public string? Dir { get; init; }

        /// <summary>
        /// Returns the list of files.
        /// </summary>
        [JsonPropertyName("files")]
        public IReadOnlyList<Aria2File>? Files { get; init; }

        /// <summary>
        /// Contains information retrieved from the .torrent (file). BitTorrent only.
        /// </summary>
        [JsonPropertyName("bittorrent")]
        public Aria2Bittorrent? Bittorrent { get; init; }

        /// <summary>
        /// The number of verified number of bytes while the files are being hash checked. This will be null unless this download is being hash checked.
        /// </summary>
        [JsonPropertyName("verifiedLength")]
        public long? VerifiedLength { get; init; }

        /// <summary>
        /// true if this download is waiting for the hash check in a queue. This will be null unless this download is in the queue.
        /// </summary>
        [JsonPropertyName("verifyIntegrityPending")]
        public bool? VerifyIntegrityPending { get; init; }
    }
}
