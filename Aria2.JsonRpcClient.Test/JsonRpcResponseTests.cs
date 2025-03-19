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

            Action act = () => JsonSerializer.Deserialize<JsonRpcResponse>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_DeserializingJsonRpcResponse_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"error\":{\"code\":-32600,\"message\":\"Invalid Request\"},\"customKey\":\"customValue\"}";

            var response = JsonSerializer.Deserialize<JsonRpcResponse>(json, Aria2ClientSerialization.Options);

            response.Should().NotBeNull();
            response.JsonRpc.Should().Be("2.0");
            response.Id.Should().Be("testId");
            response.Error.Should().NotBeNull();
            response.ExtensionData.Should().ContainKey("customKey");
            response.ExtensionData["customKey"].GetString().Should().Be("customValue");
        }

        [Fact]
        public void GIVEN_InvalidJson_WHEN_DeserializingGenericJsonRpcResponse_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<JsonRpcResponse<string>>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_DeserializingGenericJsonRpcResponse_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"result\":\"someResult\",\"anotherKey\":\"anotherValue\"}";

            var response = JsonSerializer.Deserialize<JsonRpcResponse<string>>(json, Aria2ClientSerialization.Options);

            response.Should().NotBeNull();
            response.JsonRpc.Should().Be("2.0");
            response.Id.Should().Be("testId");
            response.Result.Should().Be("someResult");
            response.ExtensionData.Should().ContainKey("anotherKey");
            response.ExtensionData["anotherKey"].GetString().Should().Be("anotherValue");
        }
    }
}
