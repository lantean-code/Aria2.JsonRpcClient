using Moq;
using FluentAssertions;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientAddTorrentTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientAddTorrentTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidTorrent_WHEN_AddTorrent_THEN_ShouldPassAddTorrentRequestToHandler()
        {
            var expected = "result";
            var response = new JsonRpcResponse<string> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var torrent = "TorrentData";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.AddTorrent(torrent);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<string>(It.Is<AddTorrent>(r => r != null)), Times.Once());
        }
    }
}

