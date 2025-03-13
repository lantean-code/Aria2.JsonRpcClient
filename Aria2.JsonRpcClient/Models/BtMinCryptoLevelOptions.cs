using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents minimum BitTorrent crypto level.
    /// </summary>
    public enum BtMinCryptoLevelOptions
    {
        /// <summary>
        /// No encryption.
        /// </summary>
        [JsonStringEnumMemberName("plain")]
        Plain,

        /// <summary>
        /// Require encryption.
        /// </summary>
        [JsonStringEnumMemberName("arc4")]
        Arc4
    }
}
