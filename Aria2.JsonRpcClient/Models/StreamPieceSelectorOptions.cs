using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the algorithm used for selecting pieces in segmented downloads.
    /// </summary>
    public enum StreamPieceSelectorOptions
    {
        /// <summary>
        /// Select a piece to reduce the number of connections established. This is reasonable default behavior because establishing a connection is an expensive operation.
        /// </summary>
        [JsonStringEnumMemberName("default")]
        Default,

        /// <summary>
        /// Select a piece closest to the beginning of the file. This is useful for viewing movies while downloading. <seealso cref="Aria2DownloadOptions.EnableHttpPipelining"/> option may be useful to reduce re-connection overhead. Note that aria2 honors <seealso cref="Aria2DownloadOptions.MinSplitSize"/> option, so it will be necessary to specify a reasonable value to <seealso cref="Aria2DownloadOptions.MinSplitSize"/> option.
        /// </summary>
        [JsonStringEnumMemberName("inorder")]
        Inorder,

        /// <summary>
        /// Select a piece randomly. Like <see cref="Inorder"/>, <seealso cref="Aria2DownloadOptions.MinSplitSize"/> option is honored.
        /// </summary>
        [JsonStringEnumMemberName("random")]
        Random,

        /// <summary>
        /// When starting to download a file, select a piece closest to the beginning of the file like <see cref="Inorder"/>, but then exponentially increases space between pieces. This reduces the number of connections established, while at the same time downloads the beginning part of the file first. This is useful for viewing movies while downloading.
        /// </summary>
        [JsonStringEnumMemberName("geom")]
        Geom
    }
}
