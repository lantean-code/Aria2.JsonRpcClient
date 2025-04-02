using System.Text.Json;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class JsonRpcResponseTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_DeserializingJsonRpcResponse_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<JsonRpcResponse>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_DeserializingJsonRpcResponse_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"error\":{\"code\":-32600,\"message\":\"Invalid Request\"},\"customKey\":\"customValue\"}";

            var response = Serializer.Deserialize<JsonRpcResponse>(json);

            response.Should().NotBeNull();
            response.JsonRpc.Should().Be("2.0");
            response.Id.Should().Be("testId");
            response.Error.Should().NotBeNull();
#if DEBUG
            response.ExtensionData.Should().ContainKey("customKey");
            response.ExtensionData["customKey"].GetString().Should().Be("customValue");
#endif
        }

        [Fact]
        public void GIVEN_InvalidJson_WHEN_DeserializingGenericJsonRpcResponse_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<JsonRpcResponse<string>>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_DeserializingGenericJsonRpcResponse_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"result\":\"someResult\",\"anotherKey\":\"anotherValue\"}";

            var response = Serializer.Deserialize<JsonRpcResponse<string>>(json);

            response.Should().NotBeNull();
            response.JsonRpc.Should().Be("2.0");
            response.Id.Should().Be("testId");
            response.Result.Should().Be("someResult");
#if DEBUG
            response.ExtensionData.Should().ContainKey("anotherKey");
            response.ExtensionData["anotherKey"].GetString().Should().Be("anotherValue");
#endif
        }
    }
}
