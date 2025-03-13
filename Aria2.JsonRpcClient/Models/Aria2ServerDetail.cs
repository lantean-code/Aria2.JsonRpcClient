using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents details of a server used for a download.
    /// </summary>
    public record Aria2ServerDetail
    {
        /// <summary>
        /// Gets the original URI of the server.
        /// </summary>
        [JsonPropertyName("uri")]
        public required string Uri { get; init; }

        /// <summary>
        /// Gets the current URI used for downloading (may differ due to redirection).
        /// </summary>
        [JsonPropertyName("currentUri")]
        public required string CurrentUri { get; init; }

        /// <summary>
        /// Gets the download speed from this server (in bytes/sec).
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public required string DownloadSpeed { get; init; }
    }
}
