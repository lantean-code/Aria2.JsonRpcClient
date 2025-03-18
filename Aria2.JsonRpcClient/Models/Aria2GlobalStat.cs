using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents global statistics for the aria2 session.
    /// </summary>
    public record Aria2GlobalStat
    {
        /// <summary>
        /// Overall download speed (byte/sec).
        /// </summary>
        [JsonPropertyName("downloadSpeed")]
        public long DownloadSpeed { get; init; }

        /// <summary>
        /// Overall upload speed(byte/sec).
        /// </summary>
        [JsonPropertyName("uploadSpeed")]
        public long UploadSpeed { get; init; }

        /// <summary>
        /// The number of active downloads.
        /// </summary>
        [JsonPropertyName("numActive")]
        public int NumActive { get; init; }

        /// <summary>
        /// The number of waiting downloads.
        /// </summary>
        [JsonPropertyName("numWaiting")]
        public int NumWaiting { get; init; }

        /// <summary>
        /// The number of stopped downloads in the current session. This value is capped by the --max-download-result option.
        /// </summary>
        [JsonPropertyName("numStopped")]
        public int NumStopped { get; init; }

        /// <summary>
        /// The number of stopped downloads in the current session and not capped by the --max-download-result option.
        /// </summary>
        [JsonPropertyName("numStoppedTotal")]
        public int NumStoppedTotal { get; init; }
    }
}
