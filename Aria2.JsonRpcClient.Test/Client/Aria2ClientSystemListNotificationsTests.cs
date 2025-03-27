using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientSystemListNotificationsTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientSystemListNotificationsTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_SystemListNotifications_THEN_ShouldPassListNotificationsRequestToHandler()
        {
            var expected = new List<string> { "notification1" };
            var response = new JsonRpcResponse<IReadOnlyList<string>> { Result = expected.AsReadOnly(), Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<string>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.SystemListNotifications();

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<string>>(It.Is<ListNotifications>(r => r != null)), Times.Once());
        }
    }
}
