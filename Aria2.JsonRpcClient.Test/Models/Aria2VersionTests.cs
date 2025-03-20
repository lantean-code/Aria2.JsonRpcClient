using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2VersionTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2Version>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"version\":\"1.35.0\",\"enabledFeatures\":[\"feature1\",\"feature2\"]}";

            var result = Serializer.Deserialize<Aria2Version>(json);

            result.Should().NotBeNull();

            result.Version.Should().Be("1.35.0");
            result.EnabledFeatures.Should().NotBeNull();
            result.EnabledFeatures.Should().HaveCount(2);
            result.EnabledFeatures[0].Should().Be("feature1");
            result.EnabledFeatures[1].Should().Be("feature2");
        }
    }
}
