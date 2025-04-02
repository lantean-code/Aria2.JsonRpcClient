using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents the global options.
    /// Any options not mapped to a specific property are in <see cref="Aria2Options.AdditionalOptions"/>.
    /// </summary>
    public record Aria2GlobalOptions : Aria2Options
    {
        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-auto-save-interval"/>
        [JsonPropertyName("auto-save-interval"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AutoSaveInterval { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-detach-seed-only"/>
        [JsonPropertyName("bt-detach-seed-only"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BtDetachSeedOnly { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-bt-max-open-files"/>
        [JsonPropertyName("bt-max-open-files"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BtMaxOpenFiles { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-check-certificate"/>
        [JsonPropertyName("check-certificate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CheckCertificate { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-conf-path"/>
        [JsonPropertyName("conf-path"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ConfPath { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-console-log-level"/>
        [JsonPropertyName("console-log-level"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ConsoleLogLevel { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-daemon"/>
        [JsonPropertyName("daemon"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Daemon { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-deferred-input"/>
        [JsonPropertyName("deferred-input"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DeferredInput { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dht-file-path"/>
        [JsonPropertyName("dht-file-path"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DhtFilePath { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dht-file-path6"/>
        [JsonPropertyName("dht-file-path6"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DhtFilePath6 { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dht-listen-port"/>
        [JsonPropertyName("dht-listen-port"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DhtListenPort { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dht-message-timeout"/>
        [JsonPropertyName("dht-message-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DhtMessageTimeout { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-disable-ipv6"/>
        [JsonPropertyName("disable-ipv6"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableIpv6 { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-disk-cache"/>
        [JsonPropertyName("disk-cache"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DiskCache { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-download-result"/>
        [JsonPropertyName("download-result"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DownloadResult { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-dscp"/>
        [JsonPropertyName("dscp"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Dscp { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-color"/>
        [JsonPropertyName("enable-color"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableColor { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-dht"/>
        [JsonPropertyName("enable-dht"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableDht { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-dht6"/>
        [JsonPropertyName("enable-dht6"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableDht6 { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-enable-rpc"/>
        [JsonPropertyName("enable-rpc"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableRpc { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-event-poll"/>
        [JsonPropertyName("event-poll"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EventPoll { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-help"/>
        [JsonPropertyName("help"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Help { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-human-readable"/>
        [JsonPropertyName("human-readable"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HumanReadable { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-keep-unfinished-download-result"/>
        [JsonPropertyName("keep-unfinished-download-result"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? KeepUnfinishedDownloadResult { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-listen-port"/>
        [JsonPropertyName("listen-port"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ListenPort { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-log-level"/>
        [JsonPropertyName("log-level"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LogLevel { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-concurrent-downloads"/>
        [JsonPropertyName("max-concurrent-downloads"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxConcurrentDownloads { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-download-result"/>
        [JsonPropertyName("max-download-result"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxDownloadResult { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-overall-download-limit"/>
        [JsonPropertyName("max-overall-download-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxOverallDownloadLimit { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-max-overall-upload-limit"/>
        [JsonPropertyName("max-overall-upload-limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxOverallUploadLimit { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-min-tls-version"/>
        [JsonPropertyName("min-tls-version"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MinTlsVersion { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-netrc-path"/>
        [JsonPropertyName("netrc-path"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NetrcPath { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-no-conf"/>
        [JsonPropertyName("no-conf"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NoConf { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-optimize-concurrent-downloads"/>
        [JsonPropertyName("optimize-concurrent-downloads"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OptimizeConcurrentDownloads { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-peer-agent"/>
        [JsonPropertyName("peer-agent"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PeerAgent { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-peer-id-prefix"/>
        [JsonPropertyName("peer-id-prefix"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PeerIdPrefix { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-quiet"/>
        [JsonPropertyName("quiet"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Quiet { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-allow-origin-all"/>
        [JsonPropertyName("rpc-allow-origin-all"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RpcAllowOriginAll { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-listen-all"/>
        [JsonPropertyName("rpc-listen-all"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RpcListenAll { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-listen-port"/>
        [JsonPropertyName("rpc-listen-port"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RpcListenPort { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-max-request-size"/>
        [JsonPropertyName("rpc-max-request-size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RpcMaxRequestSize { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-rpc-secure"/>
        [JsonPropertyName("rpc-secure"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RpcSecure { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-session"/>
        [JsonPropertyName("save-session"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SaveSession { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-save-session-interval"/>
        [JsonPropertyName("save-session-interval"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SaveSessionInterval { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-server-stat-timeout"/>
        [JsonPropertyName("server-stat-timeout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ServerStatTimeout { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-show-console-readout"/>
        [JsonPropertyName("show-console-readout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowConsoleReadout { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-show-files"/>
        [JsonPropertyName("show-files"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowFiles { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-socket-recv-buffer-size"/>
        [JsonPropertyName("socket-recv-buffer-size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SocketRecvBufferSize { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-stderr"/>
        [JsonPropertyName("stderr"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Stderr { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-stop"/>
        [JsonPropertyName("stop"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Stop { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-summary-interval"/>
        [JsonPropertyName("summary-interval"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SummaryInterval { get; init; }

        /// <seealso href="https://aria2.github.io/manual/en/html/aria2c.html#cmdoption-truncate-console-readout"/>
        [JsonPropertyName("truncate-console-readout"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? TruncateConsoleReadout { get; init; }
    }
}
