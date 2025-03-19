#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Converters;
using Aria2.JsonRpcClient.Models;
namespace Aria2.JsonRpcClient
{

    /// <summary>
    /// Represents a JSON-RPC request.
    /// </summary>
    [JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    Converters = new Type[]
    {
        // Enum converters
        typeof(JsonStringEnumConverter<BtMinCryptoLevelOptions>),
        typeof(JsonStringEnumConverter<FileAllocationOptions>),
        typeof(JsonStringEnumConverter<FollowMetalinkOptions>),
        typeof(JsonStringEnumConverter<FtpTypeOptions>),
        typeof(JsonStringEnumConverter<MetalinkPreferredProtocolOptions>),
        typeof(JsonStringEnumConverter<ProxyMethodOptions>),
        typeof(JsonStringEnumConverter<StatusOptions>),
        typeof(JsonStringEnumConverter<StreamPieceSelectorOptions>),
        typeof(JsonStringEnumConverter<UriSelectorOptions>),
        typeof(JsonStringEnumConverter<UriStatusOptions>),
        typeof(JsonStringEnumConverter<TorrentModeOptions>),

        // Custom converters
        typeof(Aria2ErrorCodeConverter),
        typeof(BooleanOrStringToBoolConverter),
        typeof(NumberOrStringToIntConverter),
        typeof(NumberOrStringToLongConverter),
        typeof(NumberOrStringToDoubleConverter),
        typeof(SizeConverter)
    })]
    [JsonSerializable(typeof(JsonRpcNotification))]
    [JsonSerializable(typeof(JsonRpcRequest))]
    [JsonSerializable(typeof(JsonRpcResponse))]
    [JsonSerializable(typeof(JsonRpcError))]
    [JsonSerializable(typeof(Aria2DownloadOptions))]
    [JsonSerializable(typeof(Requests.AddMetalink))]
    [JsonSerializable(typeof(Requests.AddTorrent))]
    [JsonSerializable(typeof(Requests.AddUri))]
    [JsonSerializable(typeof(Requests.ChangePosition))]
    [JsonSerializable(typeof(Requests.ChangeUri))]
    internal partial class Aria2ClientSerializationContext : JsonSerializerContext
    {

    }
}
#endif
