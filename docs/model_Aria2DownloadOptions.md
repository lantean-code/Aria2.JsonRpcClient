##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2DownloadOptions Model 

---

## Overview

Represents aria2 options for downloads.

---

## Properties
<a id="AllProxy"></a>
#### `string` AllProxy 

Use a proxy server for all protocols.  To override a previously
defined proxy, use ''.
You also can override this setting and specify a proxy server for a
particular protocol using [HttpProxy](#HttpProxy), [HttpsProxy](#HttpsProxy) and [FtpProxy](#FtpProxy) options.
This affects all downloads.
The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy)  
> JSON key: `all-proxy`

<a id="AllProxyPasswd"></a>
#### `string` AllProxyPasswd 

Set password for the all-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-passwd)  
> JSON key: `all-proxy-passwd`

<a id="AllProxyUser"></a>
#### `string` AllProxyUser 

Set user for the all-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-all-proxy-user)  
> JSON key: `all-proxy-user`

<a id="AllowOverwrite"></a>
#### `bool` AllowOverwrite 

Restart download from scratch if the corresponding control file
doesn't exist.  See also [AutoFileRenaming](#AutoFileRenaming) option.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-overwrite](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-overwrite)  
> JSON key: `allow-overwrite`

<a id="AllowPieceLengthChange"></a>
#### `bool` AllowPieceLengthChange 

If false is given, aria2 aborts download when a piece length is
different from one in a control file.
If true is given, you can proceed but some download progress will be lost.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-piece-length-change](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-allow-piece-length-change)  
> JSON key: `allow-piece-length-change`

<a id="AlwaysResume"></a>
#### `bool` AlwaysResume 

Always resume download. If 'true' is given, aria2 always tries to resume
download and if resume is not possible, aborts download.
If 'false' is given, when all given URIs do not support resume or aria2
encounters N URIs which do not support resume (N is the value specified using[MaxResumeFailureTries](#MaxResumeFailureTries) option), aria2 downloads file from scratch.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-always-resume](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-always-resume)  
> JSON key: `always-resume`

<a id="AsyncDns"></a>
#### `bool` AsyncDns 

Enable asynchronous DNS.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-async-dns](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-async-dns)  
> JSON key: `async-dns`

<a id="AutoFileRenaming"></a>
#### `bool` AutoFileRenaming 

Rename file name if the same file already exists.
This option works only in HTTP(S)/FTP download.
The new file name has a dot and a number (1..9999) appended after the name,
but before the file extension, if any.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-auto-file-renaming](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-auto-file-renaming)  
> JSON key: `auto-file-renaming`

<a id="BtEnableHookAfterHashCheck"></a>
#### `bool` BtEnableHookAfterHashCheck 

Allow hook command invocation after hash check (see [CheckIntegrity](#CheckIntegrity) option)
in BitTorrent download.
By default, when hash check succeeds, the command given by[on-bt-download-complete](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-on-bt-download-complete) is executed.
To disable this action, give 'false' to this option.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-hook-after-hash-check](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-hook-after-hash-check)  
> JSON key: `bt-enable-hook-after-hash-check`

<a id="BtEnableLpd"></a>
#### `bool` BtEnableLpd 

Enable Local Peer Discovery.
If a private flag is set in a torrent, aria2 doesn't use this feature for that download even if 'true' is given.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-lpd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-enable-lpd)  
> JSON key: `bt-enable-lpd`

<a id="BtExcludeTracker"></a>
#### `string` BtExcludeTracker 

Comma separated list of BitTorrent tracker's announce URI to remove.
You can use special value '*' which matches all URIs, thus removes all announce URIs.
When specifying '*' in shell command-line, don't forget to escape or quote it.
See also the [BtTracker](#BtTracker) option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-exclude-tracker](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-exclude-tracker)  
> JSON key: `bt-exclude-tracker`

<a id="BtExternalIp"></a>
#### `string` BtExternalIp 

Specify the external IP address to use in BitTorrent download and DHT.
It may be sent to BitTorrent tracker.
For DHT, this option should be set to report that local node is downloading a particular torrent.
This is critical to use DHT in a private network.
Although this function is named 'external', it can accept any kind of IP addresses.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-external-ip](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-external-ip)  
> JSON key: `bt-external-ip`

<a id="BtForceEncryption"></a>
#### `bool` BtForceEncryption 

Requires BitTorrent message payload encryption with arc4.
This is a shorthand of 'bt-require-crypto' and 'bt-min-crypto-level=arc4'.
This option does not change the option value of those options.
If 'true' is given, deny legacy BitTorrent handshake and only use Obfuscation handshake and always encrypt message payload.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-force-encryption](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-force-encryption)  
> JSON key: `bt-force-encryption`

