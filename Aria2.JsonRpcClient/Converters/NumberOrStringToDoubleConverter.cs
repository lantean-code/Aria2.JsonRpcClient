using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Converters
{
    internal class NumberOrStringToDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32();
            }
            else if (reader.TokenType == JsonTokenType.String && double.TryParse(reader.GetString(), out var value))
            {
                return value;
            }
            else
            {
                throw new JsonException($"Invalid token type for double, expects {JsonTokenType.Number} or {JsonTokenType.String} but found {reader.TokenType}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("0.0####"));
        }
    }
}
