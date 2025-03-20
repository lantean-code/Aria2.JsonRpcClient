using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2ServerDetailTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2ServerDetail>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"uri\":\"http://server.example.com/original\",\"currentUri\":\"http://server.example.com/current\",\"downloadSpeed\":\"2048\"}";

            var result = Serializer.Deserialize<Aria2ServerDetail>(json);

            result.Should().NotBeNull();

            result.Uri.Should().Be("http://server.example.com/original");
            result.CurrentUri.Should().Be("http://server.example.com/current");
            result.DownloadSpeed.Should().Be(2048);
        }
    }
}
