using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2UriTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            // Arrange
            var json = "InvalidJson";
            // Act
            Action act = () => Serializer.Deserialize<Aria2Uri>(json);
            // Assert
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            // Arrange
            var json = "{\"uri\":\"http://example.com/file\",\"status\":\"used\"}";
            // Act
            var result = Serializer.Deserialize<Aria2Uri>(json);
            // Assert
            result.Should().NotBeNull();
            result.Uri.Should().Be("http://example.com/file");
            result.Status.Should().Be(UriStatusOptions.Used);
        }
    }
}
