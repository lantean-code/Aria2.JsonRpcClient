using System.Text.Json.Serialization;
using System.Text.Json;

namespace Aria2.JsonRpcClient.Converters
{
    internal class IgnoreNullValuesConverter<T> : JsonConverter<T>
    {
        private JsonSerializerOptions? _options;

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options)!;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (_options is null)
            {
                var modifiedOptions = new JsonSerializerOptions(options)
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var converterToRemove = modifiedOptions.Converters.FirstOrDefault(c => c.GetType() == GetType());
                if (converterToRemove != null)
                {
                    modifiedOptions.Converters.Remove(converterToRemove);
                }

                _options = modifiedOptions;
            }

            JsonSerializer.Serialize(writer, value, _options);
        }
    }
}
