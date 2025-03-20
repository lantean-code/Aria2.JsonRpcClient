using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    internal readonly struct GidWrapper
    {
        [JsonPropertyName("gid")]
        public required string Gid { get; init; }
    }
}
