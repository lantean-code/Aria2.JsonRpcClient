using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class ChangeOptionTests
    {
        [Fact]
        public void GIVEN_WithGidAndOptions_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var options = new Aria2DownloadOptions { Dir = "MyDownloadDir" };
            var target = new ChangeOption("gid123", options);

            target.Method.Should().Be("aria2.changeOption");
            target.Parameters.Should().HaveCount(2);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().BeEquivalentTo(new { Dir = "MyDownloadDir" });
        }

        [Fact]
        public void GIVEN_WithGidOptionsAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var options = new Aria2DownloadOptions { Dir = "MyDownloadDir" };
            var target = new ChangeOption("gid123", options, id: "testId");

            target.Method.Should().Be("aria2.changeOption");
            target.Parameters.Should().HaveCount(2);
            target.Parameters[0].Should().Be("gid123");
            target.Parameters[1].Should().BeEquivalentTo(new { Dir = "MyDownloadDir" });
            target.Id.Should().Be("testId");
        }
    }
}
