using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class StreamPieceSelectorOptionsTests
    {
        [Theory]
        [InlineData("default", StreamPieceSelectorOptions.Default)]
        [InlineData("inorder", StreamPieceSelectorOptions.Inorder)]
        [InlineData("random", StreamPieceSelectorOptions.Random)]
        [InlineData("geom", StreamPieceSelectorOptions.Geom)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, StreamPieceSelectorOptions expected)
        {
            JsonSerializer.Deserialize<StreamPieceSelectorOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
