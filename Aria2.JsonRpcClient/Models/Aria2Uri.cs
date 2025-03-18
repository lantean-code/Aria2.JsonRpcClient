using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a URI and its status for a download.
    /// </summary>
    public record Aria2Uri
    {
        /// <summary>
        /// The URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public required string Uri { get; init; }

        /// <summary>
        /// URI status.
        /// </summary>
        [JsonPropertyName("status")]
        public UriStatusOptions Status { get; init; }
    }
}
