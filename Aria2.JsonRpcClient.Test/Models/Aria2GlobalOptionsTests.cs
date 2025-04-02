using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2GlobalOptionsTests
    {
        [Fact]
        public void GIVEN_AllNonNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var options = new Aria2GlobalOptions
            {
                AutoSaveInterval = 60,
                BtDetachSeedOnly = false,
                BtMaxOpenFiles = 100,
                CheckCertificate = true,
                ConfPath = "/usr/home/.config/aria2/aria2.conf",
                ConsoleLogLevel = "notice",
                Daemon = false,
                DeferredInput = false,
                DhtFilePath = "/usr/home/.cache/aria2/dht.dat",
                DhtFilePath6 = "/usr/home/.cache/aria2/dht6.dat",
                DhtListenPort = "6881-6999",
                DhtMessageTimeout = 10,
                DisableIpv6 = false,
                DiskCache = 16777216,
                DownloadResult = "default",
                Dscp = 0,
                EnableColor = true,
                EnableDht = true,
                EnableDht6 = false,
                EnableRpc = true,
                EventPoll = "select",
                Help = "#basic",
                HumanReadable = true,
                KeepUnfinishedDownloadResult = true,
                ListenPort = "6881-6999",
                LogLevel = "debug",
                MaxConcurrentDownloads = 5,
                MaxDownloadResult = 1000,
                MaxOverallDownloadLimit = 0,
                MaxOverallUploadLimit = 0,
                MinTlsVersion = "TLSv1.2",
                NetrcPath = "/usr/home/.netrc",
                NoConf = false,
                OptimizeConcurrentDownloads = false,
                PeerAgent = "aria2/1.37.0",
                PeerIdPrefix = "A2-1-37-0-",
                Quiet = false,
                RpcAllowOriginAll = false,
                RpcListenAll = false,
                RpcListenPort = 6800,
                RpcMaxRequestSize = 2097152,
                RpcSecure = false,
                SaveSession = "session.txt",
                SaveSessionInterval = 0,
                ServerStatTimeout = 86400,
                ShowConsoleReadout = true,
                ShowFiles = false,
                SocketRecvBufferSize = 0,
                Stderr = false,
                Stop = 0,
                SummaryInterval = 60,
                TruncateConsoleReadout = true
            };

            var json = Serializer.Serialize(options);
            var expected = "{\"auto-save-interval\":\"60\",\"bt-detach-seed-only\":\"false\",\"bt-max-open-files\":\"100\",\"check-certificate\":\"true\",\"conf-path\":\"/usr/home/.config/aria2/aria2.conf\",\"console-log-level\":\"notice\",\"daemon\":\"false\",\"deferred-input\":\"false\",\"dht-file-path\":\"/usr/home/.cache/aria2/dht.dat\",\"dht-file-path6\":\"/usr/home/.cache/aria2/dht6.dat\",\"dht-listen-port\":\"6881-6999\",\"dht-message-timeout\":\"10\",\"disable-ipv6\":\"false\",\"disk-cache\":\"16777216\",\"download-result\":\"default\",\"dscp\":\"0\",\"enable-color\":\"true\",\"enable-dht\":\"true\",\"enable-dht6\":\"false\",\"enable-rpc\":\"true\",\"event-poll\":\"select\",\"help\":\"#basic\",\"human-readable\":\"true\",\"keep-unfinished-download-result\":\"true\",\"listen-port\":\"6881-6999\",\"log-level\":\"debug\",\"max-concurrent-downloads\":\"5\",\"max-download-result\":\"1000\",\"max-overall-download-limit\":\"0\",\"max-overall-upload-limit\":\"0\",\"min-tls-version\":\"TLSv1.2\",\"netrc-path\":\"/usr/home/.netrc\",\"no-conf\":\"false\",\"optimize-concurrent-downloads\":\"false\",\"peer-agent\":\"aria2/1.37.0\",\"peer-id-prefix\":\"A2-1-37-0-\",\"quiet\":\"false\",\"rpc-allow-origin-all\":\"false\",\"rpc-listen-all\":\"false\",\"rpc-listen-port\":\"6800\",\"rpc-max-request-size\":\"2097152\",\"rpc-secure\":\"false\",\"save-session\":\"session.txt\",\"save-session-interval\":\"0\",\"server-stat-timeout\":\"86400\",\"show-console-readout\":\"true\",\"show-files\":\"false\",\"socket-recv-buffer-size\":\"0\",\"stderr\":\"false\",\"stop\":\"0\",\"summary-interval\":\"60\",\"truncate-console-readout\":\"true\"}";
            json.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GIVEN_SomeNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            // Only a few properties are set while the rest remain null.
            var options = new Aria2GlobalOptions
            {
                AutoSaveInterval = 60,
                CheckCertificate = true,
                ConfPath = "/usr/home/.config/aria2/aria2.conf",
                LogLevel = "debug",
                NetrcPath = "/usr/home/.netrc",
                RpcListenPort = 6800,
                SaveSession = "session.txt"
            };

            var json = Serializer.Serialize(options);
            var expected = "{\"auto-save-interval\":\"60\",\"check-certificate\":\"true\",\"conf-path\":\"/usr/home/.config/aria2/aria2.conf\",\"log-level\":\"debug\",\"netrc-path\":\"/usr/home/.netrc\",\"rpc-listen-port\":\"6800\",\"save-session\":\"session.txt\"}";
            json.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GIVEN_AllNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var options = new Aria2GlobalOptions
            {
                // All properties remain null.
            };

            var json = Serializer.Serialize(options);
            var expected = "{}";
            json.Should().BeEquivalentTo(expected);
        }
    }
}
