using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    internal record JsonRpcNotification
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; init; } = "2.0";

        [JsonPropertyName("method")]
        public required string Method { get; init; }

        [JsonPropertyName("params")]
        public IReadOnlyList<GidWrapper> Parameters { get; init; } = [];
    }
}
