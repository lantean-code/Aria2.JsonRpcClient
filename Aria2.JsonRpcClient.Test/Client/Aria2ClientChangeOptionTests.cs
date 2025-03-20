using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientChangeOptionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientChangeOptionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidParameters_WHEN_ChangeOption_THEN_ShouldPassChangeOptionRequestToHandler()
        {
            var options = new Aria2DownloadOptions();
            var response = new JsonRpcResponse { Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            await _target.ChangeOption(gid, options);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest(It.Is<ChangeOption>(r => r != null)), Times.Once());
        }
    }
}
