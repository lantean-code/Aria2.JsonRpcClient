using System.Text.Json;
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Moq;

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

        private record CustomObject
        {
            [JsonPropertyName("value")]
            public required string Value { get; set; }
        }

        private record CustomJsonRequest : JsonRpcRequest<CustomObject>
        {
            public CustomJsonRequest() : base("CustomRequest", [])
            {
            }
        }

        [Fact]
        public async Task GIVEN_RequestWithTypeResponseWithNoTypeInfo_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<object>>
            {
                Result = new List<object>
                {
                    JsonDocument.Parse("[{ \"value\": \"val\" }]").RootElement
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new CustomJsonRequest() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<object>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().HaveCount(1);
            var customObject = result[0].Should().BeOfType<CustomObject>().Subject;
            customObject.Value.Should().Be("val");

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<object>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_RequestWithTypeResponse_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var expected = new List<object?> { new object[] { "result" } };
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<object>>
            {
                Result = new List<object>
                {
                    JsonDocument.Parse("[[\"result\"]]").RootElement
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new ListMethods() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<object>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<object>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_RequestWithVoidResponse_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var expected = new List<object?> { null };
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<object>>
            {
                Result = new List<object>
                {
                    new JsonElement {  }
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new PauseAll() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<object>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().BeEquivalentTo(expected);

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<object>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }
    }
}
