using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientGetGlobalStatTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientGetGlobalStatTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_NoId_WHEN_GetGlobalStat_THEN_ShouldPassGetGlobalStatRequestToHandler()
        {
            var expected = new Aria2GlobalStat { };
            var response = new JsonRpcResponse<Aria2GlobalStat> { Result = expected, Error = null, Id = "Id", JsonRpc = "JsonRpc" };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<Aria2GlobalStat>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(response);

            var result = await _target.GetGlobalStat();

            result.Should().BeSameAs(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<Aria2GlobalStat>(It.Is<GetGlobalStat>(r => r != null)), Times.Once());
        }
    }
}
