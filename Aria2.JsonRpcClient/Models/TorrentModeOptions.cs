using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the file mode of the torrent.
    /// </summary>
    public enum TorrentModeOptions
    {
        /// <summary>
        /// Single-file mode.
        /// </summary>
        [JsonStringEnumMemberName("single")]
        Single,
        /// <summary>
        /// Multi-file mode.
        /// </summary>
        [JsonStringEnumMemberName("multi")]
        Multi
    }
}