<a id="BtHashCheckSeed"></a>
#### `bool` BtHashCheckSeed 

If 'true' is given, after hash check using [CheckIntegrity](#CheckIntegrity) option and file is complete,
continue to seed file.
If you want to check file and download it only when it is damaged or incomplete, set this option to 'false'.
This option has effect only on BitTorrent download.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-hash-check-seed](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-hash-check-seed)  
> JSON key: `bt-hash-check-seed`

<a id="BtLoadSavedMetadata"></a>
#### `bool` BtLoadSavedMetadata 

Before getting torrent metadata from DHT when downloading with magnet link,
first try to read file saved by [BtSaveMetadata](#BtSaveMetadata) option.
If it is successful, then skip downloading metadata from DHT.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-load-saved-metadata](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-load-saved-metadata)  
> JSON key: `bt-load-saved-metadata`

<a id="BtMaxPeers"></a>
#### `int` BtMaxPeers 

Specify the maximum number of peers per torrent.
'0' means unlimited.
Default: '55'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-max-peers](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-max-peers)  
> JSON key: `bt-max-peers`

<a id="BtMetadataOnly"></a>
#### `bool` BtMetadataOnly 

Download metadata only. The file(s) described in metadata will not be downloaded.
This option has effect only when BitTorrent Magnet URI is used.
See also the [BtSaveMetadata](#BtSaveMetadata) option.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-metadata-only](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-metadata-only)  
> JSON key: `bt-metadata-only`

<a id="BtMinCryptoLevel"></a>
#### [`BtMinCryptoLevelOptions`](model_BtMinCryptoLevelOptions.md) BtMinCryptoLevel 

Set minimum level of encryption method.
If several encryption methods are provided by a peer, aria2 chooses the lowest one which satisfies the given level.
Default: [BtMinCryptoLevelOptions.Plain](model_Plain.md).

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-min-crypto-level](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-min-crypto-level)  
> JSON key: `bt-min-crypto-level`

<a id="BtPrioritizePiece"></a>
#### `string` BtPrioritizePiece 

Try to download first and last pieces of each file first.
This is useful for previewing files.
The argument can contain two keywords: 'head' and 'tail'.
To include both keywords, they must be separated by a comma.
These keywords can take one parameter, SIZE.
For example, if 'head=SIZE' is specified, pieces in the range of first SIZE bytes
of each file get higher priority.
'tail=SIZE' means the range of last SIZE bytes of each file.
SIZE can include 'K' or 'M' (1K = 1024, 1M = 1024K).
If SIZE is omitted, SIZE = 1M is used.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-prioritize-piece](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-prioritize-piece)  
> JSON key: `bt-prioritize-piece`

<a id="BtRemoveUnselectedFile"></a>
#### `bool` BtRemoveUnselectedFile 

Removes the unselected files when download is completed in BitTorrent.
To select files, use the [SelectFile](#SelectFile) option.
If not used, all files are assumed to be selected.
Please use this option with care because it will actually remove files from your disk.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-remove-unselected-file](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-remove-unselected-file)  
> JSON key: `bt-remove-unselected-file`

<a id="BtRequestPeerSpeedLimit"></a>
#### `Size` BtRequestPeerSpeedLimit 

If the whole download speed of every torrent is lower than SPEED,
aria2 temporarily increases the number of peers to try for more download speed.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
Default: '50K'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-request-peer-speed-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-request-peer-speed-limit)  
> JSON key: `bt-request-peer-speed-limit`

<a id="BtRequireCrypto"></a>
#### `bool` BtRequireCrypto 

If 'true' is given, aria2 doesn't accept and establish connection with legacy BitTorrent handshake (the '19BitTorrent protocol').
Thus aria2 always uses Obfuscation handshake.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-require-crypto](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-require-crypto)  
> JSON key: `bt-require-crypto`

<a id="BtSaveMetadata"></a>
#### `bool` BtSaveMetadata 

Save metadata as '.torrent' file.
This option has effect only when BitTorrent Magnet URI is used.
The file name is hex encoded info hash with suffix '.torrent'.
The directory to be saved is the same as the download directory.
If the same file already exists, metadata is not saved.
See also the [BtMetadataOnly](#BtMetadataOnly) option.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-save-metadata](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-save-metadata)  
> JSON key: `bt-save-metadata`

<a id="BtSeedUnverified"></a>
#### `bool` BtSeedUnverified 

Seed previously downloaded files without verifying piece hashes.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-seed-unverified](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-seed-unverified)  
> JSON key: `bt-seed-unverified`

