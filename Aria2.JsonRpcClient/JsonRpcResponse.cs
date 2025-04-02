using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    internal record JsonRpcResponse
    {
        [JsonPropertyName("jsonrpc")]
        public required string JsonRpc { get; init; }

        [JsonPropertyName("error")]
        public JsonRpcError? Error { get; init; }

        [JsonPropertyName("id")]
        public required string Id { get; init; }

#if DEBUG
        [JsonExtensionData]
        public IDictionary<string, JsonElement> ExtensionData { get; set; } = new Dictionary<string, JsonElement>();
#endif
    }

    internal record JsonRpcResponse<T> : JsonRpcResponse
    {
        [JsonPropertyName("result")]
        public T? Result { get; init; }
    }
}
