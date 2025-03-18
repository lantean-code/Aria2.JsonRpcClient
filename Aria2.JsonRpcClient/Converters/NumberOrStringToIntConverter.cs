using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Converters
{
    internal class NumberOrStringToIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32();
            }
            else if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out var value))
            {
                return value;
            }
            else
            {
                throw new JsonException($"Invalid token type for long, expects {JsonTokenType.Number} or {JsonTokenType.String} but found {reader.TokenType}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
