using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientChangePositionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientChangePositionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidParameters_WHEN_ChangePosition_THEN_ShouldPassChangePositionRequestToHandler()
        {
            var expected = 1;
            var response = new JsonRpcResponse<int> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";
            var pos = 2;
            var how = "how";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<int>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.ChangePosition(gid, pos, how);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<int>(It.Is<ChangePosition>(r => r != null)), Times.Once());
        }
    }
}
