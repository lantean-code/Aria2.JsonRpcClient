using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a server group returned by aria2.getServers.
    /// </summary>
    public record Aria2Server
    {
        /// <summary>
        /// Gets the file index (as a string) corresponding to the group.
        /// </summary>
        [JsonPropertyName("index")]
        public required string Index { get; init; }

        /// <summary>
        /// Gets the list of server details.
        /// </summary>
        [JsonPropertyName("servers")]
        public required IReadOnlyList<Aria2ServerDetail> Servers { get; init; } = [];
    }
}
