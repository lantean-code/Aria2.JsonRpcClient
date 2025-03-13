using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents file allocation method.
    /// </summary>
    public enum FileAllocationOptions
    {
        /// <summary>
        /// No file allocation method is specified.
        /// </summary>
        [JsonStringEnumMemberName("none")]
        None,

        /// <summary>
        /// Pre-allocate file space before download begins.
        /// </summary>
        [JsonStringEnumMemberName("prealloc")]
        Prealloc,

        /// <summary>
        /// Allocate file space as the download progresses.
        /// </summary>
        [JsonStringEnumMemberName("trunc")]
        Trunc,

        /// <summary>
        /// Use the file system's fallocate function to pre-allocate space.
        /// </summary>
        [JsonStringEnumMemberName("falloc")]
        Falloc
    }
}
