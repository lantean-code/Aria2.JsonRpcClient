using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class GetGlobalOptionTests
    {
        [Fact]
        public void GIVEN_WithoutId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndEmptyParameters()
        {
            var target = new GetGlobalOption();

            target.Method.Should().Be("aria2.getGlobalOption");
            target.Parameters.Should().BeEquivalentTo(JsonRpcParameters.Empty);
        }

        [Fact]
        public void GIVEN_WithId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndEmptyParametersAndId()
        {
            var target = new GetGlobalOption("testId");

            target.Method.Should().Be("aria2.getGlobalOption");
            target.Parameters.Should().BeEquivalentTo(JsonRpcParameters.Empty);
            target.Id.Should().Be("testId");
        }
    }
}
