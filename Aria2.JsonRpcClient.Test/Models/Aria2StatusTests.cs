using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2StatusTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2Status>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"gid\":\"gid123\",\"status\":\"active\",\"totalLength\":\"100000\",\"completedLength\":\"50000\",\"uploadLength\":\"10000\",\"bitfield\":\"ff00\",\"downloadSpeed\":\"1024\",\"uploadSpeed\":\"512\",\"infoHash\":\"infohash123\",\"numSeeders\":\"8\",\"seeder\":\"true\",\"pieceLength\":\"4096\",\"numPieces\":\"25\",\"connections\":\"4\",\"errorCode\":\"0\",\"errorMessage\":\"No error\",\"followedBy\":[\"gid456\"],\"following\":\"gid789\",\"belongsTo\":\"gid101\",\"dir\":\"/downloads\",\"files\":[{\"index\":\"1\",\"path\":\"file.txt\",\"length\":\"123\",\"completedLength\":\"123\",\"selected\":\"true\",\"uris\":[{\"uri\":\"http://example.com/file\",\"status\":\"used\"}]}],\"bittorrent\":null,\"verifiedLength\":\"60000\",\"verifyIntegrityPending\":\"false\"}";

            var result = Serializer.Deserialize<Aria2Status>(json);

            result.Should().NotBeNull();

            result.Gid.Should().Be("gid123");

            result.Status.Should().Be(StatusOptions.Active);

            result.TotalLength.Should().Be(100000);
            result.CompletedLength.Should().Be(50000);
            result.UploadLength.Should().Be(10000);

            result.Bitfield.Should().Be("ff00");

            result.DownloadSpeed.Should().Be(1024);
            result.UploadSpeed.Should().Be(512);

            result.InfoHash.Should().Be("infohash123");

            result.NumSeeders.Should().Be(8);
            result.Seeder.Should().BeTrue();

            result.PieceLength.Should().Be(4096);
            result.NumPieces.Should().Be(25);

            result.Connections.Should().Be(4);

            result.ErrorCode.Should().Be(Aria2ErrorCode.Success);
            result.ErrorMessage.Should().Be("No error");

            result.FollowedBy.Should().NotBeNull();
            result.FollowedBy.Should().HaveCount(1);
            result.FollowedBy[0].Should().Be("gid456");

            result.Following.Should().Be("gid789");
            result.BelongsTo.Should().Be("gid101");

            result.Dir.Should().Be("/downloads");

            result.Files.Should().NotBeNull();
            result.Files.Should().HaveCount(1);
            result.Files[0].Index.Should().Be(1);
            result.Files[0].Path.Should().Be("file.txt");
            result.Files[0].Length.Should().Be(123);
            result.Files[0].CompletedLength.Should().Be(123);
            result.Files[0].Selected.Should().BeTrue();
            result.Files[0].Uris.Should().NotBeNull();
            result.Files[0].Uris.Should().HaveCount(1);
            result.Files[0].Uris![0].Uri.Should().Be("http://example.com/file");
            result.Files[0].Uris![0].Status.Should().Be(UriStatusOptions.Used);

            result.Bittorrent.Should().BeNull();

            result.VerifiedLength.Should().Be(60000);
            result.VerifyIntegrityPending.Should().BeFalse();
        }

        [Theory]
        [InlineData(nameof(Aria2Status.Keys.Gid), Aria2Status.Keys.Gid)]
        [InlineData(nameof(Aria2Status.Keys.Status), Aria2Status.Keys.Status)]
        [InlineData(nameof(Aria2Status.Keys.TotalLength), Aria2Status.Keys.TotalLength)]
        [InlineData(nameof(Aria2Status.Keys.CompletedLength), Aria2Status.Keys.CompletedLength)]
        [InlineData(nameof(Aria2Status.Keys.UploadLength), Aria2Status.Keys.UploadLength)]
        [InlineData(nameof(Aria2Status.Keys.Bitfield), Aria2Status.Keys.Bitfield)]
        [InlineData(nameof(Aria2Status.Keys.DownloadSpeed), Aria2Status.Keys.DownloadSpeed)]
        [InlineData(nameof(Aria2Status.Keys.UploadSpeed), Aria2Status.Keys.UploadSpeed)]
        [InlineData(nameof(Aria2Status.Keys.InfoHash), Aria2Status.Keys.InfoHash)]
        [InlineData(nameof(Aria2Status.Keys.NumSeeders), Aria2Status.Keys.NumSeeders)]
        [InlineData(nameof(Aria2Status.Keys.Seeder), Aria2Status.Keys.Seeder)]
        [InlineData(nameof(Aria2Status.Keys.PieceLength), Aria2Status.Keys.PieceLength)]
        [InlineData(nameof(Aria2Status.Keys.NumPieces), Aria2Status.Keys.NumPieces)]
        [InlineData(nameof(Aria2Status.Keys.Connections), Aria2Status.Keys.Connections)]
        [InlineData(nameof(Aria2Status.Keys.ErrorCode), Aria2Status.Keys.ErrorCode)]
        [InlineData(nameof(Aria2Status.Keys.ErrorMessage), Aria2Status.Keys.ErrorMessage)]
        [InlineData(nameof(Aria2Status.Keys.FollowedBy), Aria2Status.Keys.FollowedBy)]
        [InlineData(nameof(Aria2Status.Keys.Following), Aria2Status.Keys.Following)]
        [InlineData(nameof(Aria2Status.Keys.BelongsTo), Aria2Status.Keys.BelongsTo)]
        [InlineData(nameof(Aria2Status.Keys.Dir), Aria2Status.Keys.Dir)]
        [InlineData(nameof(Aria2Status.Keys.Files), Aria2Status.Keys.Files)]
        [InlineData(nameof(Aria2Status.Keys.Bittorrent), Aria2Status.Keys.Bittorrent)]
        [InlineData(nameof(Aria2Status.Keys.VerifiedLength), Aria2Status.Keys.VerifiedLength)]
        [InlineData(nameof(Aria2Status.Keys.VerifyIntegrityPending), Aria2Status.Keys.VerifyIntegrityPending)]
        public void GIVEN_InputPropertyName_WHEN_Matching_THEN_ShouldReturnCorrespondingKey(string name, string key)
        {
            var result = Aria2Status.Keys.Match(name);

            result.Should().NotBeNull();
            result.Should().Be(key);
        }
    }
}
