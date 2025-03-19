using System.Text.Json;
using FluentAssertions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2VersionTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2Version>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"version\":\"1.35.0\",\"enabledFeatures\":[\"feature1\",\"feature2\"]}";

            var result = JsonSerializer.Deserialize<Aria2Version>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.Version.Should().Be("1.35.0");
            result.EnabledFeatures.Should().NotBeNull();
            result.EnabledFeatures.Should().HaveCount(2);
            result.EnabledFeatures[0].Should().Be("feature1");
            result.EnabledFeatures[1].Should().Be("feature2");
        }
    }
}
