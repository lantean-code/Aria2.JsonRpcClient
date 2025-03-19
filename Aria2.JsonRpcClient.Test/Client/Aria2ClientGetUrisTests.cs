using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetUrisTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetUrisTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidGid_WHEN_GetUris_THEN_ShouldPassGetUrisRequestToHandler()
        {
            var expected = new List<Aria2Uri>
            {
                new Aria2Uri
                {
                    Uri = "Uri1",
                }
            };
            var response = new JsonRpcResponse<IReadOnlyList<Aria2Uri>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var gid = "Gid1";

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<Aria2Uri>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetUris(gid);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<Aria2Uri>>(It.Is<GetUris>(r => r != null)), Times.Once());
        }
    }
}
