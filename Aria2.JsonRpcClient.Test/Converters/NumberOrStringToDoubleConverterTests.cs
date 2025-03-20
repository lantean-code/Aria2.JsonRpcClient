using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class NumberOrStringToDoubleConverterTests
    {
        private readonly NumberOrStringToDoubleConverter _converter = new NumberOrStringToDoubleConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private double InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(double), Options);
        }

        [Fact]
        public void GIVEN_NumberToken_WHEN_Read_THEN_ShouldReturnDoubleValue()
        {
            var json = "42";

            var result = InvokeRead(json);

            result.Should().Be(42);
        }

        [Fact]
        public void GIVEN_StringTokenWithValidDouble_WHEN_Read_THEN_ShouldReturnDoubleValue()
        {
            var json = "\"42.5\"";

            var result = InvokeRead(json);

            result.Should().Be(42.5);
        }

        [Fact]
        public void GIVEN_StringTokenWithInvalidDouble_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "\"abc\"";

            Action act = () => { var _ = InvokeRead(json); };

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for double, expects*");
        }

        [Fact]
        public void GIVEN_InvalidTokenType_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "true";

            Action act = () => { var _ = InvokeRead(json); };

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for double, expects*");
        }

        [Fact]
        public void GIVEN_DoubleValue_WHEN_Write_THEN_ShouldWriteFormattedStringValue()
        {
            // Use a value that doesn't require rounding.
            var value = 42.1234;
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"42.1234\"");
        }
    }
}
