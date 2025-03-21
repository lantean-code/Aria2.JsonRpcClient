using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class NumberOrStringToLongConverterTests
    {
        private readonly NumberOrStringToLongConverter _converter = new NumberOrStringToLongConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private long InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(long), Options);
        }

        [Fact]
        public void GIVEN_NumberToken_WHEN_Read_THEN_ShouldReturnLongValue()
        {
            var json = "1234567890123";

            var result = InvokeRead(json);

            result.Should().Be(1234567890123);
        }

        [Fact]
        public void GIVEN_StringTokenWithValidLong_WHEN_Read_THEN_ShouldReturnLongValue()
        {
            var json = "\"1234567890123\"";

            var result = InvokeRead(json);

            result.Should().Be(1234567890123);
        }

        [Fact]
        public void GIVEN_StringTokenWithInvalidLong_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "\"notalong\"";

            Action act = () => InvokeRead(json);

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for long, expects*");
        }

        [Fact]
        public void GIVEN_InvalidTokenType_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "true";

            Action act = () => InvokeRead(json);

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for long, expects*");
        }

        [Fact]
        public void GIVEN_LongValue_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            var value = 1234567890123;
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"1234567890123\"");
        }
    }
}
