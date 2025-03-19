using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class SystemMulticallRequestTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<SystemMulticallRequest>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"methodName\":\"system.methodName\",\"params\":[\"param1\",\"42\"]}";

            var result = JsonSerializer.Deserialize<SystemMulticallRequest>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.MethodName.Should().Be("system.methodName");

            result.Parameters.Should().NotBeNull();
            result.Parameters.Count.Should().Be(2);

            var param0 = result.Parameters[0] as JsonElement?;
            param0.Should().NotBeNull();
            param0.Value.GetString().Should().Be("param1");

            var param1 = result.Parameters[1] as JsonElement?;
            param1.Should().NotBeNull();
            param1.Value.GetString().Should().Be("42");
        }
    }
}
