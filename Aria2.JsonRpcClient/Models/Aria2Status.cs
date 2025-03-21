using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the detailed status information of a download.
    /// </summary>
    public record Aria2Status
    {
        /// <summary>
        /// Provides constant keys corresponding to the JSON property names.
        /// </summary>
        public static class Keys
        {
            /// <inheritdoc cref="Aria2Status.Gid"/>
            public const string Gid = "gid";

            /// <inheritdoc cref="Aria2Status.Status"/>
            public const string Status = "status";

            /// <inheritdoc cref="Aria2Status.TotalLength"/>
            public const string TotalLength = "totalLength";

            /// <inheritdoc cref="Aria2Status.CompletedLength"/>
            public const string CompletedLength = "completedLength";

            /// <inheritdoc cref="Aria2Status.UploadLength"/>
            public const string UploadLength = "uploadLength";

            /// <inheritdoc cref="Aria2Status.Bitfield"/>
            public const string Bitfield = "bitfield";

            /// <inheritdoc cref="Aria2Status.DownloadSpeed"/>
            public const string DownloadSpeed = "downloadSpeed";

            /// <inheritdoc cref="Aria2Status.UploadSpeed"/>
            public const string UploadSpeed = "uploadSpeed";

            /// <inheritdoc cref="Aria2Status.InfoHash"/>
            public const string InfoHash = "infoHash";

            /// <inheritdoc cref="Aria2Status.NumSeeders"/>
            public const string NumSeeders = "numSeeders";

            /// <inheritdoc cref="Aria2Status.Seeder"/>
            public const string Seeder = "seeder";

            /// <inheritdoc cref="Aria2Status.PieceLength"/>
            public const string PieceLength = "pieceLength";

            /// <inheritdoc cref="Aria2Status.NumPieces"/>
            public const string NumPieces = "numPieces";

            /// <inheritdoc cref="Aria2Status.Connections"/>
            public const string Connections = "connections";

            /// <inheritdoc cref="Aria2Status.ErrorCode"/>
            public const string ErrorCode = "errorCode";

            /// <inheritdoc cref="Aria2Status.ErrorMessage"/>
            public const string ErrorMessage = "errorMessage";

            /// <inheritdoc cref="Aria2Status.FollowedBy"/>
            public const string FollowedBy = "followedBy";

            /// <inheritdoc cref="Aria2Status.Following"/>
            public const string Following = "following";

            /// <inheritdoc cref="Aria2Status.BelongsTo"/>
            public const string BelongsTo = "belongsTo";

            /// <inheritdoc cref="Aria2Status.Dir"/>
            public const string Dir = "dir";

            /// <inheritdoc cref="Aria2Status.Files"/>
            public const string Files = "files";

            /// <inheritdoc cref="Aria2Status.Bittorrent"/>
            public const string Bittorrent = "bittorrent";

            /// <inheritdoc cref="Aria2Status.VerifiedLength"/>
            public const string VerifiedLength = "verifiedLength";

            /// <inheritdoc cref="Aria2Status.VerifyIntegrityPending"/>
            public const string VerifyIntegrityPending = "verifyIntegrityPending";

            /// <summary>
            /// Matches the name of the Property to the key value.
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            /// <exception cref="InvalidOperationException"></exception>
            public static string Match(string name)
            {
                return name switch
                {
                    nameof(Gid) => Gid,
                    nameof(Status) => Status,
                    nameof(TotalLength) => TotalLength,
                    nameof(CompletedLength) => CompletedLength,
                    nameof(UploadLength) => UploadLength,
                    nameof(Bitfield) => Bitfield,
                    nameof(DownloadSpeed) => DownloadSpeed,
                    nameof(UploadSpeed) => UploadSpeed,
                    nameof(InfoHash) => InfoHash,
                    nameof(NumSeeders) => NumSeeders,
                    nameof(Seeder) => Seeder,
                    nameof(PieceLength) => PieceLength,
                    nameof(NumPieces) => NumPieces,
                    nameof(Connections) => Connections,
                    nameof(ErrorCode) => ErrorCode,
                    nameof(ErrorMessage) => ErrorMessage,
                    nameof(FollowedBy) => FollowedBy,
                    nameof(Following) => Following,
                    nameof(BelongsTo) => BelongsTo,
                    nameof(Dir) => Dir,
                    nameof(Files) => Files,
                    nameof(Bittorrent) => Bittorrent,
                    nameof(VerifiedLength) => VerifiedLength,
                    nameof(VerifyIntegrityPending) => VerifyIntegrityPending,
                    _ => throw new InvalidOperationException($"Unmatched name '{name}'."),
                };
            }
        }

        /// <summary>
        /// GID of the download.
        /// </summary>
        [JsonPropertyName(Keys.Gid)]
        public string? Gid { get; init; }

        /// <summary>
        /// <see cref="StatusOptions.Active"/> for currently downloading/seeding downloads.
        /// <see cref="StatusOptions.Waiting"/> for downloads in the queue; download is not started.
        /// <see cref="StatusOptions.Paused"/> for paused downloads.
        /// <see cref="StatusOptions.Error"/> for downloads that were stopped because of error.
        /// <see cref="StatusOptions.Complete"/> for stopped and completed downloads.
        /// <see cref="StatusOptions.Removed"/> for the downloads removed by user.
        /// </summary>
        [JsonPropertyName(Keys.Status)]
        public StatusOptions? Status { get; init; }

        /// <summary>
        /// Total length of the download in bytes.
        /// </summary>
        [JsonPropertyName(Keys.TotalLength)]
        public long? TotalLength { get; init; }

        /// <summary>
        /// Completed length of the download in bytes.
        /// </summary>
        [JsonPropertyName(Keys.CompletedLength)]
        public long? CompletedLength { get; init; }

        /// <summary>
        /// Uploaded length of the download in bytes.
        /// </summary>
        [JsonPropertyName(Keys.UploadLength)]
        public long? UploadLength { get; init; }

        /// <summary>
        /// Hexadecimal representation of the download progress. The highest bit corresponds to the piece at index 0. Any set bits indicate loaded pieces, while unset bits indicate not yet loaded and/or missing pieces. Any overflow bits at the end are set to zero. When the download was not started yet, this key will not be included in the response.
        /// </summary>
        [JsonPropertyName(Keys.Bitfield)]
        public string? Bitfield { get; init; }

        /// <summary>
        /// Download speed of this download measured in bytes/sec.
        /// </summary>
        [JsonPropertyName(Keys.DownloadSpeed)]
        public long? DownloadSpeed { get; init; }

        /// <summary>
        /// Upload speed of this download measured in bytes/sec.
        /// </summary>
        [JsonPropertyName(Keys.UploadSpeed)]
        public long? UploadSpeed { get; init; }

        /// <summary>
        /// InfoHash. BitTorrent only.
        /// </summary>
        [JsonPropertyName(Keys.InfoHash)]
        public string? InfoHash { get; init; }

        /// <summary>
        /// The number of seeders aria2 has connected to. BitTorrent only.
        /// </summary>
        [JsonPropertyName(Keys.NumSeeders)]
        public int? NumSeeders { get; init; }

        /// <summary>
        /// true if the local endpoint is a seeder. Otherwise false. BitTorrent only.
        /// </summary>
        [JsonPropertyName(Keys.Seeder)]
        public bool? Seeder { get; init; }

        /// <summary>
        /// Piece length in bytes.
        /// </summary>
        [JsonPropertyName(Keys.PieceLength)]
        public long? PieceLength { get; init; }

        /// <summary>
        /// The number of pieces.
        /// </summary>
        [JsonPropertyName(Keys.NumPieces)]
        public int? NumPieces { get; init; }

        /// <summary>
        /// The number of peers/servers aria2 has connected to.
        /// </summary>
        [JsonPropertyName(Keys.Connections)]
        public int? Connections { get; init; }

        /// <summary>
        /// The code of the last error for this item, if any. This value is only available for stopped/completed downloads.
        /// </summary>
        [JsonPropertyName(Keys.ErrorCode)]
        public Aria2ErrorCode? ErrorCode { get; init; }

        /// <summary>
        /// The (hopefully) human readable error message associated to <see cref="ErrorCode"/>.
        /// </summary>
        [JsonPropertyName(Keys.ErrorMessage)]
        public string? ErrorMessage { get; init; }

        /// <summary>
        /// List of GIDs which are generated as the result of this download. For example, when aria2 downloads a Metalink file, it generates downloads described in the Metalink (see the <see cref="Aria2DownloadOptions.FollowMetalink"/> option). This value is useful to track auto-generated downloads. If there are no such downloads, this will be null.
        /// </summary>
        [JsonPropertyName(Keys.FollowedBy)]
        public IReadOnlyList<string>? FollowedBy { get; init; }

        /// <summary>
        /// The reverse link for <see cref="FollowedBy"/>. A download included in <see cref="FollowedBy"/> has this object's GID in its following value.
        /// </summary>
        [JsonPropertyName(Keys.Following)]
        public string? Following { get; init; }

        /// <summary>
        /// GID of a parent download. Some downloads are a part of another download. For example, if a file in a Metalink has BitTorrent resources, the downloads of ".torrent" files are parts of that parent. If this download has no parent, this key will not be included in the response.
        /// </summary>
        [JsonPropertyName(Keys.BelongsTo)]
        public string? BelongsTo { get; init; }

        /// <summary>
        /// Directory to save files.
        /// </summary>
        [JsonPropertyName(Keys.Dir)]
        public string? Dir { get; init; }

        /// <summary>
        /// Returns the list of files.
        /// </summary>
        [JsonPropertyName(Keys.Files)]
        public IReadOnlyList<Aria2File>? Files { get; init; }

        /// <summary>
        /// Contains information retrieved from the .torrent (file). BitTorrent only.
        /// </summary>
        [JsonPropertyName(Keys.Bittorrent)]
        public Aria2Bittorrent? Bittorrent { get; init; }

        /// <summary>
        /// The number of verified number of bytes while the files are being hash checked. This will be null unless this download is being hash checked.
        /// </summary>
        [JsonPropertyName(Keys.VerifiedLength)]
        public long? VerifiedLength { get; init; }

        /// <summary>
        /// true if this download is waiting for the hash check in a queue. This will be null unless this download is in the queue.
        /// </summary>
        [JsonPropertyName(Keys.VerifyIntegrityPending)]
        public bool? VerifyIntegrityPending { get; init; }
    }
}
