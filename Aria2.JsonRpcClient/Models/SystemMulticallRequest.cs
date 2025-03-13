using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a system multicall request, encapsulating a method call and its parameters.
    /// </summary>
    public record SystemMulticallRequest
    {
        /// <summary>
        /// Gets the name of the method to be called.
        /// </summary>
        [JsonPropertyName("methodName")]
        public required string MethodName { get; init; }

        /// <summary>
        /// Gets the parameters for the method call.
        /// </summary>
        [JsonPropertyName("params")]
        public required JsonRpcParameters Parameters { get; init; }
    }
}
