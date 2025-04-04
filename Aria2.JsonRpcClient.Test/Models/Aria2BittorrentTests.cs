using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2BittorrentTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            // Arrange
            var json = "InvalidJson";
            // Act
            var act = () => Serializer.Deserialize<Aria2Bittorrent>(json);
            // Assert
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{ \"announceList\": [[\"test\"]], \"comment\": \"comment\", \"creationDate\": \"946684800\", \"mode\": \"single\", \"info\": null }";

            var result = Serializer.Deserialize<Aria2Bittorrent>(json);

            result.Should().NotBeNull();

            result.AnnounceList.Should().NotBeNull();
            result.AnnounceList.Should().HaveCount(1);
            result.AnnounceList[0][0].Should().Be("test");

            result.Comment.Should().Be("comment");
            result.CreationDate.Should().Be(946684800);
            result.Mode.Should().Be(TorrentModeOptions.Single);
            result.Info.Should().BeNull();
        }
    }
}
