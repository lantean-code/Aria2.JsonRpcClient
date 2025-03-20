using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class AddTorrentTests
    {
        [Fact]
        public void GIVEN_WithTorrent_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectName()
        {
            var target = new AddTorrent("TorrentData");

            target.Method.Should().Be("aria2.addTorrent");
            target.Parameters[0].Should().Be("TorrentData");
        }

        [Fact]
        public void GIVEN_WithTorrentAndOptions_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndOptions()
        {
            var target = new AddTorrent("TorrentData", new Aria2DownloadOptions { Dir = "Dir" });

            target.Method.Should().Be("aria2.addTorrent");
            target.Parameters[0].Should().Be("TorrentData");
            target.Parameters[1].Should().BeEquivalentTo(new { Dir = "Dir" });
        }

        [Fact]
        public void GIVEN_WithTorrentAndPosition_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var target = new AddTorrent("TorrentData", position: 5);

            target.Method.Should().Be("aria2.addTorrent");
            target.Parameters[0].Should().Be("TorrentData");
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().Be(5);
        }

        [Fact]
        public void GIVEN_WithTorrentAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var target = new AddTorrent("TorrentData", id: "id");

            target.Method.Should().Be("aria2.addTorrent");
            target.Parameters[0].Should().Be("TorrentData");
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().BeNull();
            target.Id.Should().Be("id");
        }
    }
}
