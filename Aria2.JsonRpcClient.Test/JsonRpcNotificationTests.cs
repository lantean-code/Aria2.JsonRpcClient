using System.Text.Json;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class JsonRpcNotificationTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<JsonRpcNotification>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnCorrectProperties()
        {
            var json = "{\"jsonrpc\":\"2.0\",\"method\":\"notifyMethod\",\"params\":[{\"gid\":\"gid123\"}]}";

            var notification = Serializer.Deserialize<JsonRpcNotification>(json);

            notification.Should().NotBeNull();
            notification.JsonRpc.Should().Be("2.0");
            notification.Method.Should().Be("notifyMethod");
            notification.Parameters.Should().NotBeNull();
            notification.Parameters.Should().HaveCount(1);
            notification.Parameters[0].Gid.Should().Be("gid123");
        }
    }
}
