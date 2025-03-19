using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class TorrentModeOptionsTests
    {
        [Theory]
        [InlineData("single", TorrentModeOptions.Single)]
        [InlineData("multi", TorrentModeOptions.Multi)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, TorrentModeOptions expected)
        {
            JsonSerializer.Deserialize<TorrentModeOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
