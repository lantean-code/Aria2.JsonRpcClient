using System.Text.Json;
using FluentAssertions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2StatusTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2Status>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"gid\":\"gid123\",\"status\":\"active\",\"totalLength\":\"100000\",\"completedLength\":\"50000\",\"uploadLength\":\"10000\",\"bitfield\":\"ff00\",\"downloadSpeed\":\"1024\",\"uploadSpeed\":\"512\",\"infoHash\":\"infohash123\",\"numSeeders\":\"8\",\"seeder\":\"true\",\"pieceLength\":\"4096\",\"numPieces\":\"25\",\"connections\":\"4\",\"errorCode\":\"0\",\"errorMessage\":\"No error\",\"followedBy\":[\"gid456\"],\"following\":\"gid789\",\"belongsTo\":\"gid101\",\"dir\":\"/downloads\",\"files\":[{\"index\":\"1\",\"path\":\"file.txt\",\"length\":\"123\",\"completedLength\":\"123\",\"selected\":\"true\",\"uris\":[{\"uri\":\"http://example.com/file\",\"status\":\"used\"}]}],\"bittorrent\":null,\"verifiedLength\":\"60000\",\"verifyIntegrityPending\":\"false\"}";

            var result = JsonSerializer.Deserialize<Aria2Status>(json, Aria2ClientSerialization.Options);

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
    }
}
