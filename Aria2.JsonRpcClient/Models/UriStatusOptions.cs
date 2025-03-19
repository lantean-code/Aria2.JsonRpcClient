using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the status of a URI.
    /// </summary>
    public enum UriStatusOptions
    {
        /// <summary>
        /// The URI is in use.
        /// </summary>
        [JsonStringEnumMemberName("used")]
        Used,

        /// <summary>
        /// The URI is still waiting in the queue.
        /// </summary>
        [JsonStringEnumMemberName("waiting")]
        Waiting
    }
}
