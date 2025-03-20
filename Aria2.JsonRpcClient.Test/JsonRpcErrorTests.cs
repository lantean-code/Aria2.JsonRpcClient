using System.Text.Json;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class JsonRpcErrorTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_DeserializingJsonRpcError_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<JsonRpcError>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_DeserializingJsonRpcError_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"code\":-32600,\"message\":\"Invalid Request\",\"customKey\":\"customValue\"}";

            var error = Serializer.Deserialize<JsonRpcError>(json);

            error.Should().NotBeNull();
            error.Code.Should().Be(-32600);
            error.Message.Should().Be("Invalid Request");
            error.ExtensionData.Should().ContainKey("customKey");
            error.ExtensionData["customKey"].GetString().Should().Be("customValue");
        }
    }
}
