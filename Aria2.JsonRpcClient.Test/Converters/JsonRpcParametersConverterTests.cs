using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Converters;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Converters
{
    public class JsonRpcParametersConverterTests
    {
        private readonly JsonRpcParametersConverter _converter = new JsonRpcParametersConverter();
        private static readonly JsonSerializerOptions Options = Aria2ClientSerialization.Options;

        private JsonRpcParameters InvokeRead(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);
            reader.Read();
            return _converter.Read(ref reader, typeof(JsonRpcParameters), Options);
        }

        [Fact]
        public void GIVEN_AnyState_WHEN_Read_THEN_ShouldThrowNotImplementedException()
        {
            var json = "{}";

            Action act = () => InvokeRead(json);

            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void GIVEN_ThreeParametersNullMiddle_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            JsonRpcParameters value = ["param1", null, 42];
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("[\"param1\",null,42]");
        }

        [Fact]
        public void GIVEN_ThreeParametersNullTrailing_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            JsonRpcParameters value = ["param1", 42, null];
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("[\"param1\",42]");
        }

        [Fact]
        public void GIVEN_ThreeParametersNoNullWithInt_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            JsonRpcParameters value = ["param1", 42, 1D];
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("[\"param1\",42,\"1.0\"]");
        }

        [Fact]
        public void GIVEN_ThreeParametersNoNullWithLong_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            JsonRpcParameters value = ["param1", 42L, 1D];
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("[\"param1\",42,\"1.0\"]");
        }

        [Fact]
        public void GIVEN_ThreeParametersNoNullWithBool_WHEN_Write_THEN_ShouldWriteStringValue()
        {
            JsonRpcParameters value = ["param1", true, 1D];
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            _converter.Write(writer, value, Options);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().Be("[\"param1\",true,\"1.0\"]");
        }
    }
}
