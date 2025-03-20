using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2GlobalStatTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => Serializer.Deserialize<Aria2GlobalStat>(json);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"downloadSpeed\":\"1024\",\"uploadSpeed\":\"512\",\"numActive\":\"5\",\"numWaiting\":\"3\",\"numStopped\":\"2\",\"numStoppedTotal\":\"4\"}";

            var result = Serializer.Deserialize<Aria2GlobalStat>(json);

            result.Should().NotBeNull();

            result.DownloadSpeed.Should().Be(1024);
            result.UploadSpeed.Should().Be(512);
            result.NumActive.Should().Be(5);
            result.NumWaiting.Should().Be(3);
            result.NumStopped.Should().Be(2);
            result.NumStoppedTotal.Should().Be(4);
        }
    }
}
