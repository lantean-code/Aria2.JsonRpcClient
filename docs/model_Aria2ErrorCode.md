##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2ErrorCode Enum

## Overview

Represents the error codes returned by Aria2.

---

## Members
#### `Success`
If all downloads were successful.
#### `UnknownError`
If an unknown error occurred.
#### `Timeout`
If a timeout occurred.
#### `ResourceNotFound`
If a resource was not found.
#### `MaxFileNotFoundExceeded`
If Aria2 saw the specified number of "resource not found" errors.
See --max-file-not-found option.
#### `DownloadTooSlow`
If a download was aborted because the download speed was too slow.
See --lowest-speed-limit option.
#### `NetworkProblem`
If a network problem occurred.
#### `UnfinishedDownloads`
If there were unfinished downloads.
This error is only reported if all finished downloads were successful
and there were unfinished downloads in a queue when Aria2 exited
by pressing Ctrl-C or sending a TERM or INT signal.
#### `ResumeNotSupported`
If the remote server did not support resume when resume was required
to complete the download.
#### `NotEnoughDiskSpace`
If there was not enough disk space available.
#### `PieceLengthMismatch`
If the piece length was different from the one in the .aria2 control file.
See --allow-piece-length-change option.
#### `DownloadingSameFile`
If Aria2 was downloading the same file at that moment.
#### `DownloadingSameTorrent`
If Aria2 was downloading the same info hash torrent at that moment.
#### `FileAlreadyExists`
If the file already existed.
See --allow-overwrite option.
#### `FileRenameFailed`
If renaming the file failed.
See --auto-file-renaming option.
#### `CannotOpenFile`
If Aria2 could not open an existing file.
#### `CannotCreateOrTruncateFile`
If Aria2 could not create a new file or truncate an existing file.
#### `FileIOError`
If a file I/O error occurred.
#### `CannotCreateDirectory`
If Aria2 could not create a directory.
#### `NameResolutionFailed`
If name resolution failed.
#### `MetalinkParseError`
If Aria2 could not parse a Metalink document.
#### `FTPCommandFailed`
If an FTP command failed.
#### `BadHttpResponseHeader`
If the HTTP response header was bad or unexpected.
#### `TooManyRedirects`
If too many redirects occurred.
#### `HttpAuthorizationFailed`
If HTTP authorization failed.
#### `BencodeParseError`
If Aria2 could not parse a bencoded file (usually a ".torrent" file).
#### `TorrentFileCorrupted`
If the ".torrent" file was corrupted or missing information
that Aria2 needed.
#### `BadMagnetUri`
If the Magnet URI was bad.
#### `BadOrUnexpectedOption`
If a bad or unrecognized option was given,
or an unexpected option argument was provided.
#### `RemoteServerOverloaded`
If the remote server was unable to handle the request
due to temporary overloading or maintenance.
#### `JsonRpcParseError`
If Aria2 could not parse a JSON-RPC request.
#### `Reserved`
Reserved. Not used.
#### `ChecksumValidationFailed`
If checksum validation failed.



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
