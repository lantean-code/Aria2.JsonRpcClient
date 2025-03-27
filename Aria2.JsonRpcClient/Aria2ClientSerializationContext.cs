#if NET8_0_OR_GREATER
using System.Text.Json;
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
        typeof(SizeConverter),
        typeof(JsonRpcParametersConverter),
    })]
    [JsonSerializable(typeof(JsonRpcNotification))]
    [JsonSerializable(typeof(JsonRpcRequest))]
    [JsonSerializable(typeof(JsonRpcResponse))]
    [JsonSerializable(typeof(JsonRpcError))]
    [JsonSerializable(typeof(JsonRpcParameters))]

    [JsonSerializable(typeof(Requests.AddMetalink))]
    [JsonSerializable(typeof(Requests.AddTorrent))]
    [JsonSerializable(typeof(Requests.AddUri))]
    [JsonSerializable(typeof(Requests.ChangeGlobalOption))]
    [JsonSerializable(typeof(Requests.ChangeOption))]
    [JsonSerializable(typeof(Requests.ChangePosition))]
    [JsonSerializable(typeof(Requests.ChangeUri))]
    [JsonSerializable(typeof(Requests.ForcePause))]
    [JsonSerializable(typeof(Requests.ForcePauseAll))]
    [JsonSerializable(typeof(Requests.ForceRemove))]
    [JsonSerializable(typeof(Requests.ForceShutdown))]
    [JsonSerializable(typeof(Requests.GetFiles))]
    [JsonSerializable(typeof(Requests.GetGlobalOption))]
    [JsonSerializable(typeof(Requests.GetGlobalStat))]
    [JsonSerializable(typeof(Requests.GetOption))]
    [JsonSerializable(typeof(Requests.GetPeers))]
    [JsonSerializable(typeof(Requests.GetServers))]
    [JsonSerializable(typeof(Requests.GetSessionInfo))]
    [JsonSerializable(typeof(Requests.GetUris))]
    [JsonSerializable(typeof(Requests.GetVersion))]
    [JsonSerializable(typeof(Requests.ListMethods))]
    [JsonSerializable(typeof(Requests.ListNotifications))]
    [JsonSerializable(typeof(Requests.MultiCall))]
    [JsonSerializable(typeof(Requests.Pause))]
    [JsonSerializable(typeof(Requests.PauseAll))]
    [JsonSerializable(typeof(Requests.PurgeDownloadResult))]
    [JsonSerializable(typeof(Requests.Remove))]
    [JsonSerializable(typeof(Requests.RemoveDownloadResult))]
    [JsonSerializable(typeof(Requests.SaveSession))]
    [JsonSerializable(typeof(Requests.Shutdown))]
    [JsonSerializable(typeof(Requests.TellActive))]
    [JsonSerializable(typeof(Requests.TellStatus))]
    [JsonSerializable(typeof(Requests.TellStopped))]
    [JsonSerializable(typeof(Requests.TellWaiting))]
    [JsonSerializable(typeof(Requests.Unpause))]
    [JsonSerializable(typeof(Requests.UnpauseAll))]

    [JsonSerializable(typeof(Models.Aria2DownloadOptions))]
    [JsonSerializable(typeof(Models.Aria2Options))]
    [JsonSerializable(typeof(Models.Aria2GlobalOptions))]

    [JsonSerializable(typeof(Models.Aria2Bittorrent))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Bittorrent>))]
    [JsonSerializable(typeof(Models.Aria2File))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2File>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<Models.Aria2File>>))]
    [JsonSerializable(typeof(Models.Aria2GlobalStat))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2GlobalStat>))]
    [JsonSerializable(typeof(Models.Aria2Options))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Options>))]
    [JsonSerializable(typeof(Models.Aria2Peer))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Peer>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<Models.Aria2Peer>>))]
    [JsonSerializable(typeof(Models.Aria2Server))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Server>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<Models.Aria2Server>>))]
    [JsonSerializable(typeof(Models.Aria2ServerDetail))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2ServerDetail>))]
    [JsonSerializable(typeof(Models.Aria2SessionInfo))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2SessionInfo>))]
    [JsonSerializable(typeof(Models.Aria2Status))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Status>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<Models.Aria2Status>>))]
    [JsonSerializable(typeof(Models.Aria2TorrentInfo))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2TorrentInfo>))]
    [JsonSerializable(typeof(Models.Aria2Uri))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Uri>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<Models.Aria2Uri>>))]
    [JsonSerializable(typeof(Models.Aria2Version))]
    [JsonSerializable(typeof(JsonRpcResponse<Models.Aria2Version>))]

    [JsonSerializable(typeof(JsonRpcResponse<string>))]
    [JsonSerializable(typeof(JsonRpcResponse<int>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<object>>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<int>>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyDictionary<string, string?>>))]
    [JsonSerializable(typeof(JsonRpcResponse<IReadOnlyList<string[]>>))]

    [JsonSerializable(typeof(Models.SystemMulticallRequest))]
    [JsonSerializable(typeof(Models.SystemMulticallRequest[]))]

    [JsonSerializable(typeof(GidWrapper))]
    [JsonSerializable(typeof(Models.Size))]
    internal partial class Aria2ClientSerializationContext : JsonSerializerContext
    {

    }
}
#endif
