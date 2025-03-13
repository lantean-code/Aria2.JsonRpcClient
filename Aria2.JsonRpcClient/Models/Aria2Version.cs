using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents version information and enabled features of aria2.
    /// </summary>
    public record Aria2Version
    {
        /// <summary>
        /// Gets the version number of aria2.
        /// </summary>
        [JsonPropertyName("version")]
        public required string Version { get; init; }

        /// <summary>
        /// Gets the list of enabled features.
        /// </summary>
        [JsonPropertyName("enabledFeatures")]
        public required IReadOnlyList<string> EnabledFeatures { get; init; }
    }
}
