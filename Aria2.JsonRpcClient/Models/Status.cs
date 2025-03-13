using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the status of a download.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Currently downloading/seeding.
        /// </summary>
        [JsonStringEnumMemberName("active")]
        Active,

        /// <summary>
        /// Downloads in the queue. Not started.
        /// </summary>
        [JsonStringEnumMemberName("waiting")]
        Waiting,

        /// <summary>
        /// Paused download.
        /// </summary>
        [JsonStringEnumMemberName("paused")]
        Paused,

        /// <summary>
        /// Download stopped because of an error.
        /// </summary>
        [JsonStringEnumMemberName("error")]
        Error,

        /// <summary>
        /// Stopped or completed download.
        /// </summary>
        [JsonStringEnumMemberName("complete")]
        Complete,

        /// <summary>
        /// Downoad removed by the user.
        /// </summary>
        [JsonStringEnumMemberName("removed")]
        Removed
    }
}
