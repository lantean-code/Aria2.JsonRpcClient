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
        public void GIVEN_AllNonNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var options = new Aria2Options
            {
                NoWantDigestHeader = false,
                SaveNotFound = true,
            };

            var json = Serializer.Serialize(options);
            var expected = "{\"no-want-digest-header\":\"false\",\"save-not-found\":\"true\"}";
            json.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GIVEN_SomeNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var options = new Aria2Options
            {
                NoWantDigestHeader = false,
            };

            var json = Serializer.Serialize(options);
            var expected = "{\"no-want-digest-header\":\"false\"}";
            json.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GIVEN_AllNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var options = new Aria2Options
            {
                // All properties remain null.
            };

            var json = Serializer.Serialize(options);
            var expected = "{}";
            json.Should().BeEquivalentTo(expected);
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
