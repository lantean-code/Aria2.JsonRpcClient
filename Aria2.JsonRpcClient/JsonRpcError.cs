using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    internal record JsonRpcError
    {
        [JsonPropertyName("code")]
        public int Code { get; init; }

        [JsonPropertyName("message")]
        public required string Message { get; init; }

        [JsonExtensionData]
        public IDictionary<string, JsonElement> ExtensionData { get; set; } = new Dictionary<string, JsonElement>();
    }
}
