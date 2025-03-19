using Moq;
using FluentAssertions;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientAddUriTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientAddUriTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_ValidUris_WHEN_AddUri_THEN_ShouldPassAddUriRequestToHandler()
        {
            var expected = "result";
            var response = new JsonRpcResponse<string> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };
            var uris = new[] { "Uri1" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<string>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.AddUri(uris);

            result.Should().Be(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<string>(It.Is<AddUri>(r => r != null)), Times.Once());
        }
    }
}

