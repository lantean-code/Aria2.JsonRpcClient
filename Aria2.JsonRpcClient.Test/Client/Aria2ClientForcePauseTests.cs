using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientForcePauseTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientForcePauseTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_ForcePause_THEN_ShouldPassForcePauseRequestToHandler()
        {
            var expected = "result";
            var response = new JsonRpcResponse<string> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.ForcePause(gid);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<string>(It.Is<ForcePause>(r => r != null)), Times.Once());
        }
    }
}
