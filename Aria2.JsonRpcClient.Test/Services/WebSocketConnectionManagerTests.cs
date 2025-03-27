using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Aria2.JsonRpcClient.Requests;
using Aria2.JsonRpcClient.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Polly;
using Polly.Registry;

namespace Aria2.JsonRpcClient.Test.Services
{
    public class WebSocketConnectionManagerTests
    {
        private WebSocketConnectionManager CreateManager(Mock<IClientWebSocketManager> webSocketMock)
        {
            var options = Options.Create(new Aria2ClientOptions { Host = "localhost", Port = 1234, Secret = "secret" });
            return new WebSocketConnectionManager(webSocketMock.Object, options);
        }

        private static JsonElement CreateJsonElement(string json)
        {
            using var document = JsonDocument.Parse(json);
            return document.RootElement.Clone();
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendRequestGeneric_THEN_ShouldReturnDeserializedResult()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"testResult\"}";

            var webSocketMock = new Mock<IClientWebSocketManager>();
            var manager = CreateManager(webSocketMock);

            var task = manager.SendRequest<string>(request);

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(fakeJson));

            var result = await task;

            result.Result.Should().Be("testResult");

            webSocketMock.Verify(ws => ws.SendWebSocketRequestAsync(It.IsAny<JsonRpcRequest>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendRequestNonGeneric_THEN_ShouldReturnDeserializedResponse()
        {
            var request = new Remove("dummyGid", null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\"}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);

            var task = manager.SendRequest(request);

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(fakeJson));

            var response = await task;

            response.Error.Should().BeNull();

            webSocketMock.Verify(ws => ws.SendWebSocketRequestAsync(It.IsAny<JsonRpcRequest>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_InvalidJsonResponse_WHEN_SendRequest_THEN_ShouldThrow()
        {
            var request = new Remove("dummyGid", "123");
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":123}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);

            var task = manager.SendRequest(request);

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(fakeJson));

            manager.Dispose();

            Func<Task> act = () => task;

            await act.Should().ThrowAsync<TaskCanceledException>();

            webSocketMock.Verify(ws => ws.SendWebSocketRequestAsync(It.IsAny<JsonRpcRequest>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ExceptionIsThrownBeforeRetrivingTcs_WHEN_SendRequest_THEN_ShouldSetExceptionOnTask()
        {
            var request = new Remove("dummyGid", null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\"}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);
            manager.SetFailure(true, false);

            var task = manager.SendRequest(request);

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(fakeJson));

            Func<Task> act = () => task;

            await act.Should().ThrowAsync<InvalidOperationException>();

            webSocketMock.Verify(ws => ws.SendWebSocketRequestAsync(It.IsAny<JsonRpcRequest>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ExceptionIsThrownAfterRetrivingTcs_WHEN_SendRequest_THEN_ShouldSetExceptionOnTask()
        {
            var request = new Remove("dummyGid", null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\"}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);
            manager.SetFailure(false, true);

            var task = manager.SendRequest(request);

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(fakeJson));

            Func<Task> act = () => task;

            await act.Should().ThrowAsync<InvalidOperationException>();

            webSocketMock.Verify(ws => ws.SendWebSocketRequestAsync(It.IsAny<JsonRpcRequest>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_DuplicateRequest_WHEN_SendWebSocketRequestAsyncCalledTwice_THEN_ShouldThrowInvalidOperationException()
        {
            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);

            var request = new AddUri(new[] { "dummyUri" }, null, null, null);

            var t1 = manager.SendRequest(request);

            Func<Task> secondCall = () => manager.SendRequest(request);

            await secondCall.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("A request with the same ID is already pending.");

            manager.Dispose();
        }

        [Fact]
        public void GIVEN_NotificationWithNoParameters_WHEN_ReceivingMessage_THEN_ShouldDoNothing()
        {
            var notificationJson = $"{{\"jsonrpc\":\"2.0\",\"method\":\"OnDownloadStarted\",\"params\":[]}}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);

            string? receivedId = null;
            string? receivedName = null;

            manager.OnDownloadStarted += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadStarted";
            };
            manager.OnDownloadPaused += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadPaused";
            };
            manager.OnDownloadStopped += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadStopped";
            };
            manager.OnDownloadComplete += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadComplete";
            };
            manager.OnDownloadError += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadError";
            };
            manager.OnBtDownloadComplete += id =>
            {
                receivedId = id;
                receivedName = "OnBtDownloadComplete";
            };

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(notificationJson));

            receivedId.Should().BeNull();
            receivedName.Should().BeNull();
        }

        [Theory]
        [InlineData("aria2.onDownloadStart", "startGid", "OnDownloadStarted")]
        [InlineData("aria2.onDownloadPause", "pauseGid", "OnDownloadPaused")]
        [InlineData("aria2.onDownloadStop", "stopGid", "OnDownloadStopped")]
        [InlineData("aria2.onDownloadComplete", "completeGid", "OnDownloadComplete")]
        [InlineData("aria2.onDownloadError", "errorGid", "OnDownloadError")]
        [InlineData("aria2.onBtDownloadComplete", "btGid", "OnBtDownloadComplete")]
        public void GIVEN_ValidNotification_WHEN_ReceivingMessage_THEN_ShouldRaiseCorrespondingEvent(string methodName, string gid, string eventName)
        {
            var notificationJson = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{methodName}\",\"params\":[{{\"gid\":\"{gid}\"}}]}}";

            var webSocketMock = new Mock<IClientWebSocketManager>();

            var manager = CreateManager(webSocketMock);

            string? receivedId = null;
            string? receivedName = null;

            manager.OnDownloadStarted += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadStarted";
            };
            manager.OnDownloadPaused += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadPaused";
            };
            manager.OnDownloadStopped += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadStopped";
            };
            manager.OnDownloadComplete += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadComplete";
            };
            manager.OnDownloadError += id =>
            {
                receivedId = id;
                receivedName = "OnDownloadError";
            };
            manager.OnBtDownloadComplete += id =>
            {
                receivedId = id;
                receivedName = "OnBtDownloadComplete";
            };

            webSocketMock.Raise(c => c.OnMessageReceived += null, CreateJsonElement(notificationJson));

            receivedId.Should().Be(gid);
            receivedName.Should().Be(eventName);
        }
    }
}
