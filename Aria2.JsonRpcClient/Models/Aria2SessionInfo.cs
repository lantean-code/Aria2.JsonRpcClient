using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents session information including the session ID.
    /// </summary>
    public record Aria2SessionInfo
    {
        /// <summary>
        /// Gets the session ID generated for this aria2 session.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public required string SessionId { get; init; }
    }
}
