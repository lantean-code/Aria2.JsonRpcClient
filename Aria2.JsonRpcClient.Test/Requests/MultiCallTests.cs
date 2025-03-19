using FluentAssertions;
using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class MultiCallTests
    {
        [Fact]
        public void GIVEN_WithRequests_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndMappedParameters()
        {
            var dummyRequest = new Pause("gidDummy");
            var requests = new JsonRpcRequest[] { dummyRequest };
            var target = new MultiCall(requests);

            target.Method.Should().Be("system.multicall");
            target.Parameters.Should().HaveCount(1);

            // The first parameter should be an array of SystemMulticallRequest objects mapped from the input requests.
            var multicallArray = target.Parameters[0] as SystemMulticallRequest[];
            multicallArray.Should().NotBeNull();
            multicallArray.Should().HaveCount(1);
            multicallArray[0].MethodName.Should().Be(dummyRequest.Method);
            multicallArray[0].Parameters.Should().BeEquivalentTo(dummyRequest.Parameters);
        }

        [Fact]
        public void GIVEN_WithRequestsAndId_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndMappedParametersAndId()
        {
            var dummyRequest = new Pause("gidDummy");
            var requests = new JsonRpcRequest[] { dummyRequest };
            var target = new MultiCall(requests, "testId");

            target.Method.Should().Be("system.multicall");
            target.Parameters.Should().HaveCount(1);

            var multicallArray = target.Parameters[0] as SystemMulticallRequest[];
            multicallArray.Should().NotBeNull();
            multicallArray.Should().HaveCount(1);
            multicallArray[0].MethodName.Should().Be(dummyRequest.Method);
            multicallArray[0].Parameters.Should().BeEquivalentTo(dummyRequest.Parameters);
            target.Id.Should().Be("testId");
        }
    }
}
