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
            Serializer.Deserialize<UriStatusOptions>($"\"{input}\"").Should().Be(expected);
        }
    }
}
