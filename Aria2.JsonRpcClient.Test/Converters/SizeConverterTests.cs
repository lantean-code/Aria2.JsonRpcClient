using System.Text;
using System.Text.Json;
using FluentAssertions;
using Aria2.JsonRpcClient.Converters;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class SizeConverterTests
    {
        private readonly SizeConverter _converter = new SizeConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private Size InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(Size), Options);
        }

        [Fact]
        public void GIVEN_NullJson_WHEN_Read_THEN_ShouldReturnDefaultSize()
        {
            var json = "null";

            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            var result = _converter.Read(ref reader, typeof(Size), Options);

            result.Should().Be(default(Size));
        }

        [Fact]
        public void GIVEN_ValidSizeStringWithMegabytes_WHEN_Read_THEN_ShouldReturnSizeWithMegabytes()
        {
            var json = "\"1M\"";

            var result = InvokeRead(json);

            result.Value.Should().Be(1);
            result.SizeType.Should().Be(SizeType.Megabytes);
        }

        [Fact]
        public void GIVEN_ValidSizeStringWithKilobytes_WHEN_Read_THEN_ShouldReturnSizeWithKilobytes()
        {
            var json = "\"100K\"";

            var result = InvokeRead(json);

            result.Value.Should().Be(100);
            result.SizeType.Should().Be(SizeType.Kilobytes);
        }

        [Fact]
        public void GIVEN_InvalidSizeString_WHEN_Read_THEN_ShouldThrowJsonException()
        {
            var json = "\"1G\"";

            Action act = () => { var _ = InvokeRead(json); };

            act.Should().Throw<JsonException>()
               .WithMessage("Invalid size value.");
        }

        [Fact]
        public void GIVEN_SizeValueMegabytes_WHEN_Write_THEN_ShouldWriteFormattedString()
        {
            var size = new Size(1, SizeType.Megabytes);
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, size, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"1M\"");
        }

        [Fact]
        public void GIVEN_SizeValueKilobytes_WHEN_Write_THEN_ShouldWriteFormattedString()
        {
            var size = new Size(100, SizeType.Kilobytes);
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, size, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("\"100K\"");
        }
    }
}
