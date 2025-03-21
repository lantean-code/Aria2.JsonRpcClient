using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class TellActiveTests
    {
        [Fact]
        public void GIVEN_WithoutKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndNullParameter()
        {
            var target = new TellActive();

            target.Method.Should().Be("aria2.tellActive");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().BeNull();
        }

        [Fact]
        public void GIVEN_WithKeys_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var keys = new[] { "key1", "key2" };
            var target = new TellActive(keys, "testId");

            target.Method.Should().Be("aria2.tellActive");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().BeEquivalentTo(keys);
            target.Id.Should().Be("testId");
        }

        [Fact]
        public void GIVEN_WithKeysSelector_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var keys = new[] { "dir", "following" };
            var target = new TellActive(a => new
            {
                a.Dir,
                a.Following
            }, "testId");

            target.Method.Should().Be("aria2.tellActive");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().BeEquivalentTo(keys);
            target.Id.Should().Be("testId");
        }
    }
}
