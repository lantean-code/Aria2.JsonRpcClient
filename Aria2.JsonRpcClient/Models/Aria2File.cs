using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a file within a download.
    /// </summary>
    public record Aria2File
    {
        /// <summary>
        /// Index of the file, starting at 1, in the same order as files appear in the multi-file torrent.
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; init; }

        /// <summary>
        /// File path.
        /// </summary>
        [JsonPropertyName("path")]
        public required string Path { get; init; }

        /// <summary>
        /// File size in bytes.
        /// </summary>
        [JsonPropertyName("length")]
        public long Length { get; init; }

        /// <summary>
        /// Completed length of this file in bytes. Please note that it is possible that sum of <see cref="CompletedLength"/> is less than the <seealso cref="CompletedLength"/> returned by the <see cref="IAria2Client.GetFiles"/> method. This is because completedLength in <see cref="IAria2Client.GetFiles"/> only includes completed pieces. On the other hand, completedLength in <see cref="IAria2Client.TellStatus(string, string[], string?)"/> also includes partially completed pieces.
        /// </summary>
        [JsonPropertyName("completedLength")]
        public long CompletedLength { get; init; }

        /// <summary>
        /// true if this file is selected by <see cref="Aria2DownloadOptions.SelectFile"/> option. If<see cref="Aria2DownloadOptions.SelectFile"/> is not specified or this is single-file torrent or not a torrent download at all, this value is always true. Otherwise false.
        /// </summary>
        [JsonPropertyName("selected")]
        public bool Selected { get; init; }

        /// <summary>
        /// Returns a list of URIs for this file.
        /// </summary>
        [JsonPropertyName("uris")]
        public IReadOnlyList<Aria2Uri>? Uris { get; init; }
    }
}
