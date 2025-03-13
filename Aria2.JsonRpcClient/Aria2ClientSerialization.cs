using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    internal static class Aria2ClientSerialization
    {
        private static readonly JsonSerializerOptions _options;

        static Aria2ClientSerialization()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            _options.Converters.Add(new JsonStringEnumConverter());
        }

        internal static JsonSerializerOptions Options => _options;
    }
}
