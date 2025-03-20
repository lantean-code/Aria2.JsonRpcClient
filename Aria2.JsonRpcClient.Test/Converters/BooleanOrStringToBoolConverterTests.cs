using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class BooleanOrStringToBoolConverterTests
    {
        private readonly BooleanOrStringToBoolConverter _converter = new BooleanOrStringToBoolConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private bool InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(bool), Options);
        }

        [Fact]
        public void GIVEN_TrueToken_WHEN_Read_THEN_ShouldReturnTrue()
        {
            var json = "true";

            var result = InvokeRead(json);

            result.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_FalseToken_WHEN_Read_THEN_ShouldReturnFalse()
        {
            var json = "false";

            var result = InvokeRead(json);

            result.Should().BeFalse();
        }

        [Fact]
        public void GIVEN_StringTokenWithTrue_WHEN_Read_THEN_ShouldReturnTrue()
        {
            var json = "\"true\"";

            var result = InvokeRead(json);

            result.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_StringTokenWithFalse_WHEN_Read_THEN_ShouldReturnFalse()
        {
            var json = "\"false\"";

            var result = InvokeRead(json);

            result.Should().BeFalse();
        }

        [Fact]
        public void GIVEN_StringTokenWithInvalidBoolean_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "\"notabool\"";

            Action act = () => { var _ = InvokeRead(json); };

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for long, expects*");
        }

        [Fact]
        public void GIVEN_InvalidTokenType_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "123";

            Action act = () => { var _ = InvokeRead(json); };

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid token type for long, expects*");
        }

        [Fact]
        public void GIVEN_BooleanValue_WHEN_Write_THEN_ShouldWriteFormattedStringValue()
        {
            var value = true;
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"true\"");
        }
    }
}
