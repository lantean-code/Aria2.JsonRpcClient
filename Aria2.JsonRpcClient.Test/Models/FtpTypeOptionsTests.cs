using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class FtpTypeOptionsTests
    {
        [Theory]
        [InlineData("binary", FtpTypeOptions.Binary)]
        [InlineData("ascii", FtpTypeOptions.Ascii)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, FtpTypeOptions expected)
        {
            JsonSerializer.Deserialize<FtpTypeOptions>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
