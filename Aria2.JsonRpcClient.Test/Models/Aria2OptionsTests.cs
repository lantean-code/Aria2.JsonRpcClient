using System;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2OptionsTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2Options>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"option1\":\"value1\",\"option2\":\"value2\"}";

            var result = JsonSerializer.Deserialize<Aria2Options>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.Options.Should().NotBeNull();
            result.Options.Should().HaveCount(2);
            ((JsonElement)result.Options["option1"]).GetString().Should().Be("value1");
            ((JsonElement)result.Options["option2"]).GetString().Should().Be("value2");
        }
    }
}
