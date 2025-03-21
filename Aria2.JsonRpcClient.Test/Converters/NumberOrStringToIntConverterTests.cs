using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class NumberOrStringToIntConverterTests
    {
        private readonly NumberOrStringToIntConverter _converter = new NumberOrStringToIntConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private int InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(int), Options);
        }

        [Fact]
        public void GIVEN_NumberToken_WHEN_Read_THEN_ShouldReturnIntValue()
        {
            var json = "42";

            var result = InvokeRead(json);

            result.Should().Be(42);
        }

        [Fact]
        public void GIVEN_StringTokenWithValidInt_WHEN_Read_THEN_ShouldReturnIntValue()
        {
            var json = "\"42\"";

            var result = InvokeRead(json);

            result.Should().Be(42);
        }

        [Fact]
        public void GIVEN_StringTokenWithInvalidInt_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "\"abc\"";

            Action act = () => InvokeRead(json);

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for int, expects*");
        }

        [Fact]
        public void GIVEN_InvalidTokenType_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "true";

            Action act = () => InvokeRead(json);

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for int, expects*");
        }

        [Fact]
        public void GIVEN_IntValue_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            var value = 42;
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"42\"");
        }
    }
}
