using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents URI selection algorithm.
    /// </summary>
    public enum UriSelectorOptions
    {
        /// <summary>
        /// URI is tried in the order appeared in the URI list.
        /// </summary>
        [JsonStringEnumMemberName("inorder")]
        Inorder,

        /// <summary>
        /// aria2 uses download speed observed in the previous downloads and choose fastest server in the URI list. This also effectively skips dead mirrors.
        /// </summary>
        [JsonStringEnumMemberName("feedback")]
        Feedback,

        /// <summary>
        /// Selects one of the best mirrors for the first and reserved connections. For supplementary ones, it returns mirrors which has not been tested yet, and if each of them has already been tested, returns mirrors which has to be tested again. Otherwise, it doesn't select anymore mirrors.
        /// </summary>
        [JsonStringEnumMemberName("adaptive")]
        Adaptive
    }
}
