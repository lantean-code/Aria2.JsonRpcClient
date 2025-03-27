using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientRemoveDownloadResultTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientRemoveDownloadResultTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_RemoveDownloadResult_THEN_ShouldPassRemoveDownloadResultRequestToHandler()
        {
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.RemoveDownloadResult(gid);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<RemoveDownloadResult>(r => r != null)), Times.Once());
        }
    }
}
