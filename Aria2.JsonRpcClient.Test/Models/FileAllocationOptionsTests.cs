using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class FileAllocationOptionsTests
    {
        [Theory]
        [InlineData("none", FileAllocationOptions.None)]
        [InlineData("prealloc", FileAllocationOptions.Prealloc)]
        [InlineData("trunc", FileAllocationOptions.Trunc)]
        [InlineData("falloc", FileAllocationOptions.Falloc)]
        public void GIVEN_Input_WHEN_Deserializing_THEN_ShouldReturnExpected(string input, FileAllocationOptions expected)
        {
            Serializer.Deserialize<FileAllocationOptions>($"\"{input}\"").Should().Be(expected);
        }
    }
}
