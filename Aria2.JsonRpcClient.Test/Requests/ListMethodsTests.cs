using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class ListMethodsTests
    {
        [Fact]
        public void GIVEN_WithoutId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndEmptyParameters()
        {
            var target = new SystemListMethods();

            target.Method.Should().Be("system.listMethods");
            target.Parameters.Should().BeEquivalentTo(JsonRpcParameters.Empty);
        }

        [Fact]
        public void GIVEN_WithId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndEmptyParametersAndId()
        {
            var target = new SystemListMethods("testId");

            target.Method.Should().Be("system.listMethods");
            target.Parameters.Should().BeEquivalentTo(JsonRpcParameters.Empty);
            target.Id.Should().Be("testId");
        }
    }
}
