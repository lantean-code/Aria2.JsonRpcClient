using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetVersionTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetVersionTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_GetVersion_THEN_ShouldPassGetVersionRequestToHandler()
        {
            var expected = new Aria2Version
            {
                Version = "Version",
                EnabledFeatures = []
            };

            var response = new JsonRpcResponse<Aria2Version> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2Version>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetVersion();

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2Version>(It.Is<GetVersion>(r => r != null)), Times.Once());
        }
    }
}
