using Moq;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientPauseAllTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientPauseAllTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoGid_WHEN_PauseAll_THEN_ShouldPassPauseAllRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.PauseAll();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<PauseAll>(r => r != null)), Times.Once());
        }
    }
}


