using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the method used for proxy requests.
    /// </summary>
    public enum ProxyMethodOptions
    {
        /// <summary>
        /// GET proxy method.
        /// </summary>
        [JsonStringEnumMemberName("get")]
        Get,

        /// <summary>
        /// TUNNEL proxy method.
        /// </summary>
        [JsonStringEnumMemberName("tunnel")]
        Tunnel
    }
}
