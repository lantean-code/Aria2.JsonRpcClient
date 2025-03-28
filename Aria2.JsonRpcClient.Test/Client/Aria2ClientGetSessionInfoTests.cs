using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetSessionInfoTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetSessionInfoTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_GetSessionInfo_THEN_ShouldPassGetSessionInfoRequestToHandler()
        {
            var expected = new Aria2SessionInfo
            {
                SessionId = "SessionId",
            };

            var response = new JsonRpcResponse<Aria2SessionInfo> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2SessionInfo>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetSessionInfo();

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2SessionInfo>(It.Is<GetSessionInfo>(r => r != null)), Times.Once());
        }
    }
}
