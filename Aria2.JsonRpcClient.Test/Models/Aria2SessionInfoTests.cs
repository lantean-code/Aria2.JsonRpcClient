using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2SessionInfoTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2SessionInfo>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"sessionId\":\"session123\"}";

            var result = JsonSerializer.Deserialize<Aria2SessionInfo>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();
            result.SessionId.Should().Be("session123");
        }
    }
}
