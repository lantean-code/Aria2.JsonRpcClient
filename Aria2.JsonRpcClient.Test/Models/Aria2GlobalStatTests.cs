using System;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2GlobalStatTests
    {
        [Fact]
        public void GIVEN_InvalidJson_WHEN_Deserializing_THEN_ShouldThrowJsonException()
        {
            var json = "InvalidJson";

            Action act = () => JsonSerializer.Deserialize<Aria2GlobalStat>(json, Aria2ClientSerialization.Options);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void GIVEN_ValidJson_WHEN_Deserializing_THEN_ShouldReturnObject()
        {
            var json = "{\"downloadSpeed\":\"1024\",\"uploadSpeed\":\"512\",\"numActive\":\"5\",\"numWaiting\":\"3\",\"numStopped\":\"2\",\"numStoppedTotal\":\"4\"}";

            var result = JsonSerializer.Deserialize<Aria2GlobalStat>(json, Aria2ClientSerialization.Options);

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
