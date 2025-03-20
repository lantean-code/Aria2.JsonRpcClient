using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class MetalinkPreferredProtocolOptionsTests
    {
        [Theory]
        [InlineData("http", MetalinkPreferredProtocolOptions.Http)]
        [InlineData("https", MetalinkPreferredProtocolOptions.Https)]
        [InlineData("ftp", MetalinkPreferredProtocolOptions.Ftp)]
        [InlineData("none", MetalinkPreferredProtocolOptions.None)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, MetalinkPreferredProtocolOptions expected)
        {
            Serializer.Deserialize<MetalinkPreferredProtocolOptions>($"\"{input}\"").Should().Be(expected);
        }
    }
}
