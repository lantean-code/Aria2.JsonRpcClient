using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetServersTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetServersTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_GetServers_THEN_ShouldPassGetServersRequestToHandler()
        {
            var expected = new List<Aria2Server>
            {
                new Aria2Server
                {
                    Servers = []
                }
            };
            var response = new JsonRpcResponse<IReadOnlyList<Aria2Server>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<Aria2Server>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetServers(gid);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<Aria2Server>>(It.Is<GetServers>(r => r != null)), Times.Once());
        }
    }
}
