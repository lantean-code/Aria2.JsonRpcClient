using System;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2TorrentInfoTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2TorrentInfo>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"name\":\"sample torrent\"}";

            var result = JsonSerializer.Deserialize<Aria2TorrentInfo>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.Name.Should().Be("sample torrent");
        }
    }
}
