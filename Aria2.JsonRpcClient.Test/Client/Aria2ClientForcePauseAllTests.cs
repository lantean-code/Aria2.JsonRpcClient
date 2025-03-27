using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientForcePauseAllTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientForcePauseAllTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoGid_WHEN_ForcePauseAll_THEN_ShouldPassForcePauseAllRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.ForcePauseAll();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<ForcePauseAll>(r => r != null)), Times.Once());
        }
    }
}
