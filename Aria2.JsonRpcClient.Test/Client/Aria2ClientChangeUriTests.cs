using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientChangeUriTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientChangeUriTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidParameters_WHEN_ChangeUri_THEN_ShouldPassChangeUriRequestToHandler()
        {
            var expected = new List<int> { 1, 2 };
            var response = new JsonRpcResponse<IReadOnlyList<int>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";
            var fileIndex = 0;
            var delUris = new List<string> { "del1" };
            var addUris = new List<string> { "add1" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<int>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.ChangeUri(gid, fileIndex, delUris, addUris);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<int>>(It.Is<ChangeUri>(r => r != null)), Times.Once());
        }
    }
}
