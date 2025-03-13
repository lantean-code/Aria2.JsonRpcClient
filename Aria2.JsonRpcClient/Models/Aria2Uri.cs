using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a URI and its status for a download.
    /// </summary>
    public record Aria2Uri
    {
        /// <summary>
        /// Gets the URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public required string Uri { get; init; }

        /// <summary>
        /// Gets the status of the URI (e.g. used, waiting).
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>
        /// Gets a value indicating whether this URI is selected.
        /// </summary>
        [JsonPropertyName("isSelected")]
        public string? IsSelected { get; init; }
    }
}
