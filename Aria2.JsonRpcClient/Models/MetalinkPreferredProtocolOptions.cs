using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the preferred protocol for Metalink downloads.
    /// </summary>
    public enum MetalinkPreferredProtocolOptions
    {
        /// <summary>
        /// HTTP
        /// </summary>
        [JsonStringEnumMemberName("http")]
        Http,

        /// <summary>
        /// HTTPS
        /// </summary>
        [JsonStringEnumMemberName("https")]
        Https,

        /// <summary>
        /// FTP
        /// </summary>
        [JsonStringEnumMemberName("ftp")]
        Ftp,

        /// <summary>
        /// None
        /// </summary>
        [JsonStringEnumMemberName("none")]
        None
    }
}
