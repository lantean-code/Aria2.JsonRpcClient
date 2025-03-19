using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2PeerTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2Peer>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"peerId\":\"peer123\",\"ip\":\"192.168.1.50\",\"port\":\"6881\",\"bitfield\":\"ff00\",\"amChoking\":\"false\",\"peerChoking\":\"true\",\"downloadSpeed\":\"10240\",\"uploadSpeed\":\"5120\",\"seeder\":\"true\"}";

            var result = JsonSerializer.Deserialize<Aria2Peer>(json, Aria2ClientSerialization.Options);

            result.Should().NotBeNull();

            result.PeerId.Should().Be("peer123");
            result.Ip.Should().Be("192.168.1.50");
            result.Port.Should().Be(6881);
            result.Bitfield.Should().Be("ff00");
            result.AmChoking.Should().BeFalse();
            result.PeerChoking.Should().BeTrue();
            result.DownloadSpeed.Should().Be(10240);
            result.UploadSpeed.Should().Be(5120);
            result.Seeder.Should().BeTrue();
        }
    }
}
