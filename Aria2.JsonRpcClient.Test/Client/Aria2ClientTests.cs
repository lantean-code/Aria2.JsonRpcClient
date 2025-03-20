using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly Mock<INotificationHandler> _notificationHandler = new Mock<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler.Object);
        }

        private record TestVoidRequest : JsonRpcRequest
        {
            public TestVoidRequest() : base("testMethod", [])
            {
            }

            public override Type ReturnType => typeof(string);
        }

        private record TestStringRequest : JsonRpcRequest<string>
        {
            public TestStringRequest() : base("testMethod", [])
            {
            }

            public override Type ReturnType => typeof(void);
        }

        private record ValidVoidRequest : JsonRpcRequest
        {
            public ValidVoidRequest() : base("testMethod", [])
            {
            }
        }

        private record ValidStringRequest : JsonRpcRequest<string>
        {
            public ValidStringRequest() : base("testMethod", [])
            {
            }
        }

        [Fact]
        public async Task GIVEN_RequestReturningVoidWithInvalidResponseType_WHEN_ExecutingRequest_SHOULD_Throw()
        {
            var request = new TestVoidRequest();
            Func<Task> act = async () => await _target.ExecuteRequest(request);
            var throwAsync = act.Should().ThrowAsync<ArgumentException>();
#if NET8_0_OR_GREATER
            await throwAsync.WithMessage("The return type of the request is not void. (Parameter 'request')");
#else
            await throwAsync.WithMessage("The return type of the request is not void.\n\nParameter name: request");
#endif
        }

        [Fact]
        public async Task GIVEN_RequestReturningStringWithInvalidResponseType_WHEN_ExecutingRequest_SHOULD_Throw()
        {
            var request = new TestStringRequest();
            Func<Task> act = async () => await _target.ExecuteRequest<string>(request);
            var throwAsync = act.Should().ThrowAsync<ArgumentException>();
#if NET8_0_OR_GREATER
            await throwAsync.WithMessage("The return type of the request does not match the specified type. (Parameter 'request')");
#else
            await throwAsync.WithMessage("The return type of the request does not match the specified type.\n\nParameter name: request");
#endif
        }

        [Fact]
        public async Task GIVEN_ValidVoidRequestReturnsError_WHEN_ExecutingRequest_THEN_ShouldThrowAria2Exception()
        {
            var response = new JsonRpcResponse
            {
                Id = "Id",
                JsonRpc = "JsonRpc",
                Error = new JsonRpcError { Code = 1, Message = "Error" }
            };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            Func<Task> act = () => _target.ExecuteRequest(new ValidVoidRequest());

            var x = await act.Should().ThrowAsync<Aria2Exception>().WithMessage("Error");
            x.Which.Code.Should().Be(1);
        }

        [Fact]
        public async Task GIVEN_ValidStringRequestReturnsError_WHEN_ExecutingRequest_THEN_ShouldThrowAria2Exception()
        {
            var response = new JsonRpcResponse<string>
            {
                Id = "Id",
                JsonRpc = "JsonRpc",
                Error = new JsonRpcError { Code = 1, Message = "Error" }
            };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            Func<Task> act = () => _target.ExecuteRequest<string>(new ValidStringRequest());

            var x = await act.Should().ThrowAsync<Aria2Exception>().WithMessage("Error");
            x.Which.Code.Should().Be(1);
        }

        [Fact]
        public async Task GIVEN_ValidStringRequestReturnsNullResult_WHEN_ExecutingRequest_THEN_ShouldThrowInvalidOperationException()
        {
            var response = new JsonRpcResponse<string>
            {
                Id = "Id",
                JsonRpc = "JsonRpc",
                Result = null
            };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            Func<Task> act = () => _target.ExecuteRequest<string>(new ValidStringRequest());

            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("Invalid JSON-RPC response.");
        }

        [Fact]
        public void GIVEN_OnDownloadStartedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadStarted()
        {
            string? received = null;
            _target.DownloadStarted += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadStarted += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadPausedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadPaused()
        {
            string? received = null;
            _target.DownloadPaused += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadPaused += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadStoppedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadStopped()
        {
            string? received = null;
            _target.DownloadStopped += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadStopped += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadCompleteEvent_WHEN_Raised_THEN_ShouldInvokeDownloadComplete()
        {
            string? received = null;
            _target.DownloadComplete += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadComplete += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadErrorEvent_WHEN_Raised_THEN_ShouldInvokeDownloadError()
        {
            string? received = null;
            _target.DownloadError += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadError += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnBtDownloadCompleteEvent_WHEN_Raised_THEN_ShouldInvokeBtDownloadComplete()
        {
            string? received = null;
            _target.BtDownloadComplete += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnBtDownloadComplete += null, testGid);

            received.Should().Be(testGid);
        }
    }
}
