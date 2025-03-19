#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Converters;
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
        typeof(JsonStringEnumConverter<Models.BtMinCryptoLevelOptions>),
        typeof(JsonStringEnumConverter<Models.FileAllocationOptions>),
        typeof(JsonStringEnumConverter<Models.FollowMetalinkOptions>),
        typeof(JsonStringEnumConverter<Models.FtpTypeOptions>),
        typeof(JsonStringEnumConverter<Models.MetalinkPreferredProtocolOptions>),
        typeof(JsonStringEnumConverter<Models.ProxyMethodOptions>),
        typeof(JsonStringEnumConverter<Models.StatusOptions>),
        typeof(JsonStringEnumConverter<Models.StreamPieceSelectorOptions>),
        typeof(JsonStringEnumConverter<Models.UriSelectorOptions>),
        typeof(JsonStringEnumConverter<Models.UriStatusOptions>),
        typeof(JsonStringEnumConverter<Models.TorrentModeOptions>),

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

    [JsonSerializable(typeof(Requests.AddMetalink), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.AddTorrent), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.AddUri), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ChangeGlobalOption), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ChangeOption), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ChangePosition), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ChangeUri), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ForcePause), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ForcePauseAll), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ForceRemove), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ForceShutdown), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetFiles), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetGlobalOption), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetGlobalStat), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetOption), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetPeers), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetServers), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetSessionInfo), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetUris), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.GetVersion), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ListMethods), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.ListNotifications), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.MultiCall), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.Pause), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.PauseAll), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.PurgeDownloadResult), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.Remove), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.RemoveDownloadResult), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.SaveSession), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.Shutdown), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.TellActive), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.TellStatus), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.TellStopped), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.TellWaiting), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.Unpause), GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(Requests.UnpauseAll), GenerationMode = JsonSourceGenerationMode.Serialization)]

    [JsonSerializable(typeof(Models.Aria2DownloadOptions), GenerationMode = JsonSourceGenerationMode.Serialization)]

    [JsonSerializable(typeof(Models.Aria2Bittorrent))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Bittorrent>))]
    [JsonSerializable(typeof(Models.Aria2File))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2File>))]
    [JsonSerializable(typeof(Models.Aria2GlobalStat))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2GlobalStat>))]
    [JsonSerializable(typeof(Models.Aria2Options))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Options>))]
    [JsonSerializable(typeof(Models.Aria2Peer))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Peer>))]
    [JsonSerializable(typeof(Models.Aria2Server))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Server>))]
    [JsonSerializable(typeof(Models.Aria2ServerDetail))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2ServerDetail>))]
    [JsonSerializable(typeof(Models.Aria2SessionInfo))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2SessionInfo>))]
    [JsonSerializable(typeof(Models.Aria2Status))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Status>))]
    [JsonSerializable(typeof(Models.Aria2TorrentInfo))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2TorrentInfo>))]
    [JsonSerializable(typeof(Models.Aria2Uri))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Uri>))]
    [JsonSerializable(typeof(Models.Aria2Version))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Version>))]

    internal partial class Aria2ClientSerializationContext : JsonSerializerContext
    {

    }
}
#endif