<a id="BtStopTimeout"></a>
#### `int` BtStopTimeout 

Stop BitTorrent download if download speed is 0 in consecutive SEC seconds.
If '0' is given, this feature is disabled.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-stop-timeout](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-stop-timeout)  
> JSON key: `bt-stop-timeout`

<a id="BtTracker"></a>
#### `string` BtTracker 

Comma separated list of additional BitTorrent tracker's announce URI.
These URIs are not affected by the URIs removed by the [BtExcludeTracker](#BtExcludeTracker) option because they are added after those are removed.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker)  
> JSON key: `bt-tracker`

<a id="BtTrackerConnectTimeout"></a>
#### `int` BtTrackerConnectTimeout 

Set the connect timeout (in seconds) to establish connection to tracker.
After connection is established, this option makes no effect and 'bt-tracker-timeout' is used instead.
Default: '60'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-connect-timeout](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-connect-timeout)  
> JSON key: `bt-tracker-connect-timeout`

<a id="BtTrackerInterval"></a>
#### `int` BtTrackerInterval 

Set the interval (in seconds) between tracker requests.
This completely overrides the interval value and aria2 just uses this value.
If '0' is set, aria2 determines the interval based on tracker response and download progress.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-interval](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-interval)  
> JSON key: `bt-tracker-interval`

<a id="BtTrackerTimeout"></a>
#### `int` BtTrackerTimeout 

Set timeout (in seconds) for tracker requests.
Default: '60'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-timeout](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-tracker-timeout)  
> JSON key: `bt-tracker-timeout`

<a id="CheckIntegrity"></a>
#### `bool` CheckIntegrity 

Check file integrity by validating piece hashes or a hash of entire file.
This option has effect only in BitTorrent, Metalink downloads with checksums or HTTP(S)/FTP downloads with the [Checksum](#Checksum) option.
If piece hashes are provided, this option can detect damaged portions of a file and re-download them.
If a hash of the entire file is provided, hash check is done only when file has already been downloaded,
determined by file length. If hash check fails, file is re-downloaded from scratch.
If both are provided, only piece hashes are used.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-check-integrity](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-check-integrity)  
> JSON key: `check-integrity`

<a id="Checksum"></a>
#### `string` Checksum 

Set checksum.
TYPE is hash type (as listed in the 'Hash Algorithms' in 'aria2c -v')
and DIGEST is hex digest.
For example, setting sha-1 digest looks like:
'sha-1=0192ba11326fe2298c8cb4de616f4d4140213838'
This option applies only to HTTP(S)/FTP downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-checksum](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-checksum)  
> JSON key: `checksum`

<a id="ConditionalGet"></a>
#### `bool` ConditionalGet 

Download file only when the local file is older than remote file.
This function works only with HTTP(S) downloads.
It does not work if file size is specified in Metalink.
It also ignores Content-Disposition header.
If a control file exists, this option will be ignored.
This function uses If-Modified-Since header to conditionally download only newer files.
When getting modification time of local file, it uses the user supplied file name (see [Out](#Out) option)
or the file name part in URI if 'out' is not specified.
To overwrite an existing file, 'allow-overwrite' is required.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-conditional-get](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-conditional-get)  
> JSON key: `conditional-get`

<a id="ConnectTimeout"></a>
#### `int` ConnectTimeout 

Set the connect timeout (in seconds) to establish connection to HTTP/FTP/proxy server.
After the connection is established, this option has no effect and 'timeout' is used instead.
Default: '60'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-connect-timeout](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-connect-timeout)  
> JSON key: `connect-timeout`

<a id="ContentDispositionDefaultUtf8"></a>
#### `bool` ContentDispositionDefaultUtf8 

Handle quoted string in Content-Disposition header as UTF-8 instead of ISO-8859-1,
for example, the filename parameter, but not the extended version filename*.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-content-disposition-default-utf8](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-content-disposition-default-utf8)  
> JSON key: `content-disposition-default-utf8`

<a id="@Continue"></a>
#### `bool` @Continue 

Continue downloading a partially downloaded file.
Use this option to resume a download started by a web browser or another program which downloads files sequentially from the beginning.
Currently, this option is only applicable to HTTP(S)/FTP downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-continue](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-continue)  
> JSON key: `continue`

<a id="Dir"></a>
#### `string` Dir 

The directory to store the downloaded file.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dir](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dir)  
> JSON key: `dir`

<a id="DryRun"></a>
#### `bool` DryRun 

