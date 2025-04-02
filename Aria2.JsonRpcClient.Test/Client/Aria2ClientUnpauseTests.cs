using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientUnpauseTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientUnpauseTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_Unpause_THEN_ShouldPassUnpauseRequestToHandler()
        {
            var expected = "result";
            var response = new JsonRpcResponse<string> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.Unpause(gid);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<string>(It.Is<Unpause>(r => r != null)), Times.Once());
        }
    }
}
