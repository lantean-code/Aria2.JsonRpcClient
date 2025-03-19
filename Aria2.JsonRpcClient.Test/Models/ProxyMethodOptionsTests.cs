using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class ProxyMethodOptionsTests
    {
        [Theory]
        [InlineData("get", ProxyMethodOptions.Get)]
        [InlineData("tunnel", ProxyMethodOptions.Tunnel)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, ProxyMethodOptions expected)
        {
            JsonSerializer.Deserialize<ProxyMethodOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