If 'true' is given, aria2 just checks whether the remote file is
available and doesn't download data.
This option has effect on HTTP/FTP download.
BitTorrent downloads are canceled if 'true' is specified.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dry-run](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dry-run)  
> JSON key: `dry-run`

<a id="EnableHttpKeepAlive"></a>
#### `bool` EnableHttpKeepAlive 

Enable HTTP/1.1 persistent connection.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-keep-alive](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-keep-alive)  
> JSON key: `enable-http-keep-alive`

<a id="EnableHttpPipelining"></a>
#### `bool` EnableHttpPipelining 

Enable HTTP/1.1 pipelining.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-pipelining](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-http-pipelining)  
> JSON key: `enable-http-pipelining`

<a id="EnableMmap"></a>
#### `bool` EnableMmap 

Map files into memory. This option may not work if the file space is not pre-allocated.
See the [FileAllocation](#FileAllocation) option.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-mmap](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-mmap)  
> JSON key: `enable-mmap`

<a id="EnablePeerExchange"></a>
#### `bool` EnablePeerExchange 

Enable Peer Exchange extension.
If a private flag is set in a torrent, this feature is disabled for that download even if 'true' is given.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-peer-exchange](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-peer-exchange)  
> JSON key: `enable-peer-exchange`

<a id="FileAllocation"></a>
#### [`FileAllocationOptions`](model_FileAllocationOptions.md) FileAllocation 

Specify file allocation method.
'none' doesn't pre-allocate file space.
'prealloc' pre-allocates file space before download begins.
'trunc' truncates a file to a specified length using ftruncate or equivalent.
'falloc' pre-allocates file space using posix_fallocate if available.
Possible values: 'none', 'prealloc', 'trunc', 'falloc'.
Default: 'prealloc'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-file-allocation](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-file-allocation)  
> JSON key: `file-allocation`

<a id="FollowMetalink"></a>
#### [`FollowMetalinkOptions`](model_FollowMetalinkOptions.md) FollowMetalink 

If 'true' or 'mem' is specified, when a file whose suffix is '.meta4' or '.metalink'
or content type is 'application/metalink4+xml' or 'application/metalink+xml' is downloaded,
aria2 parses it as a metalink file and downloads the files described in it.
If 'mem' is specified, a metalink file is not written to disk, but is kept in memory.
If 'false' is specified, the metalink file is downloaded to disk but not parsed.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-metalink](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-metalink)  
> JSON key: `follow-metalink`

<a id="FollowTorrent"></a>
#### `bool` FollowTorrent 

If 'true' is specified, when a file whose suffix is '.torrent' or content type is 'application/x-bittorrent'
is downloaded, aria2 parses it as a torrent file and downloads the files described in it.
If 'false' is specified, the torrent file is downloaded to disk but not parsed.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-torrent](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-follow-torrent)  
> JSON key: `follow-torrent`

<a id="ForceSave"></a>
#### `bool` ForceSave 

Force saving the download with even if completed or removed.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-force-save](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-force-save)  
> JSON key: `force-save`

<a id="FtpPasswd"></a>
#### `string` FtpPasswd 

Set FTP password. This affects all URIs.
If the user name is embedded in the URI but the password is missing,
aria2 tries to resolve the password using .netrc.
If found, that password is used; otherwise, the password specified here is used.
Default: 'ARIA2USER@'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-passwd)  
> JSON key: `ftp-passwd`

<a id="FtpPasv"></a>
#### `bool` FtpPasv 

Use the passive mode in FTP.
If 'false' is given, active mode will be used.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-pasv](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-pasv)  
> JSON key: `ftp-pasv`

<a id="FtpProxy"></a>
#### `string` FtpProxy 

Use a proxy server for FTP.
To override a previously defined proxy, use ''.
See also the [AllProxy](#AllProxy) option.
The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy)  
> JSON key: `ftp-proxy`

<a id="FtpProxyPasswd"></a>
#### `string` FtpProxyPasswd 

Set password for the [FtpProxy](#FtpProxy) option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-passwd)  
> JSON key: `ftp-proxy-passwd`

<a id="FtpProxyUser"></a>
#### `string` FtpProxyUser 

Set user for the [FtpProxy](#FtpProxy) option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-proxy-user)  
> JSON key: `ftp-proxy-user`

<a id="FtpReuseConnection"></a>
#### `bool` FtpReuseConnection 

Reuse FTP connection.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-reuse-connection](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-reuse-connection)  
> JSON key: `ftp-reuse-connection`

<a id="FtpType"></a>
#### [`FtpTypeOptions`](model_FtpTypeOptions.md) FtpType 

Set FTP transfer type.
TYPE is either 'binary' or 'ascii'.
Default: 'binary'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-type](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-type)  
> JSON key: `ftp-type`

