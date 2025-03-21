using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2OptionsTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2Options>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"option1\":\"value1\",\"option2\":\"value2\"}";

            var result = Serializer.Deserialize<Aria2Options>(json);

            result.Should().NotBeNull();

            result.AdditionalOptions.Should().NotBeNull();
            result.AdditionalOptions.Should().HaveCount(2);
            ((JsonElement)result.AdditionalOptions["option1"]).GetString().Should().Be("value1");
            ((JsonElement)result.AdditionalOptions["option2"]).GetString().Should().Be("value2");
        }
    }
}
