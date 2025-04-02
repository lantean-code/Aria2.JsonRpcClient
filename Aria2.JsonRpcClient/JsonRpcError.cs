using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// An object representing an aria2 error.
    /// </summary>
    public record JsonRpcError
    {
        /// <summary>
        /// The numerical code for the error.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; init; }

        /// <summary>
        /// A human readable error message.
        /// </summary>
        [JsonPropertyName("message")]
        public required string Message { get; init; }

#if DEBUG
        /// <summary>
        /// This is used for debugging purposes only.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JsonElement> ExtensionData { get; set; } = new Dictionary<string, JsonElement>();
#endif
    }
}
