using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class AddMetalinkTests
    {
        [Fact]
        public void GIVEN_WithUri_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectName()
        {
            var target = new AddMetalink("Uri");
            target.Method.Should().Be("aria2.addMetalink");
            target.Parameters[0].Should().Be("Uri");
        }

        [Fact]
        public void GIVEN_WithUriAndOptions_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndOptions()
        {
            var target = new AddMetalink("Uri", new Aria2DownloadOptions { Dir = "Dir" });
            target.Method.Should().Be("aria2.addMetalink");
            target.Parameters[0].Should().Be("Uri");
            target.Parameters[1].Should().BeEquivalentTo(new { Dir = "Dir" });
        }

        [Fact]
        public void GIVEN_WithUriAndPosition_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var target = new AddMetalink("Uri", position: 5);
            target.Method.Should().Be("aria2.addMetalink");
            target.Parameters[0].Should().Be("Uri");
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().Be(5);
        }

        [Fact]
        public void GIVEN_WithUriAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var target = new AddMetalink("Uri", id: "id");
            target.Method.Should().Be("aria2.addMetalink");
            target.Parameters[0].Should().Be("Uri");
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().BeNull();
            target.Id.Should().Be("id");
        }
    }
}
