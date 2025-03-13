using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents FTP transfer type.
    /// </summary>
    public enum FtpTypeOptions
    {
        /// <summary>
        /// Binary transfer type.
        /// </summary>
        [JsonStringEnumMemberName("binary")]
        Binary,

        /// <summary>
        /// ASCII transfer type.
        /// </summary>
        [JsonStringEnumMemberName("ascii")]
        Ascii
    }
}
