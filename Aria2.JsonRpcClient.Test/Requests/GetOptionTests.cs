using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class GetOptionTests
    {
        [Fact]
        public void GIVEN_WithGid_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameter()
        {
            var target = new GetOption("gid123");

            target.Method.Should().Be("aria2.getOption");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().Be("gid123");
        }

        [Fact]
        public void GIVEN_WithGidAndId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var target = new GetOption("gid123", "testId");

            target.Method.Should().Be("aria2.getOption");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().Be("gid123");
            target.Id.Should().Be("testId");
        }
    }
}
