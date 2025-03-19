using Aria2.JsonRpcClient.Requests;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientSaveSessionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientSaveSessionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_SaveSession_THEN_ShouldPassSaveSessionRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.SaveSession();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<SaveSession>(r => r != null)), Times.Once());
        }
    }
}