<a id="FtpUser"></a>
#### `string` FtpUser 

Set FTP user. This affects all URIs.
Default: 'anonymous'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ftp-user)  
> JSON key: `ftp-user`

<a id="Gid"></a>
#### `string` Gid 

Set GID manually.
The GID must be a 16-character hex string (only 0-9, a-f, A-F allowed, with no leading zeros stripped).
The all-zero GID is reserved and must not be used.
The GID must be unique; otherwise an error is reported and the download is not added.
This option is useful when restoring sessions saved using option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-gid](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-gid)  
> JSON key: `gid`

<a id="HashCheckOnly"></a>
#### `bool` HashCheckOnly 

If 'true' is given, after hash check using [CheckIntegrity](#CheckIntegrity) option,
abort download whether or not download is complete.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-hash-check-only](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-hash-check-only)  
> JSON key: `hash-check-only`

<a id="Header"></a>
#### `string` Header 

Append HEADER to HTTP request header.
This option can be used repeatedly to specify more than one header.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-header](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-header)  
> JSON key: `header`

<a id="HttpAcceptGzip"></a>
#### `bool` HttpAcceptGzip 

Send 'Accept-Encoding: deflate, gzip' request header and inflate response if remote server responds with
'Content-Encoding: gzip' or 'Content-Encoding: deflate'.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-accept-gzip](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-accept-gzip)  
> JSON key: `http-accept-gzip`

<a id="HttpAuthChallenge"></a>
#### `bool` HttpAuthChallenge 

Send HTTP authorization header only when it is requested by the server.
If 'false' is set, then the authorization header is always sent.
Exception: if user name and password are embedded in URI, the header is always sent.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-auth-challenge](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-auth-challenge)  
> JSON key: `http-auth-challenge`

<a id="HttpNoCache"></a>
#### `bool` HttpNoCache 

Send 'Cache-Control: no-cache' and 'Pragma: no-cache' headers to avoid cached content.
If 'false' is given, these headers are not sent and you can add a Cache-Control header with your directive.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-no-cache](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-no-cache)  
> JSON key: `http-no-cache`

<a id="HttpPasswd"></a>
#### `string` HttpPasswd 

Set HTTP password. This affects all URIs.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-passwd)  
> JSON key: `http-passwd`

<a id="HttpProxy"></a>
#### `string` HttpProxy 

Use a proxy server for HTTP.
To override a previously defined proxy, use ''.
See also the [AllProxy](#AllProxy) option.
The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy)  
> JSON key: `http-proxy`

<a id="HttpProxyPasswd"></a>
#### `string` HttpProxyPasswd 

Set password for the http-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-passwd)  
> JSON key: `http-proxy-passwd`

<a id="HttpProxyUser"></a>
#### `string` HttpProxyUser 

Set user for the http-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-proxy-user)  
> JSON key: `http-proxy-user`

<a id="HttpUser"></a>
#### `string` HttpUser 

Set HTTP user. This affects all URIs.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-http-user)  
> JSON key: `http-user`

<a id="HttpsProxy"></a>
#### `string` HttpsProxy 

Use a proxy server for HTTPS.
To override a previously defined proxy, use ''.
See also the [AllProxy](#AllProxy) option.
The format of PROXY is '[http://][USER:PASSWORD@]HOST[:PORT]'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy)  
> JSON key: `https-proxy`

<a id="HttpsProxyPasswd"></a>
#### `string` HttpsProxyPasswd 

Set password for the https-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-passwd](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-passwd)  
> JSON key: `https-proxy-passwd`

<a id="HttpsProxyUser"></a>
#### `string` HttpsProxyUser 

Set user for the https-proxy option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-user](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-https-proxy-user)  
> JSON key: `https-proxy-user`

<a id="IndexOut"></a>
#### `string` IndexOut 

Set file path for file with index=INDEX.
You can find the file index using the  option.
PATH is a relative path to the directory specified in the [Dir](#Dir) option.
This option can be specified multiple times.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-index-out](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-index-out)  
> JSON key: `index-out`

<a id="LowestSpeedLimit"></a>
#### `Size` LowestSpeedLimit 

Close connection if download speed (in bytes per sec) is lower than or equal to this value.
'0' means aria2 does not have a lowest speed limit.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
This option does not affect BitTorrent downloads.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-lowest-speed-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-lowest-speed-limit)  
> JSON key: `lowest-speed-limit`

<a id="MaxConnectionPerServer"></a>
#### `int` MaxConnectionPerServer 

