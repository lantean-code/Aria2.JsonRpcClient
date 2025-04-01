using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents aria2 options for downloads.
    /// </summary>
    public record Aria2DownloadOptions
    {
        /// <summary>
        /// Use a proxy server for all protocols.  To override a previously
        /// defined proxy, use ''.
        /// You also can override this setting and specify a proxy server for a
        /// particular protocol using <see cref="HttpProxy"/>, <see cref="HttpsProxy"/> and <see cref="FtpProxy"/> options.
        /// This affects all downloads.
        /// The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy"/>
        [JsonPropertyName("all-proxy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AllProxy { get; set; }

        /// <summary>
        /// Set password for the all-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-passwd"/>
        [JsonPropertyName("all-proxy-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AllProxyPasswd { get; set; }

        /// <summary>
        /// Set user for the all-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-user"/>
        [JsonPropertyName("all-proxy-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AllProxyUser { get; set; }

        /// <summary>
        /// Restart download from scratch if the corresponding control file
        /// doesn't exist.  See also <see cref="AutoFileRenaming"/> option.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-overwrite"/>
        [JsonPropertyName("allow-overwrite"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowOverwrite { get; set; }

        /// <summary>
        /// If false is given, aria2 aborts download when a piece length is
        /// different from one in a control file.
        /// If true is given, you can proceed but some download progress will be lost.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-piece-length-change"/>
        [JsonPropertyName("allow-piece-length-change"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowPieceLengthChange { get; set; }

        /// <summary>
        /// Always resume download. If 'true' is given, aria2 always tries to resume
        /// download and if resume is not possible, aborts download.
        /// If 'false' is given, when all given URIs do not support resume or aria2
        /// encounters N URIs which do not support resume (N is the value specified using
        /// <see cref="MaxResumeFailureTries"/> option), aria2 downloads file from scratch.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-always-resume"/>
        [JsonPropertyName("always-resume"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AlwaysResume { get; set; }

        /// <summary>
        /// Enable asynchronous DNS.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-async-dns"/>
        [JsonPropertyName("async-dns"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AsyncDns { get; set; }

        /// <summary>
        /// Rename file name if the same file already exists.
        /// This option works only in HTTP(S)/FTP download.
        /// The new file name has a dot and a number (1..9999) appended after the name,
        /// but before the file extension, if any.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-auto-file-renaming"/>
        [JsonPropertyName("auto-file-renaming"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoFileRenaming { get; set; }

        /// <summary>
        /// Allow hook command invocation after hash check (see <see cref="CheckIntegrity"/> option)
        /// in BitTorrent download.
        /// By default, when hash check succeeds, the command given by
        /// <see href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-on-bt-download-complete">on-bt-download-complete</see>
        /// is executed.
        /// To disable this action, give 'false' to this option.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-hook-after-hash-check"/>
        [JsonPropertyName("bt-enable-hook-after-hash-check"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtEnableHookAfterHashCheck { get; set; }

        /// <summary>
        /// Enable Local Peer Discovery.
        /// If a private flag is set in a torrent, aria2 doesn't use this feature for that download even if 'true' is given.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-lpd"/>
        [JsonPropertyName("bt-enable-lpd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtEnableLpd { get; set; }

        /// <summary>
        /// Comma separated list of BitTorrent tracker's announce URI to remove.
        /// You can use special value '*' which matches all URIs, thus removes all announce URIs.
        /// When specifying '*' in shell command-line, don't forget to escape or quote it.
        /// See also the <see cref="BtTracker"/> option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-exclude-tracker"/>
        [JsonPropertyName("bt-exclude-tracker"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BtExcludeTracker { get; set; }

        /// <summary>
        /// Specify the external IP address to use in BitTorrent download and DHT.
        /// It may be sent to BitTorrent tracker.
        /// For DHT, this option should be set to report that local node is downloading a particular torrent.
        /// This is critical to use DHT in a private network.
        /// Although this function is named 'external', it can accept any kind of IP addresses.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-external-ip"/>
        [JsonPropertyName("bt-external-ip"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BtExternalIp { get; set; }

        /// <summary>
        /// Requires BitTorrent message payload encryption with arc4.
        /// This is a shorthand of 'bt-require-crypto' and 'bt-min-crypto-level=arc4'.
        /// This option does not change the option value of those options.
        /// If 'true' is given, deny legacy BitTorrent handshake and only use Obfuscation handshake and always encrypt message payload.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-force-encryption"/>
        [JsonPropertyName("bt-force-encryption"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtForceEncryption { get; set; }

        /// <summary>
        /// If 'true' is given, after hash check using <see cref="CheckIntegrity"/> option and file is complete,
        /// continue to seed file.
        /// If you want to check file and download it only when it is damaged or incomplete, set this option to 'false'.
        /// This option has effect only on BitTorrent download.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-hash-check-seed"/>
        [JsonPropertyName("bt-hash-check-seed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtHashCheckSeed { get; set; }

        /// <summary>
        /// Before getting torrent metadata from DHT when downloading with magnet link,
        /// first try to read file saved by <see cref="BtSaveMetadata"/> option.
        /// If it is successful, then skip downloading metadata from DHT.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-load-saved-metadata"/>
        [JsonPropertyName("bt-load-saved-metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtLoadSavedMetadata { get; set; }

        /// <summary>
        /// Specify the maximum number of peers per torrent.
        /// '0' means unlimited.
        /// Default: '55'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-max-peers"/>
        [JsonPropertyName("bt-max-peers"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtMaxPeers { get; set; }

        /// <summary>
        /// Download metadata only. The file(s) described in metadata will not be downloaded.
        /// This option has effect only when BitTorrent Magnet URI is used.
        /// See also the <see cref="BtSaveMetadata"/> option.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-metadata-only"/>
        [JsonPropertyName("bt-metadata-only"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtMetadataOnly { get; set; }

        /// <summary>
        /// Set minimum level of encryption method.
        /// If several encryption methods are provided by a peer, aria2 chooses the lowest one which satisfies the given level.
        /// Default: <see cref="BtMinCryptoLevelOptions.Plain"/>.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-min-crypto-level"/>
        [JsonPropertyName("bt-min-crypto-level"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BtMinCryptoLevelOptions? BtMinCryptoLevel { get; set; }

        /// <summary>
        /// Try to download first and last pieces of each file first.
        /// This is useful for previewing files.
        /// The argument can contain two keywords: 'head' and 'tail'.
        /// To include both keywords, they must be separated by a comma.
        /// These keywords can take one parameter, SIZE.
        /// For example, if 'head=SIZE' is specified, pieces in the range of first SIZE bytes
        /// of each file get higher priority.
        /// 'tail=SIZE' means the range of last SIZE bytes of each file.
        /// SIZE can include 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// If SIZE is omitted, SIZE = 1M is used.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-prioritize-piece"/>
        [JsonPropertyName("bt-prioritize-piece"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BtPrioritizePiece { get; set; }

        /// <summary>
        /// Removes the unselected files when download is completed in BitTorrent.
        /// To select files, use the <see cref="SelectFile"/> option.
        /// If not used, all files are assumed to be selected.
        /// Please use this option with care because it will actually remove files from your disk.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-remove-unselected-file"/>
        [JsonPropertyName("bt-remove-unselected-file"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtRemoveUnselectedFile { get; set; }

        /// <summary>
        /// If the whole download speed of every torrent is lower than SPEED,
        /// aria2 temporarily increases the number of peers to try for more download speed.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// Default: '50K'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-request-peer-speed-limit"/>
        [JsonPropertyName("bt-request-peer-speed-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? BtRequestPeerSpeedLimit { get; set; }

        /// <summary>
        /// If 'true' is given, aria2 doesn't accept and establish connection with legacy BitTorrent handshake (the '19BitTorrent protocol').
        /// Thus aria2 always uses Obfuscation handshake.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-require-crypto"/>
        [JsonPropertyName("bt-require-crypto"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtRequireCrypto { get; set; }

        /// <summary>
        /// Save metadata as '.torrent' file.
        /// This option has effect only when BitTorrent Magnet URI is used.
        /// The file name is hex encoded info hash with suffix '.torrent'.
        /// The directory to be saved is the same as the download directory.
        /// If the same file already exists, metadata is not saved.
        /// See also the <see cref="BtMetadataOnly"/> option.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-save-metadata"/>
        [JsonPropertyName("bt-save-metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtSaveMetadata { get; set; }

        /// <summary>
        /// Seed previously downloaded files without verifying piece hashes.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-seed-unverified"/>
        [JsonPropertyName("bt-seed-unverified"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtSeedUnverified { get; set; }

        /// <summary>
        /// Stop BitTorrent download if download speed is 0 in consecutive SEC seconds.
        /// If '0' is given, this feature is disabled.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-stop-timeout"/>
        [JsonPropertyName("bt-stop-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtStopTimeout { get; set; }

        /// <summary>
        /// Comma separated list of additional BitTorrent tracker's announce URI.
        /// These URIs are not affected by the URIs removed by the <see cref="BtExcludeTracker"/> option because they are added after those are removed.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker"/>
        [JsonPropertyName("bt-tracker"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BtTracker { get; set; }

        /// <summary>
        /// Set the connect timeout (in seconds) to establish connection to tracker.
        /// After connection is established, this option makes no effect and 'bt-tracker-timeout' is used instead.
        /// Default: '60'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-connect-timeout"/>
        [JsonPropertyName("bt-tracker-connect-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtTrackerConnectTimeout { get; set; }

        /// <summary>
        /// Set the interval (in seconds) between tracker requests.
        /// This completely overrides the interval value and aria2 just uses this value.
        /// If '0' is set, aria2 determines the interval based on tracker response and download progress.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-interval"/>
        [JsonPropertyName("bt-tracker-interval"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtTrackerInterval { get; set; }

        /// <summary>
        /// Set timeout (in seconds) for tracker requests.
        /// Default: '60'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-timeout"/>
        [JsonPropertyName("bt-tracker-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtTrackerTimeout { get; set; }

        /// <summary>
        /// Check file integrity by validating piece hashes or a hash of entire file.
        /// This option has effect only in BitTorrent, Metalink downloads with checksums or HTTP(S)/FTP downloads with the <see cref="Checksum"/> option.
        /// If piece hashes are provided, this option can detect damaged portions of a file and re-download them.
        /// If a hash of the entire file is provided, hash check is done only when file has already been downloaded,
        /// determined by file length. If hash check fails, file is re-downloaded from scratch.
        /// If both are provided, only piece hashes are used.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-check-integrity"/>
        [JsonPropertyName("check-integrity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CheckIntegrity { get; set; }

        /// <summary>
        /// Set checksum.
        /// TYPE is hash type (as listed in the 'Hash Algorithms' in 'aria2c -v')
        /// and DIGEST is hex digest.
        /// For example, setting sha-1 digest looks like:
        /// 'sha-1=0192ba11326fe2298c8cb4de616f4d4140213838'
        /// This option applies only to HTTP(S)/FTP downloads.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-checksum"/>
        [JsonPropertyName("checksum"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Checksum { get; set; }

        /// <summary>
        /// Download file only when the local file is older than remote file.
        /// This function works only with HTTP(S) downloads.
        /// It does not work if file size is specified in Metalink.
        /// It also ignores Content-Disposition header.
        /// If a control file exists, this option will be ignored.
        /// This function uses If-Modified-Since header to conditionally download only newer files.
        /// When getting modification time of local file, it uses the user supplied file name (see <see cref="Out"/> option)
        /// or the file name part in URI if 'out' is not specified.
        /// To overwrite an existing file, 'allow-overwrite' is required.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-conditional-get"/>
        [JsonPropertyName("conditional-get"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ConditionalGet { get; set; }

        /// <summary>
        /// Set the connect timeout (in seconds) to establish connection to HTTP/FTP/proxy server.
        /// After the connection is established, this option has no effect and 'timeout' is used instead.
        /// Default: '60'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-connect-timeout"/>
        [JsonPropertyName("connect-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ConnectTimeout { get; set; }

        /// <summary>
        /// Handle quoted string in Content-Disposition header as UTF-8 instead of ISO-8859-1,
        /// for example, the filename parameter, but not the extended version filename*.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-content-disposition-default-utf8"/>
        [JsonPropertyName("content-disposition-default-utf8"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ContentDispositionDefaultUtf8 { get; set; }

        /// <summary>
        /// Continue downloading a partially downloaded file.
        /// Use this option to resume a download started by a web browser or another program which downloads files sequentially from the beginning.
        /// Currently, this option is only applicable to HTTP(S)/FTP downloads.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-continue"/>
        [JsonPropertyName("continue"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? @Continue { get; set; }

        /// <summary>
        /// The directory to store the downloaded file.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dir"/>
        [JsonPropertyName("dir"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Dir { get; set; }

        /// <summary>
        /// If 'true' is given, aria2 just checks whether the remote file is
        /// available and doesn't download data.
        /// This option has effect on HTTP/FTP download.
        /// BitTorrent downloads are canceled if 'true' is specified.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dry-run"/>
        [JsonPropertyName("dry-run"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DryRun { get; set; }

        /// <summary>
        /// Enable HTTP/1.1 persistent connection.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-keep-alive"/>
        [JsonPropertyName("enable-http-keep-alive"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableHttpKeepAlive { get; set; }

        /// <summary>
        /// Enable HTTP/1.1 pipelining.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-pipelining"/>
        [JsonPropertyName("enable-http-pipelining"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableHttpPipelining { get; set; }

        /// <summary>
        /// Map files into memory. This option may not work if the file space is not pre-allocated.
        /// See the <see cref="FileAllocation"/> option.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-mmap"/>
        [JsonPropertyName("enable-mmap"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableMmap { get; set; }

        /// <summary>
        /// Enable Peer Exchange extension.
        /// If a private flag is set in a torrent, this feature is disabled for that download even if 'true' is given.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-peer-exchange"/>
        [JsonPropertyName("enable-peer-exchange"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnablePeerExchange { get; set; }

        /// <summary>
        /// Specify file allocation method.
        /// 'none' doesn't pre-allocate file space.
        /// 'prealloc' pre-allocates file space before download begins.
        /// 'trunc' truncates a file to a specified length using ftruncate or equivalent.
        /// 'falloc' pre-allocates file space using posix_fallocate if available.
        /// Possible values: 'none', 'prealloc', 'trunc', 'falloc'.
        /// Default: 'prealloc'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-file-allocation"/>
        [JsonPropertyName("file-allocation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FileAllocationOptions? FileAllocation { get; set; }

        /// <summary>
        /// If 'true' or 'mem' is specified, when a file whose suffix is '.meta4' or '.metalink'
        /// or content type is 'application/metalink4+xml' or 'application/metalink+xml' is downloaded,
        /// aria2 parses it as a metalink file and downloads the files described in it.
        /// If 'mem' is specified, a metalink file is not written to disk, but is kept in memory.
        /// If 'false' is specified, the metalink file is downloaded to disk but not parsed.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-metalink"/>
        [JsonPropertyName("follow-metalink"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FollowMetalinkOptions? FollowMetalink { get; set; }

        /// <summary>
        /// If 'true' is specified, when a file whose suffix is '.torrent' or content type is 'application/x-bittorrent'
        /// is downloaded, aria2 parses it as a torrent file and downloads the files described in it.
        /// If 'false' is specified, the torrent file is downloaded to disk but not parsed.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-torrent"/>
        [JsonPropertyName("follow-torrent"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FollowTorrent { get; set; }

        /// <summary>
        /// Force saving the download with
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-session"/>
        /// even if completed or removed.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-force-save"/>
        [JsonPropertyName("force-save"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ForceSave { get; set; }

        /// <summary>
        /// Set FTP password. This affects all URIs.
        /// If the user name is embedded in the URI but the password is missing,
        /// aria2 tries to resolve the password using .netrc.
        /// If found, that password is used; otherwise, the password specified here is used.
        /// Default: 'ARIA2USER@'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-passwd"/>
        [JsonPropertyName("ftp-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FtpPasswd { get; set; }

        /// <summary>
        /// Use the passive mode in FTP.
        /// If 'false' is given, active mode will be used.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-pasv"/>
        [JsonPropertyName("ftp-pasv"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FtpPasv { get; set; }

        /// <summary>
        /// Use a proxy server for FTP.
        /// To override a previously defined proxy, use ''.
        /// See also the <see cref="AllProxy"/> option.
        /// The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy"/>
        [JsonPropertyName("ftp-proxy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FtpProxy { get; set; }

        /// <summary>
        /// Set password for the <see cref="FtpProxy"/> option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-passwd"/>
        [JsonPropertyName("ftp-proxy-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FtpProxyPasswd { get; set; }

        /// <summary>
        /// Set user for the <see cref="FtpProxy"/> option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-user"/>
        [JsonPropertyName("ftp-proxy-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FtpProxyUser { get; set; }

        /// <summary>
        /// Reuse FTP connection.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-reuse-connection"/>
        [JsonPropertyName("ftp-reuse-connection"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FtpReuseConnection { get; set; }

        /// <summary>
        /// Set FTP transfer type.
        /// TYPE is either 'binary' or 'ascii'.
        /// Default: 'binary'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-type"/>
        [JsonPropertyName("ftp-type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FtpTypeOptions? FtpType { get; set; }

        /// <summary>
        /// Set FTP user. This affects all URIs.
        /// Default: 'anonymous'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-user"/>
        [JsonPropertyName("ftp-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FtpUser { get; set; }

        /// <summary>
        /// Set GID manually.
        /// The GID must be a 16-character hex string (only 0-9, a-f, A-F allowed, with no leading zeros stripped).
        /// The all-zero GID is reserved and must not be used.
        /// The GID must be unique; otherwise an error is reported and the download is not added.
        /// This option is useful when restoring sessions saved using
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-session"/>
        /// option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-gid"/>
        [JsonPropertyName("gid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Gid { get; set; }

        /// <summary>
        /// If 'true' is given, after hash check using <see cref="CheckIntegrity"/> option,
        /// abort download whether or not download is complete.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-hash-check-only"/>
        [JsonPropertyName("hash-check-only"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HashCheckOnly { get; set; }

        /// <summary>
        /// Append HEADER to HTTP request header.
        /// This option can be used repeatedly to specify more than one header.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-header"/>
        [JsonPropertyName("header"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Header { get; set; }

        /// <summary>
        /// Send 'Accept-Encoding: deflate, gzip' request header and inflate response if remote server responds with
        /// 'Content-Encoding: gzip' or 'Content-Encoding: deflate'.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-accept-gzip"/>
        [JsonPropertyName("http-accept-gzip"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HttpAcceptGzip { get; set; }

        /// <summary>
        /// Send HTTP authorization header only when it is requested by the server.
        /// If 'false' is set, then the authorization header is always sent.
        /// Exception: if user name and password are embedded in URI, the header is always sent.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-auth-challenge"/>
        [JsonPropertyName("http-auth-challenge"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HttpAuthChallenge { get; set; }

        /// <summary>
        /// Send 'Cache-Control: no-cache' and 'Pragma: no-cache' headers to avoid cached content.
        /// If 'false' is given, these headers are not sent and you can add a Cache-Control header with your directive.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-no-cache"/>
        [JsonPropertyName("http-no-cache"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HttpNoCache { get; set; }

        /// <summary>
        /// Set HTTP password. This affects all URIs.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-passwd"/>
        [JsonPropertyName("http-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpPasswd { get; set; }

        /// <summary>
        /// Use a proxy server for HTTP.
        /// To override a previously defined proxy, use ''.
        /// See also the <see cref="AllProxy" /> option.
        /// The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy"/>
        [JsonPropertyName("http-proxy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpProxy { get; set; }

        /// <summary>
        /// Set password for the http-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-passwd"/>
        [JsonPropertyName("http-proxy-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpProxyPasswd { get; set; }

        /// <summary>
        /// Set user for the http-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-user"/>
        [JsonPropertyName("http-proxy-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpProxyUser { get; set; }

        /// <summary>
        /// Set HTTP user. This affects all URIs.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-user"/>
        [JsonPropertyName("http-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpUser { get; set; }

        /// <summary>
        /// Use a proxy server for HTTPS.
        /// To override a previously defined proxy, use ''.
        /// See also the <see cref="AllProxy" /> option.
        /// The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy"/>
        [JsonPropertyName("https-proxy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpsProxy { get; set; }

        /// <summary>
        /// Set password for the https-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-passwd"/>
        [JsonPropertyName("https-proxy-passwd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpsProxyPasswd { get; set; }

        /// <summary>
        /// Set user for the https-proxy option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-user"/>
        [JsonPropertyName("https-proxy-user"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HttpsProxyUser { get; set; }

        /// <summary>
        /// Set file path for file with index=INDEX.
        /// You can find the file index using the <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-show-files"/> option.
        /// PATH is a relative path to the directory specified in the <see cref="Dir"/> option.
        /// This option can be specified multiple times.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-index-out"/>
        [JsonPropertyName("index-out"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IndexOut { get; set; }

        /// <summary>
        /// Close connection if download speed (in bytes per sec) is lower than or equal to this value.
        /// '0' means aria2 does not have a lowest speed limit.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// This option does not affect BitTorrent downloads.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-lowest-speed-limit"/>
        [JsonPropertyName("lowest-speed-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? LowestSpeedLimit { get; set; }

        /// <summary>
        /// The maximum number of connections to one server for each download.
        /// Default: '1'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-connection-per-server"/>
        [JsonPropertyName("max-connection-per-server"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxConnectionPerServer { get; set; }

        /// <summary>
        /// Set maximum download speed per each download in bytes per sec.
        /// '0' means unrestricted.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-download-limit"/>
        [JsonPropertyName("max-download-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? MaxDownloadLimit { get; set; }

        /// <summary>
        /// If aria2 receives 'file not found' status from the remote server NUM times without
        /// getting a single byte, then force the download to fail.
        /// Specify '0' to disable this option.
        /// This option is effective only for HTTP/FTP servers.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-file-not-found"/>
        [JsonPropertyName("max-file-not-found"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxFileNotFound { get; set; }

        /// <summary>
        /// Set the maximum file size to enable mmap.
        /// The file size is determined by the sum of all files in one download.
        /// If the file size exceeds this value, mmap will be disabled.
        /// Default: '9223372036854775807'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-mmap-limit"/>
        [JsonPropertyName("max-mmap-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? MaxMmapLimit { get; set; }

        /// <summary>
        /// When used with 'always-resume=false', aria2 downloads file from scratch when
        /// it detects N number of URIs that do not support resume.
        /// If N is '0', aria2 downloads file from scratch when all given URIs do not support resume.
        /// See the <see cref="AlwaysResume"/> option.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-resume-failure-tries"/>
        [JsonPropertyName("max-resume-failure-tries"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxResumeFailureTries { get; set; }

        /// <summary>
        /// Set number of tries. '0' means unlimited.
        /// See also the <see cref="RetryWait"/> option.
        /// Default: '5'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-tries"/>
        [JsonPropertyName("max-tries"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxTries { get; set; }

        /// <summary>
        /// Set maximum upload speed per each torrent in bytes per sec.
        /// '0' means unrestricted.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// To limit overall upload speed, use the <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-overall-upload-limit"/> option.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-upload-limit"/>
        [JsonPropertyName("max-upload-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? MaxUploadLimit { get; set; }

        /// <summary>
        /// Specify base URI to resolve relative URI in metalink:url and metalink:metaurl element
        /// in a metalink file stored in local disk.
        /// If URI points to a directory, URI must end with '/'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-base-uri"/>
        [JsonPropertyName("metalink-base-uri"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MetalinkBaseUri { get; set; }

        /// <summary>
        /// If 'true' is given and several protocols are available for a mirror in a metalink file,
        /// aria2 uses one of them.
        /// Use with the <see cref="MetalinkPreferredProtocol"/> option.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-enable-unique-protocol"/>
        [JsonPropertyName("metalink-enable-unique-protocol"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MetalinkEnableUniqueProtocol { get; set; }

        /// <summary>
        /// Specify the language of the file to download.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-language"/>
        [JsonPropertyName("metalink-language"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MetalinkLanguage { get; set; }

        /// <summary>
        /// Specify the location of the preferred server.
        /// A comma-delimited list of locations is acceptable, for example: 'jp,us'.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-location"/>
        [JsonPropertyName("metalink-location"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MetalinkLocation { get; set; }

        /// <summary>
        /// Specify the operating system of the file to download.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-os"/>
        [JsonPropertyName("metalink-os"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MetalinkOs { get; set; }

        /// <summary>
        /// Specify preferred protocol.
        /// Possible values: 'http', 'https', 'ftp' and 'none'.
        /// Specify 'none' to disable this feature.
        /// Default: 'none'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-preferred-protocol"/>
        [JsonPropertyName("metalink-preferred-protocol"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MetalinkPreferredProtocolOptions? MetalinkPreferredProtocol { get; set; }

        /// <summary>
        /// Specify the version of the file to download.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-version"/>
        [JsonPropertyName("metalink-version"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MetalinkVersion { get; set; }

        /// <summary>
        /// aria2 does not split file ranges smaller than twice this value.
        /// For example, consider downloading a 20MiB file.
        /// If SIZE is 10M, aria2 splits the file into 2 ranges; if SIZE is 15M, no split occurs.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// Possible values: from '1M' to '1024M'.
        /// Default: '20M'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-min-split-size"/>
        [JsonPropertyName("min-split-size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? MinSplitSize { get; set; }

        /// <summary>
        /// No file allocation is made for files whose size is smaller than this value.
        /// You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
        /// Default: '5M'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-file-allocation-limit"/>
        [JsonPropertyName("no-file-allocation-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? NoFileAllocationLimit { get; set; }

        /// <summary>
        /// Disables netrc support.
        /// Netrc support is enabled by default.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-netrc"/>
        [JsonPropertyName("no-netrc"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NoNetrc { get; set; }

        /// <summary>
        /// Specify a comma separated list of host names, domains and network addresses
        /// with or without a subnet mask where no proxy should be used.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-proxy"/>
        [JsonPropertyName("no-proxy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NoProxy { get; set; }

        /// <summary>
        /// The file name of the downloaded file.
        /// It is always relative to the directory given in the <see cref="Dir"/> option.
        /// When the 'force-sequential' (-Z) option is used, this option is ignored.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-out"/>
        [JsonPropertyName("out"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Out { get; set; }

        /// <summary>
        /// Enable parameterized URI support.
        /// You can specify a set of parts (e.g. 'http://{sv1,sv2,sv3}/foo.iso') or numeric sequences with a step counter
        /// (e.g. 'http://host/image[000-100:2].img').
        /// If all URIs do not point to the same file, the -Z option is required.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-parameterized-uri"/>
        [JsonPropertyName("parameterized-uri"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ParameterizedUri { get; set; }

        /// <summary>
        /// Pause download after added.
        /// This option is effective only when 'enable-rpc' is given.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause"/>
        [JsonPropertyName("pause"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pause { get; set; }

        /// <summary>
        /// Pause downloads created as a result of metadata download.
        /// There are 3 types of metadata downloads.
        /// These subsequent downloads will be paused.
        /// This option is effective only when 'enable-rpc' is given.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause-metadata"/>
        [JsonPropertyName("pause-metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PauseMetadata { get; set; }

        /// <summary>
        /// Set a piece length for HTTP/FTP downloads.
        /// This is the boundary when aria2 splits a file.
        /// All splits occur at multiples of this length.
        /// This option will be ignored in BitTorrent downloads and also ignored if a Metalink file contains piece hashes.
        /// Default: '1M'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-piece-length"/>
        [JsonPropertyName("piece-length"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Size? PieceLength { get; set; }

        /// <summary>
        /// Set the method to use in proxy request.
        /// METHOD is either 'get' or 'tunnel'.
        /// HTTPS downloads always use 'tunnel' regardless of this option.
        /// Default: 'get'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-proxy-method"/>
        [JsonPropertyName("proxy-method"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProxyMethodOptions? ProxyMethod { get; set; }

        /// <summary>
        /// Validate chunk of data by calculating checksum while downloading a file if chunk checksums are provided.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-realtime-chunk-checksum"/>
        [JsonPropertyName("realtime-chunk-checksum"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RealtimeChunkChecksum { get; set; }

        /// <summary>
        /// Set an http referrer (Referer).
        /// This affects all http/https downloads.
        /// If '*' is given, the download URI is also used as the referrer.
        /// This may be useful when used together with the <see cref="ParameterizedUri"/> option.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-referer"/>
        [JsonPropertyName("referer"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Referer { get; set; }

        /// <summary>
        /// Retrieve timestamp of the remote file from the remote HTTP/FTP server and if available, apply it to the local file.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remote-time"/>
        [JsonPropertyName("remote-time"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RemoteTime { get; set; }

        /// <summary>
        /// Remove control file before download.
        /// When used with 'allow-overwrite' set to true, download always starts from scratch.
        /// This is useful for users behind proxy servers which disable resume.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remove-control-file"/>
        [JsonPropertyName("remove-control-file"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RemoveControlFile { get; set; }

        /// <summary>
        /// Set the seconds to wait between retries.
        /// When SEC > 0, aria2 will retry downloads when the HTTP server returns a 503 response.
        /// Default: '0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-retry-wait"/>
        [JsonPropertyName("retry-wait"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RetryWait { get; set; }

        /// <summary>
        /// Reuse already used URIs if no unused URIs are left.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-reuse-uri"/>
        [JsonPropertyName("reuse-uri"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReuseUri { get; set; }

        /// <summary>
        /// Save the uploaded torrent or metalink metadata in the directory specified by the <see cref="Dir"/> option.
        /// The file name consists of the SHA-1 hash hex string of metadata plus an extension.
        /// For torrent, the extension is '.torrent'. For metalink, it is '.meta4'.
        /// If 'false' is given, the downloads added by aria2.addTorrent or aria2.addMetalink will not be saved by
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-session"/>
        /// option.
        /// Default: 'true'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-save-upload-metadata"/>
        [JsonPropertyName("rpc-save-upload-metadata"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RpcSaveUploadMetadata { get; set; }

        /// <summary>
        /// Specify share ratio. Seed completed torrents until share ratio reaches
        /// RATIO.
        /// You are strongly encouraged to specify equals or more than '1.0' here.
        /// Specify '0.0' if you intend to do seeding regardless of share ratio.
        /// If <see cref="SeedTime"/> option is specified along with this option, seeding ends when
        /// at least one of the conditions is satisfied.
        /// Default: '1.0'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-ratio"/>
        [JsonPropertyName("seed-ratio"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SeedRatio { get; set; }

        /// <summary>
        /// Specify seeding time in (fractional) minutes. Also see the <see cref="SeedRatio"/> option.
        /// Note: Specifying '0' disables seeding after download completed.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-time"/>
        [JsonPropertyName("seed-time"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SeedTime { get; set; }

        /// <summary>
        /// Set file to download by specifying its index.
        /// You can find the file index using the <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-show-files"/> option.
        /// Multiple indexes can be specified by using commas (e.g. '3,6'), ranges (e.g. '1-5'),
        /// or a combination (e.g. '1-5,8,9').
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-select-file"/>
        [JsonPropertyName("select-file"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SelectFile { get; set; }

        /// <summary>
        /// Download a file using N connections.
        /// If more than N URIs are given, the first N are used and the remaining URIs are used for backup.
        /// If fewer than N URIs are given, those URIs are reused so that N connections total are made simultaneously.
        /// The number of connections to the same host is restricted by the <see cref="MaxConnectionPerServer"/> option.
        /// See also the <see cref="MinSplitSize"/> option.
        /// Default: '5'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-split"/>
        [JsonPropertyName("split"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Split { get; set; }

        /// <summary>
        /// Set checksum for SSH host public key.
        /// TYPE is hash type (supported types: 'sha-1' or 'md5') and DIGEST is hex digest.
        /// For example: 'sha-1=b030503d4de4539dc7885e6f0f5e256704edf4c3'.
        /// This option can be used to validate server's public key when SFTP is used.
        /// If not set, no validation takes place.
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ssh-host-key-md"/>
        [JsonPropertyName("ssh-host-key-md"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SshHostKeyMd { get; set; }

        /// <summary>
        /// Specify piece selection algorithm used in HTTP/FTP download.
        /// A piece is a fixed length segment which is downloaded in parallel in a segmented download.
        /// default:
        ///   Select a piece to reduce the number of connections established.
        ///   This is the reasonable default behavior.
        /// inorder:
        ///   Select a piece closest to the beginning of the file.
        ///   This is useful for previewing movies while downloading.
        ///   Note that 'enable-http-pipelining' may reduce reconnection overhead.
        ///   Also, <see cref="MinSplitSize"/> is honored.
        /// random:
        ///   Select a piece randomly.
        ///   Also honors the <see cref="MinSplitSize"/> option.
        /// geom:
        ///   Initially selects a piece close to the beginning, then exponentially increases the spacing between pieces.
        ///   This reduces the number of connections established while downloading the beginning part first.
        /// Default: 'default'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-stream-piece-selector"/>
        [JsonPropertyName("stream-piece-selector"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StreamPieceSelectorOptions? StreamPieceSelector { get; set; }

        /// <summary>
        /// Set timeout in seconds.
        /// Default: '60'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-timeout"/>
        [JsonPropertyName("timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Timeout { get; set; }

        /// <summary>
        /// Specify URI selection algorithm.
        /// The possible values are 'inorder', 'feedback' and 'adaptive'.
        /// If 'inorder' is given, URIs are tried in the order they appear.
        /// If 'feedback' is given, aria2 uses download speed observed in previous downloads to choose the fastest server.
        /// If 'adaptive' is given, it selects one of the best mirrors for the first and reserved connections,
        /// and for supplementary ones returns mirrors which have not been tested yet or need to be retested.
        /// Default: 'feedback'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-uri-selector"/>
        [JsonPropertyName("uri-selector"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UriSelectorOptions? UriSelector { get; set; }

        /// <summary>
        /// Use HEAD method for the first HTTP request.
        /// Default: 'false'
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-use-head"/>
        [JsonPropertyName("use-head"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UseHead { get; set; }

        /// <summary>
        /// Set user agent for HTTP(S) downloads.
        /// Default: 'aria2/$VERSION' (with $VERSION replaced by the package version).
        /// </summary>
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-user-agent"/>
        [JsonPropertyName("user-agent"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserAgent { get; set; }
    }
}
