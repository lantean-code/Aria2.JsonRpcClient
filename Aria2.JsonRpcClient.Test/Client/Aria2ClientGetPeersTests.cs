using Moq;
using FluentAssertions;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetPeersTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetPeersTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_GetPeers_THEN_ShouldPassGetPeersRequestToHandler()
        {
            var expected = new List<Aria2Peer>
            {
                new Aria2Peer
                {
                    Ip = "Ip1",
                }
            };
            var response = new JsonRpcResponse<IReadOnlyList<Aria2Peer>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<Aria2Peer>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetPeers(gid);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<Aria2Peer>>(It.Is<GetPeers>(r => r != null)), Times.Once());
        }
    }
}

