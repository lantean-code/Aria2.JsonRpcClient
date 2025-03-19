using FluentAssertions;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class RemoveDownloadResultTests
    {
        [Fact]
        public void GIVEN_WithGid_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameter()
        {
            var target = new RemoveDownloadResult("gid123");

            target.Method.Should().Be("aria2.removeDownloadResult");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().Be("gid123");
            
        }

        [Fact]
        public void GIVEN_WithGidAndId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectParametersAndId()
        {
            var target = new RemoveDownloadResult("gid123", "testId");

            target.Method.Should().Be("aria2.removeDownloadResult");
            target.Parameters.Should().HaveCount(1);
            target.Parameters[0].Should().Be("gid123");
            target.Id.Should().Be("testId");
        }
    }
}
