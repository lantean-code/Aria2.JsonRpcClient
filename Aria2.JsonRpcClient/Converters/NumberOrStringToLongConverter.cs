using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Converters
{
    internal class NumberOrStringToLongConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt64();
            }
            else if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), out var value))
            {
                return value;
            }
            else
            {
                throw new JsonException($"Invalid token type for long, expects {JsonTokenType.Number} or {JsonTokenType.String} but found {reader.TokenType}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
