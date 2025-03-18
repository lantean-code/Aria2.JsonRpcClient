using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Converters
{
    internal class BooleanOrStringToBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                return reader.GetBoolean();
            }
            else if (reader.TokenType == JsonTokenType.String && bool.TryParse(reader.GetString(), out var value))
            {
                return value;
            }
            else
            {
                throw new JsonException($"Invalid token type for long, expects {JsonTokenType.True}, {JsonTokenType.False} or {JsonTokenType.String} but found {reader.TokenType}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteBooleanValue(value);
        }
    }
}
