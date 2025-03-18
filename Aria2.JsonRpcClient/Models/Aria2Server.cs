using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a server group returned by aria2.getServers.
    /// </summary>
    public record Aria2Server
    {
        /// <summary>
        /// Index of the file, starting at 1, in the same order as files appear in the multi-file metalink.
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; init; }

        /// <summary>
        /// Gets the list of server details.
        /// </summary>
        [JsonPropertyName("servers")]
        public required IReadOnlyList<Aria2ServerDetail> Servers { get; init; } = [];
    }
}
