using System;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Aria2.JsonRpcClient.Models;

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
            Action act = () => JsonSerializer.Deserialize<Aria2Uri>(json, Aria2ClientSerialization.Options);
            // Assert
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            // Arrange
            var json = "{\"uri\":\"http://example.com/file\",\"status\":\"used\"}";
            // Act
            var result = JsonSerializer.Deserialize<Aria2Uri>(json, Aria2ClientSerialization.Options);
            // Assert
            result.Should().NotBeNull();
            result.Uri.Should().Be("http://example.com/file");
            result.Status.Should().Be(UriStatusOptions.Used);
        }
    }
}
