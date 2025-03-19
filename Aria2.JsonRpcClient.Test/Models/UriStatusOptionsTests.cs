using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class UriStatusOptionsTests
    {
        [Theory]
        [InlineData("used", UriStatusOptions.Used)]
        [InlineData("waiting", UriStatusOptions.Waiting)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, UriStatusOptions expected)
        {
            JsonSerializer.Deserialize<UriStatusOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
