namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the error codes returned by aria2.
    /// </summary>
    public enum Aria2ErrorCode
    {
        /// <summary>
        /// If all downloads were successful.
        /// </summary>
        Success = 0,

        /// <summary>
        /// If an unknown error occurred.
        /// </summary>
        UnknownError = 1,

        /// <summary>
        /// If a timeout occurred.
        /// </summary>
        Timeout = 2,

        /// <summary>
        /// If a resource was not found.
        /// </summary>
        ResourceNotFound = 3,

        /// <summary>
        /// If aria2 saw the specified number of "resource not found" errors.
        /// See --max-file-not-found option.
        /// </summary>
        MaxFileNotFoundExceeded = 4,

        /// <summary>
        /// If a download was aborted because the download speed was too slow.
        /// See --lowest-speed-limit option.
        /// </summary>
        DownloadTooSlow = 5,

        /// <summary>
        /// If a network problem occurred.
        /// </summary>
        NetworkProblem = 6,

        /// <summary>
        /// If there were unfinished downloads.
        /// This error is only reported if all finished downloads were successful
        /// and there were unfinished downloads in a queue when aria2 exited
        /// by pressing Ctrl-C or sending a TERM or INT signal.
        /// </summary>
        UnfinishedDownloads = 7,

        /// <summary>
        /// If the remote server did not support resume when resume was required
        /// to complete the download.
        /// </summary>
        ResumeNotSupported = 8,

        /// <summary>
        /// If there was not enough disk space available.
        /// </summary>
        NotEnoughDiskSpace = 9,

        /// <summary>
        /// If the piece length was different from the one in the .aria2 control file.
        /// See --allow-piece-length-change option.
        /// </summary>
        PieceLengthMismatch = 10,

        /// <summary>
        /// If aria2 was downloading the same file at that moment.
        /// </summary>
        DownloadingSameFile = 11,

        /// <summary>
        /// If aria2 was downloading the same info hash torrent at that moment.
        /// </summary>
        DownloadingSameTorrent = 12,

        /// <summary>
        /// If the file already existed.
        /// See --allow-overwrite option.
        /// </summary>
        FileAlreadyExists = 13,

        /// <summary>
        /// If renaming the file failed.
        /// See --auto-file-renaming option.
        /// </summary>
        FileRenameFailed = 14,

        /// <summary>
        /// If aria2 could not open an existing file.
        /// </summary>
        CannotOpenFile = 15,

        /// <summary>
        /// If aria2 could not create a new file or truncate an existing file.
        /// </summary>
        CannotCreateOrTruncateFile = 16,

        /// <summary>
        /// If a file I/O error occurred.
        /// </summary>
        FileIOError = 17,

        /// <summary>
        /// If aria2 could not create a directory.
        /// </summary>
        CannotCreateDirectory = 18,

        /// <summary>
        /// If name resolution failed.
        /// </summary>
        NameResolutionFailed = 19,

        /// <summary>
        /// If aria2 could not parse a Metalink document.
        /// </summary>
        MetalinkParseError = 20,

        /// <summary>
        /// If an FTP command failed.
        /// </summary>
        FTPCommandFailed = 21,

        /// <summary>
        /// If the HTTP response header was bad or unexpected.
        /// </summary>
        BadHttpResponseHeader = 22,

        /// <summary>
        /// If too many redirects occurred.
        /// </summary>
        TooManyRedirects = 23,

        /// <summary>
        /// If HTTP authorization failed.
        /// </summary>
        HttpAuthorizationFailed = 24,

        /// <summary>
        /// If aria2 could not parse a bencoded file (usually a ".torrent" file).
        /// </summary>
        BencodeParseError = 25,

        /// <summary>
        /// If the ".torrent" file was corrupted or missing information
        /// that aria2 needed.
        /// </summary>
        TorrentFileCorrupted = 26,

        /// <summary>
        /// If the Magnet URI was bad.
        /// </summary>
        BadMagnetUri = 27,

        /// <summary>
        /// If a bad or unrecognized option was given,
        /// or an unexpected option argument was provided.
        /// </summary>
        BadOrUnexpectedOption = 28,

        /// <summary>
        /// If the remote server was unable to handle the request
        /// due to temporary overloading or maintenance.
        /// </summary>
        RemoteServerOverloaded = 29,

        /// <summary>
        /// If aria2 could not parse a JSON-RPC request.
        /// </summary>
        JsonRpcParseError = 30,

        /// <summary>
        /// Reserved. Not used.
        /// </summary>
        Reserved = 31,

        /// <summary>
        /// If checksum validation failed.
        /// </summary>
        ChecksumValidationFailed = 32
    }
}
