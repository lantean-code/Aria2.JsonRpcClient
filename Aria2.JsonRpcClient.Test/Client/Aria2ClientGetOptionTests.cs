using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetOptionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetOptionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_GetOption_THEN_ShouldPassGetOptionRequestToHandler()
        {
            var expected = new Aria2Options();
            var response = new JsonRpcResponse<Aria2Options> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2Options>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetOption(gid);

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2Options>(It.Is<GetOption>(r => r != null)), Times.Once());
        }
    }
}
