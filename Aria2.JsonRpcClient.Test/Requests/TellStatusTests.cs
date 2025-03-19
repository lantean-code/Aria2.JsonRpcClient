using FluentAssertions;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class TellStatusTests
    {
        [Fact]
        public void GIVEN_WithGidWithoutKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var target = new TellStatus("gid123");

            target.Method.Should().Be("aria2.tellStatus");
            target.Parameters.Should().HaveCount(2);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().BeNull();
            
        }

        [Fact]
        public void GIVEN_WithGidAndKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var keys = new[] { "key1", "key2" };
            var target = new TellStatus("gid123", keys, "testId");

            target.Method.Should().Be("aria2.tellStatus");
            target.Parameters.Should().HaveCount(2);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().BeEquivalentTo(keys);
            target.Id.Should().Be("testId");
        }
    }
}
