using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class UriSelectorOptionsTests
    {
        [Theory]
        [InlineData("inorder", UriSelectorOptions.Inorder)]
        [InlineData("feedback", UriSelectorOptions.Feedback)]
        [InlineData("adaptive", UriSelectorOptions.Adaptive)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, UriSelectorOptions expected)
        {
            JsonSerializer.Deserialize<UriSelectorOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
