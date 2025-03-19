using Aria2.JsonRpcClient.Requests;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientPurgeDownloadResultTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientPurgeDownloadResultTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_PurgeDownloadResult_THEN_ShouldPassPurgeDownloadResultRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.PurgeDownloadResult();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<PurgeDownloadResult>(r => r != null)), Times.Once());
        }
    }
}