The maximum number of connections to one server for each download.
Default: '1'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-connection-per-server](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-connection-per-server)  
> JSON key: `max-connection-per-server`

<a id="MaxDownloadLimit"></a>
#### `Size` MaxDownloadLimit 

Set maximum download speed per each download in bytes per sec.
'0' means unrestricted.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-download-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-download-limit)  
> JSON key: `max-download-limit`

<a id="MaxFileNotFound"></a>
#### `int` MaxFileNotFound 

If aria2 receives 'file not found' status from the remote server NUM times without
getting a single byte, then force the download to fail.
Specify '0' to disable this option.
This option is effective only for HTTP/FTP servers.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-file-not-found](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-file-not-found)  
> JSON key: `max-file-not-found`

<a id="MaxMmapLimit"></a>
#### `Size` MaxMmapLimit 

Set the maximum file size to enable mmap.
The file size is determined by the sum of all files in one download.
If the file size exceeds this value, mmap will be disabled.
Default: '9223372036854775807'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-mmap-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-mmap-limit)  
> JSON key: `max-mmap-limit`

<a id="MaxResumeFailureTries"></a>
#### `int` MaxResumeFailureTries 

When used with 'always-resume=false', aria2 downloads file from scratch when
it detects N number of URIs that do not support resume.
If N is '0', aria2 downloads file from scratch when all given URIs do not support resume.
See the [AlwaysResume](#AlwaysResume) option.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-resume-failure-tries](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-resume-failure-tries)  
> JSON key: `max-resume-failure-tries`

<a id="MaxTries"></a>
#### `int` MaxTries 

Set number of tries. '0' means unlimited.
See also the [RetryWait](#RetryWait) option.
Default: '5'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-tries](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-tries)  
> JSON key: `max-tries`

<a id="MaxUploadLimit"></a>
#### `Size` MaxUploadLimit 

Set maximum upload speed per each torrent in bytes per sec.
'0' means unrestricted.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
To limit overall upload speed, use the  option.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-upload-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-upload-limit)  
> JSON key: `max-upload-limit`

<a id="MetalinkBaseUri"></a>
#### `string` MetalinkBaseUri 

Specify base URI to resolve relative URI in metalink:url and metalink:metaurl element
in a metalink file stored in local disk.
If URI points to a directory, URI must end with '/'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-base-uri](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-base-uri)  
> JSON key: `metalink-base-uri`

<a id="MetalinkEnableUniqueProtocol"></a>
#### `bool` MetalinkEnableUniqueProtocol 

If 'true' is given and several protocols are available for a mirror in a metalink file,
aria2 uses one of them.
Use with the [MetalinkPreferredProtocol](#MetalinkPreferredProtocol) option.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-enable-unique-protocol](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-enable-unique-protocol)  
> JSON key: `metalink-enable-unique-protocol`

<a id="MetalinkLanguage"></a>
#### `string` MetalinkLanguage 

Specify the language of the file to download.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-language](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-language)  
> JSON key: `metalink-language`

<a id="MetalinkLocation"></a>
#### `string` MetalinkLocation 

Specify the location of the preferred server.
A comma-delimited list of locations is acceptable, for example: 'jp,us'.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-location](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-location)  
> JSON key: `metalink-location`

<a id="MetalinkOs"></a>
#### `string` MetalinkOs 

Specify the operating system of the file to download.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-os](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-os)  
> JSON key: `metalink-os`

<a id="MetalinkPreferredProtocol"></a>
#### [`MetalinkPreferredProtocolOptions`](model_MetalinkPreferredProtocolOptions.md) MetalinkPreferredProtocol 

Specify preferred protocol.
Possible values: 'http', 'https', 'ftp' and 'none'.
Specify 'none' to disable this feature.
Default: 'none'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-preferred-protocol](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-preferred-protocol)  
> JSON key: `metalink-preferred-protocol`

<a id="MetalinkVersion"></a>
#### `string` MetalinkVersion 

Specify the version of the file to download.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-version](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-metalink-version)  
> JSON key: `metalink-version`

<a id="MinSplitSize"></a>
#### `Size` MinSplitSize 

aria2 does not split file ranges smaller than twice this value.
For example, consider downloading a 20MiB file.
If SIZE is 10M, aria2 splits the file into 2 ranges; if SIZE is 15M, no split occurs.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
Possible values: from '1M' to '1024M'.
Default: '20M'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-min-split-size](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-min-split-size)  
> JSON key: `min-split-size`

<a id="NoFileAllocationLimit"></a>
#### `Size` NoFileAllocationLimit 

