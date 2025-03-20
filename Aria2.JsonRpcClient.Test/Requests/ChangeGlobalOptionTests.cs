using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class ChangeGlobalOptionTests
    {
        [Fact]
        public void GIVEN_WithOptions_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectName()
        {
            var options = new Aria2DownloadOptions { Dir = "MyDir" };
            var target = new ChangeGlobalOption(options);

            target.Method.Should().Be("aria2.changeGlobalOption");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().BeEquivalentTo(new { Dir = "MyDir" });
        }

        [Fact]
        public void GIVEN_WithOptionsAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var options = new Aria2DownloadOptions { Dir = "MyDir" };
            var target = new ChangeGlobalOption(options, id: "testId");

            target.Method.Should().Be("aria2.changeGlobalOption");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().BeEquivalentTo(new { Dir = "MyDir" });
            target.Id.Should().Be("testId");
        }
    }
}
