using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class ChangePositionTests
    {
        [Fact]
        public void GIVEN_WithGidPosHow_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var target = new ChangePosition("gid123", 10, "up");

            target.Method.Should().Be("aria2.changePosition");
            target.Parameters.Should().HaveCount(3);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().Be(10);
            target.Parameters[2].Should().Be("up");
            
        }

        [Fact]
        public void GIVEN_WithGidPosHowAndId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var target = new ChangePosition("gid123", 10, "up", id: "testId");

            target.Method.Should().Be("aria2.changePosition");
            target.Parameters.Should().HaveCount(3);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().Be(10);
            target.Parameters[2].Should().Be("up");
            target.Id.Should().Be("testId");
        }
    }
}
