using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents details of a server used for a download.
    /// </summary>
    public record Aria2ServerDetail
    {
        /// <summary>
        /// Original URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public required string Uri { get; init; }

        /// <summary>
        /// This is the URI currently used for downloading. If redirection is involved, currentUri and uri may differ.
        /// </summary>
        [JsonPropertyName("currentUri")]
        public required string CurrentUri { get; init; }

        /// <summary>
        /// Download speed (byte/sec).
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public long DownloadSpeed { get; init; }
    }
}
