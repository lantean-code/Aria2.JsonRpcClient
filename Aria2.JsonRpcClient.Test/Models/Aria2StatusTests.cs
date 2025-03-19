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
            // Arrange
            var json = "InvalidJson";
            // Act
            var act = () => JsonSerializer.Deserialize<Aria2Status>(json, Aria2ClientSerialization.Options);
            // Assert
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = " {\"bitfield\": \"0000000000\", \"completedLength\": \"901120\", \"connections\": \"1\", \"dir\": \"/downloads\", \"downloadSpeed\": \"15158\", \"files\": [{\"index\": \"1\", \"length\": \"34896138\", \"completedLength\": \"34896138\", \"path\": \"/downloads/file\", \"selected\": \"true\", \"uris\": [{\"status\": \"used\", \"uri\": \"http://example.org/file\"}]}], \"gid\": \"2089b05ecca3d829\", \"numPieces\": \"34\", \"pieceLength\": \"1048576\", \"status\": \"active\", \"totalLength\": \"34896138\", \"uploadLength\": \"0\", \"uploadSpeed\": \"0\"}";

            var result = JsonSerializer.Deserialize<Aria2Status>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.Bitfield.Should().Be("0000000000");
            result.CompletedLength.Should().Be(901120);
            result.Connections.Should().Be(1);
            result.Dir.Should().Be("/downloads");
            result.DownloadSpeed.Should().Be(15158);
            result.Files.Should().NotBeNull();
            result.Files.Should().HaveCount(1);
            result.Files[0].Index.Should().Be(1);
            result.Files[0].Length.Should().Be(34896138);
            result.Files[0].CompletedLength.Should().Be(34896138);
            result.Files[0].Path.Should().Be("/downloads/file");
            result.Files[0].Selected.Should().BeTrue();
            result.Files[0].Uris.Should().NotBeNull();
            result.Files[0].Uris.Should().HaveCount(1);
            result.Files[0].Uris![0].Status.Should().Be(UriStatusOptions.Used);
            result.Files[0].Uris![0].Uri.Should().Be("http://example.org/file");
            result.Gid.Should().Be("2089b05ecca3d829");
            result.NumPieces.Should().Be(34);
            result.PieceLength.Should().Be(1048576);
            result.Status.Should().Be(StatusOptions.Active);
            result.TotalLength.Should().Be(34896138);
            result.UploadLength.Should().Be(0);
            result.UploadSpeed.Should().Be(0);

        }
    }
}