No file allocation is made for files whose size is smaller than this value.
You can append 'K' or 'M' (1K = 1024, 1M = 1024K).
Default: '5M'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-file-allocation-limit](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-file-allocation-limit)  
> JSON key: `no-file-allocation-limit`

<a id="NoNetrc"></a>
#### `bool` NoNetrc 

Disables netrc support.
Netrc support is enabled by default.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-netrc](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-netrc)  
> JSON key: `no-netrc`

<a id="NoProxy"></a>
#### `string` NoProxy 

Specify a comma separated list of host names, domains and network addresses
with or without a subnet mask where no proxy should be used.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-proxy](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-proxy)  
> JSON key: `no-proxy`

<a id="Out"></a>
#### `string` Out 

The file name of the downloaded file.
It is always relative to the directory given in the [Dir](#Dir) option.
When the 'force-sequential' (-Z) option is used, this option is ignored.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-out](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-out)  
> JSON key: `out`

<a id="ParameterizedUri"></a>
#### `bool` ParameterizedUri 

Enable parameterized URI support.
You can specify a set of parts (e.g. 'http://{sv1,sv2,sv3}/foo.iso') or numeric sequences with a step counter
(e.g. 'http://host/image[000-100:2].img').
If all URIs do not point to the same file, the -Z option is required.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-parameterized-uri](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-parameterized-uri)  
> JSON key: `parameterized-uri`

<a id="Pause"></a>
#### `bool` Pause 

Pause download after added.
This option is effective only when 'enable-rpc' is given.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause)  
> JSON key: `pause`

<a id="PauseMetadata"></a>
#### `bool` PauseMetadata 

Pause downloads created as a result of metadata download.
There are 3 types of metadata downloads.
These subsequent downloads will be paused.
This option is effective only when 'enable-rpc' is given.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause-metadata](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-pause-metadata)  
> JSON key: `pause-metadata`

<a id="PieceLength"></a>
#### `Size` PieceLength 

Set a piece length for HTTP/FTP downloads.
This is the boundary when aria2 splits a file.
All splits occur at multiples of this length.
This option will be ignored in BitTorrent downloads and also ignored if a Metalink file contains piece hashes.
Default: '1M'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-piece-length](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-piece-length)  
> JSON key: `piece-length`

<a id="ProxyMethod"></a>
#### [`ProxyMethodOptions`](model_ProxyMethodOptions.md) ProxyMethod 

Set the method to use in proxy request.
METHOD is either 'get' or 'tunnel'.
HTTPS downloads always use 'tunnel' regardless of this option.
Default: 'get'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-proxy-method](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-proxy-method)  
> JSON key: `proxy-method`

<a id="RealtimeChunkChecksum"></a>
#### `bool` RealtimeChunkChecksum 

Validate chunk of data by calculating checksum while downloading a file if chunk checksums are provided.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-realtime-chunk-checksum](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-realtime-chunk-checksum)  
> JSON key: `realtime-chunk-checksum`

<a id="Referer"></a>
#### `string` Referer 

Set an http referrer (Referer).
This affects all http/https downloads.
If '*' is given, the download URI is also used as the referrer.
This may be useful when used together with the [ParameterizedUri](#ParameterizedUri) option.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-referer](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-referer)  
> JSON key: `referer`

<a id="RemoteTime"></a>
#### `bool` RemoteTime 

Retrieve timestamp of the remote file from the remote HTTP/FTP server and if available, apply it to the local file.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remote-time](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remote-time)  
> JSON key: `remote-time`

<a id="RemoveControlFile"></a>
#### `bool` RemoveControlFile 

Remove control file before download.
When used with 'allow-overwrite' set to true, download always starts from scratch.
This is useful for users behind proxy servers which disable resume.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remove-control-file](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-remove-control-file)  
> JSON key: `remove-control-file`

<a id="RetryWait"></a>
#### `int` RetryWait 

Set the seconds to wait between retries.
When SEC > 0, aria2 will retry downloads when the HTTP server returns a 503 response.
Default: '0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-retry-wait](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-retry-wait)  
> JSON key: `retry-wait`

<a id="ReuseUri"></a>
#### `bool` ReuseUri 

Reuse already used URIs if no unused URIs are left.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-reuse-uri](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-reuse-uri)  
> JSON key: `reuse-uri`

<a id="RpcSaveUploadMetadata"></a>
#### `bool` RpcSaveUploadMetadata 

