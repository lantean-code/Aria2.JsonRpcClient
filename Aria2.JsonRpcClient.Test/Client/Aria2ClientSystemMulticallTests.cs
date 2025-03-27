using System.Text.Json;
using System.Text.Json.Serialization;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
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
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<JsonElement>>
            {
                Result = new List<JsonElement>
                {
                    JsonDocument.Parse("[{ \"value\": \"val\" }]").RootElement
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new CustomJsonRequest() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().HaveCount(1);
            var customJsonElement = result[0].Should().BeOfType<CustomObject>().Subject;
            customJsonElement.Value.Should().Be("val");

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_RequestWithTypeResponse_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<JsonElement>>
            {
                Result = new List<JsonElement>
                {
                    JsonDocument.Parse("[[\"result\"]]").RootElement
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new ListMethods() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            var res = ListMethods.GetResult(result[0]);
            res.Should().NotBeNull();
            res.Should().HaveCount(1);
            res[0].Should().Be("result");

            result.Should().HaveCount(1);
            var value = result[0].Should().BeOfType<List<string>>().Subject;
            value.Should().HaveCount(1);
            value[0].Should().Be("result");

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_RequestWithVoidResponse_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<JsonElement>>
            {
                Result = new List<JsonElement>
                {
                    JsonDocument.Parse("[[]]").RootElement
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new PauseAll() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            result.Should().HaveCount(1);
            result[0].Should().BeNull();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }

        [Fact]
        public async Task GIVEN_RequestWithErrorResponse_WHEN_SystemMulticall_THEN_ShouldPassMultiCallRequestToHandler()
        {
            var jsonResponse = new JsonRpcResponse<IReadOnlyList<JsonElement>>
            {
                Result = new List<JsonElement>
                {
                    JsonDocument.Parse("{\"code\":-32600,\"message\":\"Invalid Request\",\"customKey\":\"customValue\"}").RootElement,
                }.AsReadOnly(),
                Error = null,
                Id = "Id",
                JsonRpc = "JsonRpc"
            };
            var methods = new JsonRpcRequest[] { new TellActive() };

            Mock.Get(_requestHandler)
                .Setup(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.IsAny<JsonRpcRequest>()))
                .ReturnsAsync(jsonResponse);

            var result = await _target.SystemMulticall(methods);

            var isError = TellActive.IsError(result[0], out var error);
            isError.Should().BeTrue();
            error.Should().NotBeNull();
            result[0].Should().BeOfType<JsonRpcError>();

            Mock.Get(_requestHandler)
                .Verify(x => x.SendRequest<IReadOnlyList<JsonElement>>(It.Is<MultiCall>(r => r != null)), Times.Once());
        }
    }
}
