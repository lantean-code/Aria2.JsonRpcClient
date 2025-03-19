using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Aria2.JsonRpcClient.Models;
using Microsoft.Extensions.Options;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2DownloadOptionsTests
    {
        [Fact]
        public void TestDownloadOptions()
        {
            var options = new Aria2DownloadOptions
            {
                AllowOverwrite = true,
                AutoFileRenaming = true,
                CheckIntegrity = true,
                Dir = "C:\\Downloads",
                FileAllocation = FileAllocationOptions.Prealloc,
                MaxConnectionPerServer = 16,
                MaxDownloadLimit = new Size(12, SizeType.Megabytes),
                MaxUploadLimit = new Size(),
                Split = 16,
                Timeout = 600,
                UserAgent = "Aria2/1.35.0"
            };
            var json = JsonSerializer.Serialize(options);
            var expected = "{\"allow-overwrite\":true,\"auto-file-renaming\":true,\"check-integrity\":true,\"dir\":\"C:\\Downloads\",\"file-allocation\":\"prealloc\",\"max-connection-per-server\":16,\"max-download-limit\":\"12M\",\"max-upload-limit\":\"0M\",\"split\":16,\"timeout\":600,\"user-agent\":\"Aria2/1.35.0\"}";
            Assert.Equal(expected, json);
        }

        [Fact]
        public void IsIt()
        {
            var downloadOptions = new Aria2DownloadOptions
            {
                AllProxy = "http://user:pass@proxy.example.com:8080",
                AllProxyPasswd = "pass",
                AllProxyUser = "user",
                AllowOverwrite = true,
                AllowPieceLengthChange = true,
                AlwaysResume = true,
                AsyncDns = true,
                AutoFileRenaming = true,
                BtEnableHookAfterHashCheck = true,
                BtEnableLpd = true,
                BtExcludeTracker = "http://tracker.example.com/exclude",
                BtExternalIp = "192.168.1.100",
                BtForceEncryption = true,
                BtHashCheckSeed = true,
                BtLoadSavedMetadata = true,
                BtMaxPeers = 100,
                BtMetadataOnly = false,
                BtMinCryptoLevel = BtMinCryptoLevelOptions.Plain,
                BtPrioritizePiece = "head=1M,tail=1M",
                BtRemoveUnselectedFile = true,
                BtRequestPeerSpeedLimit = new Size(50, SizeType.Kilobytes),
                BtRequireCrypto = true,
                BtSaveMetadata = true,
                BtSeedUnverified = true,
                BtStopTimeout = 30,
                BtTracker = "http://tracker.example.com/announce",
                BtTrackerConnectTimeout = 60,
                BtTrackerInterval = 120,
                BtTrackerTimeout = 60,
                CheckIntegrity = true,
                Checksum = "sha-1=0192ba11326fe2298c8cb4de616f4d4140213838",
                ConditionalGet = true,
                ConnectTimeout = 60,
                ContentDispositionDefaultUtf8 = true,
                @Continue = true,
                Dir = "/downloads",
                DryRun = true,
                EnableHttpKeepAlive = true,
                EnableHttpPipelining = true,
                EnableMmap = true,
                EnablePeerExchange = true,
                FileAllocation = FileAllocationOptions.Prealloc,
                FollowMetalink = FollowMetalinkOptions.Mem,
                FollowTorrent = true,
                ForceSave = true,
                FtpPasswd = "ftpPassword",
                FtpPasv = true,
                FtpProxy = "http://ftp-proxy.example.com:2121",
                FtpProxyPasswd = "ftpProxyPass",
                FtpProxyUser = "ftpProxyUser",
                FtpReuseConnection = true,
                FtpType = FtpTypeOptions.Binary,
                FtpUser = "anonymous",
                Gid = "1234567890abcdef",
                HashCheckOnly = true,
                Header = "User-Agent: aria2",
                HttpAcceptGzip = true,
                HttpAuthChallenge = true,
                HttpNoCache = true,
                HttpPasswd = "httpPass",
                HttpProxy = "http://http-proxy.example.com:3128",
                HttpProxyPasswd = "httpProxyPass",
                HttpProxyUser = "httpProxyUser",
                HttpUser = "httpUser",
                HttpsProxy = "http://https-proxy.example.com:3128",
                HttpsProxyPasswd = "httpsProxyPass",
                HttpsProxyUser = "httpsProxyUser",
                IndexOut = "index0",
                LowestSpeedLimit = new Size(0, SizeType.Kilobytes),
                MaxConnectionPerServer = 10,
                MaxDownloadLimit = new Size(0, SizeType.Kilobytes),
                MaxFileNotFound = 0,
                MaxMmapLimit = new Size(1024, SizeType.Megabytes),
                MaxResumeFailureTries = 5,
                MaxTries = 5,
                MaxUploadLimit = new Size(0, SizeType.Kilobytes),
                MetalinkBaseUri = "http://metalink.example.com/base/",
                MetalinkEnableUniqueProtocol = true,
                MetalinkLanguage = "en",
                MetalinkLocation = "us,jp",
                MetalinkOs = "windows",
                MetalinkPreferredProtocol = MetalinkPreferredProtocolOptions.Https,
                MetalinkVersion = "1.0",
                MinSplitSize = new Size(20, SizeType.Megabytes),
                NoFileAllocationLimit = new Size(5, SizeType.Megabytes),
                NoNetrc = true,
                NoProxy = "localhost,127.0.0.1",
                Out = "output.file",
                ParameterizedUri = true,
                Pause = true,
                PauseMetadata = true,
                PieceLength = new Size(1, SizeType.Megabytes),
                ProxyMethod = ProxyMethodOptions.Get,
                RealtimeChunkChecksum = true,
                Referer = "http://example.com",
                RemoteTime = true,
                RemoveControlFile = true,
                RetryWait = 10,
                ReuseUri = true,
                RpcSaveUploadMetadata = true,
                SeedRatio = 1.0,
                SeedTime = 30.0,
                SelectFile = "1,2,3",
                Split = 5,
                SshHostKeyMd = "sha-1=b030503d4de4539dc7885e6f0f5e256704edf4c3",
                StreamPieceSelector = StreamPieceSelectorOptions.Default,
                Timeout = 60,
                UriSelector = UriSelectorOptions.Feedback,
                UseHead = true,
                UserAgent = "aria2/1.35.0"
            };


            var json = JsonSerializer.Serialize(downloadOptions, Aria2ClientSerialization.Options);
            var expected = "{\"all-proxy\":\"http://user:pass@proxy.example.com:8080\",\"all-proxy-passwd\":\"pass\",\"all-proxy-user\":\"user\",\"allow-overwrite\":\"true\",\"allow-piece-length-change\":\"true\",\"always-resume\":\"true\",\"async-dns\":\"true\",\"auto-file-renaming\":\"true\",\"bt-enable-hook-after-hash-check\":\"true\",\"bt-enable-lpd\":\"true\",\"bt-exclude-tracker\":\"http://tracker.example.com/exclude\",\"bt-external-ip\":\"192.168.1.100\",\"bt-force-encryption\":\"true\",\"bt-hash-check-seed\":\"true\",\"bt-load-saved-metadata\":\"true\",\"bt-max-peers\":\"100\",\"bt-metadata-only\":\"false\",\"bt-min-crypto-level\":\"plain\",\"bt-prioritize-piece\":\"head=1M,tail=1M\",\"bt-remove-unselected-file\":\"true\",\"bt-request-peer-speed-limit\":\"50K\",\"bt-require-crypto\":\"true\",\"bt-save-metadata\":\"true\",\"bt-seed-unverified\":\"true\",\"bt-stop-timeout\":\"30\",\"bt-tracker\":\"http://tracker.example.com/announce\",\"bt-tracker-connect-timeout\":\"60\",\"bt-tracker-interval\":\"120\",\"bt-tracker-timeout\":\"60\",\"check-integrity\":\"true\",\"checksum\":\"sha-1=0192ba11326fe2298c8cb4de616f4d4140213838\",\"conditional-get\":\"true\",\"connect-timeout\":\"60\",\"content-disposition-default-utf8\":\"true\",\"continue\":\"true\",\"dir\":\"/downloads\",\"dry-run\":\"true\",\"enable-http-keep-alive\":\"true\",\"enable-http-pipelining\":\"true\",\"enable-mmap\":\"true\",\"enable-peer-exchange\":\"true\",\"file-allocation\":\"prealloc\",\"follow-metalink\":\"mem\",\"follow-torrent\":\"true\",\"force-save\":\"true\",\"ftp-passwd\":\"ftpPassword\",\"ftp-pasv\":\"true\",\"ftp-proxy\":\"http://ftp-proxy.example.com:2121\",\"ftp-proxy-passwd\":\"ftpProxyPass\",\"ftp-proxy-user\":\"ftpProxyUser\",\"ftp-reuse-connection\":\"true\",\"ftp-type\":\"binary\",\"ftp-user\":\"anonymous\",\"gid\":\"1234567890abcdef\",\"hash-check-only\":\"true\",\"header\":\"User-Agent: aria2\",\"http-accept-gzip\":\"true\",\"http-auth-challenge\":\"true\",\"http-no-cache\":\"true\",\"http-passwd\":\"httpPass\",\"http-proxy\":\"http://http-proxy.example.com:3128\",\"http-proxy-passwd\":\"httpProxyPass\",\"http-proxy-user\":\"httpProxyUser\",\"http-user\":\"httpUser\",\"https-proxy\":\"http://https-proxy.example.com:3128\",\"https-proxy-passwd\":\"httpsProxyPass\",\"https-proxy-user\":\"httpsProxyUser\",\"index-out\":\"index0\",\"lowest-speed-limit\":\"0K\",\"max-connection-per-server\":\"10\",\"max-download-limit\":\"0K\",\"max-file-not-found\":\"0\",\"max-mmap-limit\":\"1024M\",\"max-resume-failure-tries\":\"5\",\"max-tries\":\"5\",\"max-upload-limit\":\"0K\",\"metalink-base-uri\":\"http://metalink.example.com/base/\",\"metalink-enable-unique-protocol\":\"true\",\"metalink-language\":\"en\",\"metalink-location\":\"us,jp\",\"metalink-os\":\"windows\",\"metalink-preferred-protocol\":\"https\",\"metalink-version\":\"1.0\",\"min-split-size\":\"20M\",\"no-file-allocation-limit\":\"5M\",\"no-netrc\":\"true\",\"no-proxy\":\"localhost,127.0.0.1\",\"out\":\"output.file\",\"parameterized-uri\":\"true\",\"pause\":\"true\",\"pause-metadata\":\"true\",\"piece-length\":\"1M\",\"proxy-method\":\"get\",\"realtime-chunk-checksum\":\"true\",\"referer\":\"http://example.com\",\"remote-time\":\"true\",\"remove-control-file\":\"true\",\"retry-wait\":\"10\",\"reuse-uri\":\"true\",\"rpc-save-upload-metadata\":\"true\",\"seed-ratio\":\"1.0\",\"seed-time\":\"30.0\",\"select-file\":\"1,2,3\",\"split\":\"5\",\"ssh-host-key-md\":\"sha-1=b030503d4de4539dc7885e6f0f5e256704edf4c3\",\"stream-piece-selector\":\"default\",\"timeout\":\"60\",\"uri-selector\":\"feedback\",\"use-head\":\"true\",\"user-agent\":\"aria2/1.35.0\"}";
            Assert.Equal(expected, json);
        }
    }
}
