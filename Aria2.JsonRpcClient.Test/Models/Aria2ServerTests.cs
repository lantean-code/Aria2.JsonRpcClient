using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2ServerTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2Server>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"index\":\"1\",\"servers\":[{\"uri\":\"http://server.example.com/original\",\"currentUri\":\"http://server.example.com/current\",\"downloadSpeed\":\"2048\"}]}";

            var result = Serializer.Deserialize<Aria2Server>(json);

            result.Should().NotBeNull();

            result.Index.Should().Be(1);

            result.Servers.Should().NotBeNull();
            result.Servers.Should().HaveCount(1);
            result.Servers[0].Uri.Should().Be("http://server.example.com/original");
            result.Servers[0].CurrentUri.Should().Be("http://server.example.com/current");
            result.Servers[0].DownloadSpeed.Should().Be(2048);
        }
    }
}
