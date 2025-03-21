using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    internal record SystemMulticallRequest
    {
        [JsonPropertyName("methodName")]
        public required string MethodName { get; init; }

        [JsonPropertyName("params")]
        public required JsonRpcParameters Parameters { get; init; }
    }
}
