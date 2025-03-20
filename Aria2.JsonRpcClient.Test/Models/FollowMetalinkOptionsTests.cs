using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class FollowMetalinkOptionsTests
    {
        [Theory]
        [InlineData("true", FollowMetalinkOptions.True)]
        [InlineData("false", FollowMetalinkOptions.False)]
        [InlineData("mem", FollowMetalinkOptions.Mem)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, FollowMetalinkOptions expected)
        {
            Serializer.Deserialize<FollowMetalinkOptions>($"\"{input}\"").Should().Be(expected);
        }
    }
}
