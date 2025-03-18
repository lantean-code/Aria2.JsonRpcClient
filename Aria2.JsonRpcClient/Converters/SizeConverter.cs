using System.Text.Json;
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Converters
{
    internal class SizeConverter : JsonConverter<Size>
    {
        public override Size Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value is null)
            {
                return default;
            }

            if (Size.TryParse(value, out var size))
            {
                return size;
            }

            throw new JsonException("Invalid size value.");
        }

        public override void Write(Utf8JsonWriter writer, Size value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
