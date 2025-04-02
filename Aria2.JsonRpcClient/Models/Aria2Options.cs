using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the options of a download.
    /// Any options not mapped to a specific property are in <see cref="AdditionalOptions"/>.
    /// </summary>
    public record Aria2Options : Aria2DownloadOptions
    {
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-want-digest-header"/>
        [JsonPropertyName("no-want-digest-header"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NoWantDigestHeader { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-not-found"/>
        [JsonPropertyName("save-not-found"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SaveNotFound { get; init; }

        /// <summary>
        /// Gets a dictionary of option additional key-value pairs.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalOptions { get; set; } = new Dictionary<string, object>();
    }
}