Save the uploaded torrent or metalink metadata in the directory specified by the [Dir](#Dir) option.
The file name consists of the SHA-1 hash hex string of metadata plus an extension.
For torrent, the extension is '.torrent'. For metalink, it is '.meta4'.
If 'false' is given, the downloads added by aria2.addTorrent or aria2.addMetalink will not be saved by option.
Default: 'true'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-save-upload-metadata](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-save-upload-metadata)  
> JSON key: `rpc-save-upload-metadata`

<a id="SeedRatio"></a>
#### `double` SeedRatio 

Specify share ratio. Seed completed torrents until share ratio reaches
RATIO.
You are strongly encouraged to specify equals or more than '1.0' here.
Specify '0.0' if you intend to do seeding regardless of share ratio.
If [SeedTime](#SeedTime) option is specified along with this option, seeding ends when
at least one of the conditions is satisfied.
Default: '1.0'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-ratio](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-ratio)  
> JSON key: `seed-ratio`

<a id="SeedTime"></a>
#### `double` SeedTime 

Specify seeding time in (fractional) minutes. Also see the [SeedRatio](#SeedRatio) option.
Note: Specifying '0' disables seeding after download completed.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-time](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-seed-time)  
> JSON key: `seed-time`

<a id="SelectFile"></a>
#### `string` SelectFile 

Set file to download by specifying its index.
You can find the file index using the  option.
Multiple indexes can be specified by using commas (e.g. '3,6'), ranges (e.g. '1-5'),
or a combination (e.g. '1-5,8,9').

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-select-file](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-select-file)  
> JSON key: `select-file`

<a id="Split"></a>
#### `int` Split 

Download a file using N connections.
If more than N URIs are given, the first N are used and the remaining URIs are used for backup.
If fewer than N URIs are given, those URIs are reused so that N connections total are made simultaneously.
The number of connections to the same host is restricted by the [MaxConnectionPerServer](#MaxConnectionPerServer) option.
See also the [MinSplitSize](#MinSplitSize) option.
Default: '5'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-split](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-split)  
> JSON key: `split`

<a id="SshHostKeyMd"></a>
#### `string` SshHostKeyMd 

Set checksum for SSH host public key.
TYPE is hash type (supported types: 'sha-1' or 'md5') and DIGEST is hex digest.
For example: 'sha-1=b030503d4de4539dc7885e6f0f5e256704edf4c3'.
This option can be used to validate server's public key when SFTP is used.
If not set, no validation takes place.

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ssh-host-key-md](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-ssh-host-key-md)  
> JSON key: `ssh-host-key-md`

<a id="StreamPieceSelector"></a>
#### [`StreamPieceSelectorOptions`](model_StreamPieceSelectorOptions.md) StreamPieceSelector 

Specify piece selection algorithm used in HTTP/FTP download.
A piece is a fixed length segment which is downloaded in parallel in a segmented download.
default:
Select a piece to reduce the number of connections established.
This is the reasonable default behavior.
inorder:
Select a piece closest to the beginning of the file.
This is useful for previewing movies while downloading.
Note that 'enable-http-pipelining' may reduce reconnection overhead.
Also, [MinSplitSize](#MinSplitSize) is honored.
random:
Select a piece randomly.
Also honors the [MinSplitSize](#MinSplitSize) option.
geom:
Initially selects a piece close to the beginning, then exponentially increases the spacing between pieces.
This reduces the number of connections established while downloading the beginning part first.
Default: 'default'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-stream-piece-selector](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-stream-piece-selector)  
> JSON key: `stream-piece-selector`

<a id="Timeout"></a>
#### `int` Timeout 

Set timeout in seconds.
Default: '60'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-timeout](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-timeout)  
> JSON key: `timeout`

<a id="UriSelector"></a>
#### [`UriSelectorOptions`](model_UriSelectorOptions.md) UriSelector 

Specify URI selection algorithm.
The possible values are 'inorder', 'feedback' and 'adaptive'.
If 'inorder' is given, URIs are tried in the order they appear.
If 'feedback' is given, aria2 uses download speed observed in previous downloads to choose the fastest server.
If 'adaptive' is given, it selects one of the best mirrors for the first and reserved connections,
and for supplementary ones returns mirrors which have not been tested yet or need to be retested.
Default: 'feedback'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-uri-selector](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-uri-selector)  
> JSON key: `uri-selector`

<a id="UseHead"></a>
#### `bool` UseHead 

Use HEAD method for the first HTTP request.
Default: 'false'

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-use-head](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-use-head)  
> JSON key: `use-head`

<a id="UserAgent"></a>
#### `string` UserAgent 

Set user agent for HTTP(S) downloads.
Default: 'aria2/$VERSION' (with $VERSION replaced by the package version).

> [https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-user-agent](https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-user-agent)  
> JSON key: `user-agent`


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
