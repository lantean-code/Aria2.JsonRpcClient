using System.Text.Json;
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Converters
{
    internal class Aria2ErrorCodeConverter : JsonConverter<Aria2ErrorCode>
    {
        public override Aria2ErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int number;
            if (reader.TokenType == JsonTokenType.Number)
            {
                number = reader.GetInt32();
            }
            else if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out var stringNumber))
            {
                number = stringNumber;
            }
            else
            {
                throw new JsonException($"Invalid token type for {nameof(Aria2ErrorCode)}, expects {JsonTokenType.Number} or {JsonTokenType.String} but found {reader.TokenType}.");
            }

            return (Aria2ErrorCode)number;
        }

        public override void Write(Utf8JsonWriter writer, Aria2ErrorCode value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(((int)value).ToString());
        }
    }
}
