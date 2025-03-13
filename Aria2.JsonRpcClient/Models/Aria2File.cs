using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a file within a download.
    /// </summary>
    public record Aria2File
    {
        /// <summary>
        /// Gets the index of the file (as a string).
        /// </summary>
        [JsonPropertyName("index")]
        public required string Index { get; init; }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        [JsonPropertyName("path")]
        public required string Path { get; init; }

        /// <summary>
        /// Gets the file length in bytes.
        /// </summary>
        [JsonPropertyName("length")]
        public required string Length { get; init; }

        /// <summary>
        /// Gets the completed length of the file in bytes.
        /// </summary>
        [JsonPropertyName("completedLength")]
        public required string CompletedLength { get; init; }

        /// <summary>
        /// Gets whether the file is selected (as a string).
        /// </summary>
        [JsonPropertyName("selected")]
        public required string Selected { get; init; }

        /// <summary>
        /// Gets the list of URIs associated with this file.
        /// </summary>
        [JsonPropertyName("uris")]
        public IReadOnlyList<Aria2Uri>? Uris { get; init; }
    }
}
