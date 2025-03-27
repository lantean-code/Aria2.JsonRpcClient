using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientUnpauseAllTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientUnpauseAllTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoGid_WHEN_UnpauseAll_THEN_ShouldPassUnpauseAllRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.UnpauseAll();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<UnpauseAll>(r => r != null)), Times.Once());
        }
    }
}
