using System.Text.Json;
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Converters;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient
{
    internal static class Aria2ClientSerialization
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        static Aria2ClientSerialization()
        {
            _options.Converters.Add(new JsonStringEnumConverter<BtMinCryptoLevelOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<FileAllocationOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<FollowMetalinkOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<FtpTypeOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<MetalinkPreferredProtocolOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<ProxyMethodOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<StatusOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<StreamPieceSelectorOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<UriSelectorOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<UriStatusOptions>());
            _options.Converters.Add(new JsonStringEnumConverter<TorrentModeOptions>());

            _options.Converters.Add(new Aria2ErrorCodeConverter());
            _options.Converters.Add(new BooleanOrStringToBoolConverter());
            _options.Converters.Add(new NumberOrStringToIntConverter());
            _options.Converters.Add(new NumberOrStringToLongConverter());
            _options.Converters.Add(new NumberOrStringToDoubleConverter());
            _options.Converters.Add(new SizeConverter());
        }

        internal static JsonSerializerOptions Options => _options;
    }
}
