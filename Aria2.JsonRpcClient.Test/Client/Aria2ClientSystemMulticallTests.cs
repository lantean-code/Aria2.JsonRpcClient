using Moq;
using FluentAssertions;
using System.Text.Json;
using Aria2.JsonRpcClient.Requests;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientSystemMulticallTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly INotificationHandler _notificationHandler = Mock.Of<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientSystemMulticallTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler);
        }

        [Fact]
        public async Task GIVEN_MethodsArray_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var expected = new List<object?> { new object[] { "result" } };
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<JsonElement[]>>
            {
                Result = new List<JsonElement[]>
                {
                    new JsonElement[] { JsonDocument.Parse("[\"result\"]").RootElement }
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new ListMethods() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<JsonElement[]>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<JsonElement[]>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }
    }
}
