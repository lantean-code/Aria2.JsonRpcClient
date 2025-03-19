using Moq;
using FluentAssertions;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientPauseTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientPauseTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_Pause_THEN_ShouldPassPauseRequestToHandler()
        {
            var expected = "result";
            var response = new JsonRpcResponse<string> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.Pause(gid);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<string>(It.Is<Pause>(r => r != null)), Times.Once());
        }
    }
}
