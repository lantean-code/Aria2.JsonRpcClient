using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class ExtensionsTests
    {
        [Fact]
        public void GIVEN_NonMulticallRequestWithEmptyParameters_WHEN_EnsureSecretCalled_THEN_ShouldInsertSecret()
        {
            var request = new FakeJsonRpcRequest("download", []);

            request.EnsureSecret("mySecret");

            request.Parameters[0].Should().Be("token:mySecret");
        }

        [Fact]
        public void GIVEN_NonMulticallRequestWithNonStringFirstParameter_WHEN_EnsureSecretCalled_THEN_ShouldInsertSecret()
        {
            var request = new FakeJsonRpcRequest("download", [123, "other"]);

            request.EnsureSecret("mySecret");

            request.Parameters[0].Should().Be("token:mySecret");
        }

        [Fact]
        public void GIVEN_NonMulticallRequestWithFirstParameterNotStartingWithToken_WHEN_EnsureSecretCalled_THEN_ShouldInsertSecret()
        {
            var request = new FakeJsonRpcRequest("download", ["notToken", "other"]);

            request.EnsureSecret("mySecret");

            request.Parameters[0].Should().Be("token:mySecret");
        }

        [Fact]
        public void GIVEN_NonMulticallRequestWithExistingToken_WHEN_EnsureSecretCalled_THEN_ShouldNotChangeSecret()
        {
            var request = new FakeJsonRpcRequest("download", ["token:existing", "other"]);

            request.EnsureSecret("mySecret");

            request.Parameters[0].Should().Be("token:existing");
            request.Parameters.Count.Should().Be(2);
        }

        [Fact]
        public void GIVEN_MulticallRequestWithEmptyCallParameters_WHEN_EnsureSecretCalled_THEN_ShouldInsertSecretInEachCall()
        {
            var call1 = new SystemMulticallRequest { MethodName = "dummy", Parameters = JsonRpcParameters.Empty };
            var call2 = new SystemMulticallRequest { MethodName = "dummy", Parameters = JsonRpcParameters.Empty };
            var multicallArray = new SystemMulticallRequest[] { call1, call2 };
            var request = new FakeJsonRpcRequest("system.multicall", [multicallArray]);

            request.EnsureSecret("mySecret");

            call1.Parameters[0].Should().Be("token:mySecret");
            call2.Parameters[0].Should().Be("token:mySecret");
        }

        [Fact]
        public void GIVEN_MulticallRequestWithExistingToken_WHEN_EnsureSecretCalled_THEN_ShouldNotInsertSecretInCalls()
        {
            var call1 = new SystemMulticallRequest
            {
                MethodName = "dummy",
                Parameters = ["token:existing", "param"]
            };
            var multicallArray = new SystemMulticallRequest[] { call1 };
            var request = new FakeJsonRpcRequest("system.multicall", [multicallArray]);

            request.EnsureSecret("mySecret");

            call1.Parameters[0].Should().Be("token:existing");
            call1.Parameters.Count.Should().Be(2);
        }

        private record FakeJsonRpcRequest : JsonRpcRequest
        {
            public FakeJsonRpcRequest(string method, JsonRpcParameters parameters) : base(method, parameters)
            {
            }
        }
    }
}
