using System.Text.Json;
using FluentAssertions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2ServerDetailTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2ServerDetail>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"uri\":\"http://server.example.com/original\",\"currentUri\":\"http://server.example.com/current\",\"downloadSpeed\":\"2048\"}";

            var result = JsonSerializer.Deserialize<Aria2ServerDetail>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.Uri.Should().Be("http://server.example.com/original");
            result.CurrentUri.Should().Be("http://server.example.com/current");
            result.DownloadSpeed.Should().Be(2048);
        }
    }
}
