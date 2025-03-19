using Moq;
using FluentAssertions;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientTellWaitingTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientTellWaitingTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidOffsetAndNum_WHEN_TellWaiting_THEN_ShouldPassTellWaitingRequestToHandler()
        {
            var expected = new List<Aria2Status> { new Aria2Status() };
            var response = new JsonRpcResponse<IReadOnlyList<Aria2Status>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var offset = 0;
            var num = 1;

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<Aria2Status>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.TellWaiting(offset, num);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<Aria2Status>>(It.Is<TellWaiting>(r => r != null)), Times.Once());
        }
    }
}
