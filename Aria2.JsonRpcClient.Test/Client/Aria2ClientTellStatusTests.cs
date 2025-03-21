using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientTellStatusTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientTellStatusTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_TellStatus_THEN_ShouldPassTellStatusRequestToHandler()
        {
            var expected = new Aria2Status();
            var response = new JsonRpcResponse<Aria2Status> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2Status>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.TellStatus(gid);

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2Status>(It.Is<TellStatus>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ValidGidWithKeysSelector_WHEN_TellStatus_THEN_ShouldPassTellStatusRequestToHandler()
        {
            var expected = new Aria2Status();
            var response = new JsonRpcResponse<Aria2Status> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2Status>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.TellStatus(gid, s => new { s.Gid });

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2Status>(It.Is<TellStatus>(r => r != null)), Times.Once());
        }
    }
}
