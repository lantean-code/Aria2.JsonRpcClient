using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class Aria2ErrorCodeConverterTests
    {
        private readonly Aria2ErrorCodeConverter _converter = new Aria2ErrorCodeConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private Aria2ErrorCode InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(Aria2ErrorCode), Options);
        }

        [Fact]
        public void GIVEN_NumberToken_WHEN_Read_THEN_ShouldReturnAria2ErrorCodeValue()
        {
            var json = "123";

            var result = InvokeRead(json);

            result.Should().Be((Aria2ErrorCode)123);
        }

        [Fact]
        public void GIVEN_StringTokenWithValidNumber_WHEN_Read_THEN_ShouldReturnAria2ErrorCodeValue()
        {
            var json = "\"123\"";

            var result = InvokeRead(json);

            result.Should().Be((Aria2ErrorCode)123);
        }

        [Fact]
        public void GIVEN_InvalidTokenType_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "true";

            Action act = () => InvokeRead(json);

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for Aria2ErrorCode, expects Number or String but found*");
        }

        [Fact]
        public void GIVEN_Aria2ErrorCodeValue_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            var value = (Aria2ErrorCode)123;
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"123\"");
        }
    }
}
