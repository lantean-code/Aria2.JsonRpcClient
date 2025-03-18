using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents session information including the session ID.
    /// </summary>
    public record Aria2SessionInfo
    {
        /// <summary>
        /// Session ID, which is generated each time when aria2 is invoked.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public required string SessionId { get; init; }
    }
}
