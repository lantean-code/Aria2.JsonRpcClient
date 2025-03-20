using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2FileTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            // Arrange
            var json = "InvalidJson";
            // Act
            Action act = () => Serializer.Deserialize<Aria2File>(json);
            // Assert
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            // Arrange
            // All primitive properties are provided as strings.
            // The "uris" property is an array populated with one sample Aria2Uri object.
            var json = "{\"index\":\"1\",\"path\":\"some/file/path.txt\",\"length\":\"123456\",\"completedLength\":\"654321\",\"selected\":\"true\",\"uris\":[{\"uri\":\"http://example.com/file\",\"status\":\"used\"}]}";
            // Act
            var result = Serializer.Deserialize<Aria2File>(json);
            // Assert
            result.Should().NotBeNull();
            result.Index.Should().Be(1);
            result.Path.Should().Be("some/file/path.txt");
            result.Length.Should().Be(123456L);
            result.CompletedLength.Should().Be(654321L);
            result.Selected.Should().BeTrue();
            result.Uris.Should().NotBeNull();
            result.Uris.Should().HaveCount(1);
            result.Uris[0].Uri.Should().Be("http://example.com/file");
            result.Uris[0].Status.Should().Be(UriStatusOptions.Used);
        }
    }
}
