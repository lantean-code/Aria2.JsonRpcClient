using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class BtMinCryptoLevelOptionsTests
    {
        [Theory]
        [InlineData("plain", BtMinCryptoLevelOptions.Plain)]
        [InlineData("arc4", BtMinCryptoLevelOptions.Arc4)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, BtMinCryptoLevelOptions expected)
        {
            JsonSerializer.Deserialize<BtMinCryptoLevelOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
