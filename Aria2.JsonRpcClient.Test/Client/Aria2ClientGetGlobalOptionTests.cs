using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetGlobalOptionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetGlobalOptionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_GetGlobalOption_THEN_ShouldPassGetGlobalOptionRequestToHandler()
        {
            var expected = new Dictionary<string, string?> { { "key", "value" } };
            var response = new JsonRpcResponse<IReadOnlyDictionary<string, string?>> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyDictionary<string, string?>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetGlobalOption();

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyDictionary<string, string?>>(It.Is<GetGlobalOption>(r => r != null)), Times.Once());
        }
    }
}
