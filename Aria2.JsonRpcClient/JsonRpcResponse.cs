using System.Diagnostics.CodeAnalysis;
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

        [JsonExtensionData]
        public IDictionary<string, JsonElement> ExtensionData { get; init; } = new Dictionary<string, JsonElement>();
    }

    internal record JsonRpcResponse<T> : JsonRpcResponse
    {
        [JsonPropertyName("result")]
        public T? Result { get; init; }
    }
}
