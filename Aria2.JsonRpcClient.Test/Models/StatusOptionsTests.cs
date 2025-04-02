using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class StatusOptionsTests
    {
        [Theory]
        [InlineData("active", StatusOptions.Active)]
        [InlineData("waiting", StatusOptions.Waiting)]
        [InlineData("paused", StatusOptions.Paused)]
        [InlineData("error", StatusOptions.Error)]
        [InlineData("complete", StatusOptions.Complete)]
        [InlineData("removed", StatusOptions.Removed)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, StatusOptions expected)
        {
            Serializer.Deserialize<StatusOptions>($"\"{input}\"").Should().Be(expected);
        }
    }
}
