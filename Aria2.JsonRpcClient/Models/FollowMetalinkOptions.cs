using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the options for following metalink files.
    /// </summary>
    public enum FollowMetalinkOptions
    {
        /// <summary>
        /// Parses a metalink file and downloads the files listed in it. The metalink file is downloaded to disk.
        /// </summary>
        [JsonStringEnumMemberName("true")]
        True,

        /// <summary>
        /// Does not parse a metalink file but still downloads it to disk.
        /// </summary>
        [JsonStringEnumMemberName("false")]
        False,

        /// <summary>
        /// Parses a metalink file and downloads the files listed in it. The metalink file is not downloaded to disk.
        /// </summary>
        [JsonStringEnumMemberName("mem")]
        Mem
    }
}
