using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents global statistics for the aria2 session.
    /// </summary>
    public record Aria2GlobalStat
    {
        /// <summary>
        /// Gets the overall download speed in bytes/sec.
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public required string DownloadSpeed { get; init; }

        /// <summary>
        /// Gets the overall upload speed in bytes/sec.
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public required string UploadSpeed { get; init; }

        /// <summary>
        /// Gets the number of active downloads.
        /// </summary>
        [JsonPropertyName("numActive")]
        public required string NumActive { get; init; }

        /// <summary>
        /// Gets the number of waiting downloads.
        /// </summary>
        [JsonPropertyName("numWaiting")]
        public required string NumWaiting { get; init; }

        /// <summary>
        /// Gets the number of stopped downloads in the current session.
        /// </summary>
        [JsonPropertyName("numStopped")]
        public required string NumStopped { get; init; }

        /// <summary>
        /// Gets the total number of stopped downloads in the session.
        /// </summary>
        [JsonPropertyName("numStoppedTotal")]
        public required string NumStoppedTotal { get; init; }
    }
}
