using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class TellWaitingTests
    {
        [Fact]
        public void GIVEN_WithOffsetAndNumWithoutKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var target = new TellWaiting(0, 10);

            target.Method.Should().Be("aria2.tellWaiting");
            target.Parameters.Should().HaveCount(3);
            target.Parameters[0].Should().Be(0);
            target.Parameters[1].Should().Be(10);
            target.Parameters[2].Should().BeNull();
        }

        [Fact]
        public void GIVEN_WithOffsetNumAndKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var keys = new[] { "key1", "key2" };
            var target = new TellWaiting(5, 15, keys, "testId");

            target.Method.Should().Be("aria2.tellWaiting");
            target.Parameters.Should().HaveCount(3);
            target.Parameters[0].Should().Be(5);
            target.Parameters[1].Should().Be(15);
            target.Parameters[2].Should().BeEquivalentTo(keys);
            target.Id.Should().Be("testId");
        }

        [Fact]
        public void GIVEN_WithOffsetNumAndKeysSelector_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var keys = new[] { "gid" };
            var target = new TellWaiting(5, 15, s => s.Gid, "testId");

            target.Method.Should().Be("aria2.tellWaiting");
            target.Parameters.Should().HaveCount(3);
            target.Parameters[0].Should().Be(5);
            target.Parameters[1].Should().Be(15);
            target.Parameters[2].Should().BeEquivalentTo(keys);
            target.Id.Should().Be("testId");
        }
    }
}
