using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the options of a download as a dictionary.
    /// Any options not mapped to a specific property are captured here.
    /// </summary>
    public record Aria2Options : Aria2DownloadOptions
    {
        /// <summary>
        /// Gets a dictionary of option additional key-value pairs.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object>? AdditionalOptions { get; set; }
    }
}
