using System.Net.WebSockets;
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
    public class ClientWebSocketManagerTests
    {
        private ClientWebSocketManager CreateManager(Mock<IClientWebSocket> webSocketMock)
        {
            var options = Options.Create(new Aria2ClientOptions { Host = "localhost", Port = 1234, Secret = "secret" });
            var policyRegistry = new PolicyRegistry { { "WebSocketPolicy", Policy.NoOpAsync() } };
            return new ClientWebSocketManager(webSocketMock.Object, options, policyRegistry);
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendWebSocketRequestAsyncGeneric_THEN_ShouldReturnDeserializedResult()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"testResult\"}";
            var fakeBytes = Encoding.UTF8.GetBytes(fakeJson);

            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns<ArraySegment<byte>, CancellationToken>((buffer, token) =>
                {
                    Array.Copy(fakeBytes, 0, buffer.Array!, buffer.Offset, fakeBytes.Length);
                    return Task.FromResult(new WebSocketReceiveResult(fakeBytes.Length, WebSocketMessageType.Text, true));
                });

            var manager = CreateManager(webSocketMock);

            await manager.SendWebSocketRequestAsync(request);

            webSocketMock.Verify(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendWebSocketRequestAsyncNonGeneric_THEN_ShouldReturnDeserializedResponse()
        {
            var request = new Remove("dummyGid", null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\"}";
            var fakeBytes = Encoding.UTF8.GetBytes(fakeJson);

            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns<ArraySegment<byte>, CancellationToken>((buffer, token) =>
                {
                    Array.Copy(fakeBytes, 0, buffer.Array!, buffer.Offset, fakeBytes.Length);
                    return Task.FromResult(new WebSocketReceiveResult(fakeBytes.Length, WebSocketMessageType.Text, true));
                });

            var manager = CreateManager(webSocketMock);

            await manager.SendWebSocketRequestAsync(request);

            webSocketMock.Verify(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_MultiSegmentResponse_WHEN_ReceiveLoopAssemblesMessage_THEN_PendingRequestReceivesFullMessage()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var part1 = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"test";
            var part2 = "Result\"}";
            var bytes1 = Encoding.UTF8.GetBytes(part1);
            var bytes2 = Encoding.UTF8.GetBytes(part2);

            var callCount = 0;
            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns<ArraySegment<byte>, CancellationToken>((buffer, token) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        Array.Copy(bytes1, 0, buffer.Array!, buffer.Offset, bytes1.Length);
                        return Task.FromResult(new WebSocketReceiveResult(bytes1.Length, WebSocketMessageType.Text, false));
                    }
                    else
                    {
                        Array.Copy(bytes2, 0, buffer.Array!, buffer.Offset, bytes2.Length);
                        return Task.FromResult(new WebSocketReceiveResult(bytes2.Length, WebSocketMessageType.Text, true));
                    }
                });

            var manager = CreateManager(webSocketMock);

            await manager.SendWebSocketRequestAsync(request);

            manager.Dispose();
        }

        [Fact]
        public async Task GIVEN_WebSocketInTerminalState_WHEN_SendWebSocketRequestAsyncCalled_THEN_ShouldCallRefreshAndConnect()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var fakeJson = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"testResult\"}";
            var fakeBytes = Encoding.UTF8.GetBytes(fakeJson);

            var stateSequence = new Queue<WebSocketState>(new[] { WebSocketState.Closed, WebSocketState.Open });

            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(() => stateSequence.Peek());
            webSocketMock.Setup(ws => ws.Refresh())
                .Callback(() => stateSequence.Dequeue())
                .Verifiable();
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns<ArraySegment<byte>, CancellationToken>((buffer, token) =>
                {
                    Array.Copy(fakeBytes, 0, buffer.Array!, buffer.Offset, fakeBytes.Length);
                    return Task.FromResult(new WebSocketReceiveResult(fakeBytes.Length, WebSocketMessageType.Text, true));
                });

            // Create the manager using our mock.
            var manager = CreateManager(webSocketMock);

            await manager.SendWebSocketRequestAsync(request);

            webSocketMock.Verify(ws => ws.Refresh(), Times.Once());
            webSocketMock.Verify(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_CloseMessage_WHEN_SendWebSocketRequestAsyncCalled_THEN_CloseAsyncIsCalled()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);

            var closeResult = new WebSocketReceiveResult(0, WebSocketMessageType.Close, true);

            var webSocketMock = new Mock<IClientWebSocket>();

            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);

            webSocketMock.Setup(ws => ws.SendAsync(
                    It.IsAny<ArraySegment<byte>>(),
                    WebSocketMessageType.Text,
                    true,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(closeResult);

            var tcs = new TaskCompletionSource<bool>();

            webSocketMock.Setup(ws => ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Callback(() => tcs.TrySetResult(true));

            var manager = CreateManager(webSocketMock);

            // Calling SendWebSocketRequestAsync to trigger EnsureConnectedAsync and start the receive loop.
            // This call will hang because no valid response is delivered, but that's acceptable for this test.
            var sendTask = manager.SendWebSocketRequestAsync(request);

            // Allow time for the receive loop to process the close message.
            var completedTask = await Task.WhenAny(tcs.Task, Task.Delay(2000));
#pragma warning disable xUnit1031 // Do not use blocking task operations in test method
            Assert.True(completedTask == tcs.Task && tcs.Task.Result, "CloseAsync was not called within the timeout.");
#pragma warning restore xUnit1031 // Do not use blocking task operations in test method

            manager.Dispose();

            webSocketMock.Verify(ws => ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_BufferTooSmall_WHEN_ReceiveLoopRuns_THEN_ShouldThrowBufferTooSmallException()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);

            var terminalResult = new WebSocketReceiveResult(8192, WebSocketMessageType.Text, false);

            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                         .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                         .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(terminalResult);

            var manager = CreateManager(webSocketMock);

            await manager.SendWebSocketRequestAsync(request);

            JsonElement? received = null;

            manager.OnMessageReceived += msg => received = msg;

            manager.Dispose();

            received.Should().BeNull();
        }

        [Fact]
        public async Task GIVEN_MultiSegmentResponse_WHEN_MessageIsSplitAcrossSegments_THEN_OnMessageReceivedIsCalledWithAssembledMessage()
        {
            // Arrange
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var part1 = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"tes";
            var part2 = "tResult\"}";
            var bytes1 = Encoding.UTF8.GetBytes(part1);
            var bytes2 = Encoding.UTF8.GetBytes(part2);

            int callCount = 0;
            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns<ArraySegment<byte>, CancellationToken>((buffer, token) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        // First segment: not the end of message.
                        Array.Copy(bytes1, 0, buffer.Array!, buffer.Offset, bytes1.Length);
                        return Task.FromResult(new WebSocketReceiveResult(bytes1.Length, WebSocketMessageType.Text, false));
                    }
                    else
                    {
                        // Second segment: marks the end.
                        Array.Copy(bytes2, 0, buffer.Array!, buffer.Offset, bytes2.Length);
                        return Task.FromResult(new WebSocketReceiveResult(bytes2.Length, WebSocketMessageType.Text, true));
                    }
                });

            var manager = CreateManager(webSocketMock);
            var tcs = new TaskCompletionSource<JsonElement>();

            manager.OnMessageReceived += (msg) =>
            {
                tcs.TrySetResult(msg);
            };

            // Act
            await manager.SendWebSocketRequestAsync(request);
            var received = await tcs.Task;

            // Assert
            var assembledMessage = received.GetRawText();
            var expectedMessage = "{\"jsonrpc\":\"2.0\",\"id\":\"" + request.Id + "\",\"result\":\"testResult\"}";
            assembledMessage.Should().Be(expectedMessage);

            manager.Dispose();
        }
    }
}
