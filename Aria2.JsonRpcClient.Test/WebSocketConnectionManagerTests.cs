using System.Net.WebSockets;
using System.Text;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Polly;
using Polly.Registry;

namespace Aria2.JsonRpcClient.Test
{
    public class WebSocketConnectionManagerTests
    {
        private WebSocketConnectionManager CreateManager(Mock<IClientWebSocket> webSocketMock)
        {
            var options = Options.Create(new Aria2ClientOptions { Host = "localhost", Port = 1234, Secret = "secret" });
            var policyRegistry = new PolicyRegistry { { "WebSocketPolicy", Policy.NoOpAsync() } };
            return new WebSocketConnectionManager(webSocketMock.Object, options, policyRegistry);
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendRequestGeneric_THEN_ShouldReturnDeserializedResult()
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

            var result = await manager.SendRequest<string>(request);

            result.Result.Should().Be("testResult");

            webSocketMock.Verify(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_ValidRequest_WHEN_SendRequestNonGeneric_THEN_ShouldReturnDeserializedResponse()
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

            var response = await manager.SendRequest(request);

            response.Error.Should().BeNull();

            webSocketMock.Verify(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_DuplicateRequest_WHEN_SendRequestCalledTwice_THEN_ShouldThrowInvalidOperationException()
        {
            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            // Configure ReceiveAsync to never complete so the first call remains pending.
            var pendingTcs = new TaskCompletionSource<WebSocketReceiveResult>();
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Returns(pendingTcs.Task);

            var manager = CreateManager(webSocketMock);

            var request = new AddUri(new[] { "dummyUri" }, null, null, null);

            var firstCall = manager.SendRequest<string>(request);

            Func<Task> secondCall = () => manager.SendRequest<string>(request);

            await secondCall.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("A request with the same ID is already pending.");

            manager.Dispose();
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

            var result = await manager.SendRequest<string>(request);

            result.Result.Should().Be("testResult");

            manager.Dispose();
        }

        [Theory]
        [InlineData("{\"jsonrpc\":\"2.0\",\"method\":\"aria2.onDownloadStart\",\"params\":[]}")]
        [InlineData("{\"jsonrpc\":\"2.0\",\"method\":\"aria2.onDownloadStart\"}")]
        public async Task GIVEN_NotificationWithNoParams_WHEN_ReceiveLoopProcessesMessage_THEN_ShouldNotRaiseAnyEvent(string json)
        {
            var notificationBytes = Encoding.UTF8.GetBytes(json);
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
                        Array.Copy(notificationBytes, 0, buffer.Array!, buffer.Offset, notificationBytes.Length);
                        return Task.FromResult(new WebSocketReceiveResult(notificationBytes.Length, WebSocketMessageType.Text, true));
                    }
                    else
                    {
                        throw new OperationCanceledException();
                    }
                });

            var manager = CreateManager(webSocketMock);

            var eventRaised = false;
            manager.OnDownloadStarted += gid => eventRaised = true;

            // Trigger the receive loop by issuing a dummy SendRequest that will use our notification.
            var dummyRequest = new AddUri(new[] { "dummyUri" }, null, null, "dummy");
            _ = manager.SendRequest<string>(dummyRequest);

            // Await a short period for the notification to be processed.
            await Task.Delay(500);

            eventRaised.Should().BeFalse();

            manager.Dispose();
        }

        [Theory]
        [InlineData("aria2.onDownloadStart", "startGid", "OnDownloadStarted")]
        [InlineData("aria2.onDownloadPause", "pauseGid", "OnDownloadPaused")]
        [InlineData("aria2.onDownloadStop", "stopGid", "OnDownloadStopped")]
        [InlineData("aria2.onDownloadComplete", "completeGid", "OnDownloadComplete")]
        [InlineData("aria2.onDownloadError", "errorGid", "OnDownloadError")]
        [InlineData("aria2.onBtDownloadComplete", "btGid", "OnBtDownloadComplete")]
        public async Task GIVEN_ValidNotification_WHEN_ReceiveLoopProcessesMessage_THEN_ShouldRaiseCorrespondingEvent(string methodName, string gid, string eventName)
        {
            var notificationJson = $"{{\"jsonrpc\":\"2.0\",\"method\":\"{methodName}\",\"params\":[{{\"gid\":\"{gid}\"}}]}}";
            var notificationBytes = Encoding.UTF8.GetBytes(notificationJson);

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
                        Array.Copy(notificationBytes, 0, buffer.Array!, buffer.Offset, notificationBytes.Length);
                        return Task.FromResult(new WebSocketReceiveResult(notificationBytes.Length, WebSocketMessageType.Text, true));
                    }
                    else
                    {
                        throw new OperationCanceledException();
                    }
                });

            var manager = CreateManager(webSocketMock);

            string? received = null;
            switch (eventName)
            {
                case "OnDownloadStarted":
                    manager.OnDownloadStarted += id => received = id;
                    break;
                case "OnDownloadPaused":
                    manager.OnDownloadPaused += id => received = id;
                    break;
                case "OnDownloadStopped":
                    manager.OnDownloadStopped += id => received = id;
                    break;
                case "OnDownloadComplete":
                    manager.OnDownloadComplete += id => received = id;
                    break;
                case "OnDownloadError":
                    manager.OnDownloadError += id => received = id;
                    break;
                case "OnBtDownloadComplete":
                    manager.OnBtDownloadComplete += id => received = id;
                    break;
            }

            var dummyRequest = new AddUri(new[] { "dummyUri" }, null, null, "dummy");
            _ = manager.SendRequest<string>(dummyRequest);

            // Await a short period for the notification to be processed.
            await Task.Delay(500);

            received.Should().Be(gid);

            manager.Dispose();
        }

        [Fact]
        public async Task GIVEN_OperationCanceledExceptionInReceiveAsync_WHEN_ReceiveLoopRuns_THEN_ShouldExitLoop()
        {
            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new OperationCanceledException());
            var manager = CreateManager(webSocketMock);

            var receiveLoop = typeof(WebSocketConnectionManager)
                .GetMethod("ReceiveLoop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var task = (Task?)receiveLoop!.Invoke(manager, null);
            await (task ?? Task.CompletedTask);
        }

        [Fact]
        public async Task GIVEN_GenericExceptionInReceiveAsync_WHEN_ReceiveLoopRuns_THEN_ShouldFaultPendingRequestsAndClearThem()
        {
            var request = new AddUri(new[] { "dummyUri" }, null, null, null);
            var webSocketMock = new Mock<IClientWebSocket>();
            webSocketMock.Setup(ws => ws.State).Returns(WebSocketState.Open);
            webSocketMock.Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            webSocketMock.Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test exception"));
            var manager = CreateManager(webSocketMock);

            var sendTask = manager.SendRequest<string>(request);

            Func<Task> act = async () => await sendTask;
            await act.Should().ThrowAsync<Exception>().WithMessage("Test exception");
        }

        [Fact]
        public async Task GIVEN_WebSocketInTerminalState_WHEN_SendRequestCalled_THEN_ShouldCallRefreshAndConnect()
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

            var result = await manager.SendRequest<string>(request);

            result.Result.Should().Be("testResult");

            webSocketMock.Verify(ws => ws.Refresh(), Times.Once());
            webSocketMock.Verify(ws => ws.ConnectAsync(It.IsAny<Uri>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GIVEN_CloseMessage_WHEN_SendRequestCalled_THEN_CloseAsyncIsCalled()
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

            webSocketMock.Setup(ws => ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var manager = CreateManager(webSocketMock);

            // Calling SendRequest to trigger EnsureConnectedAsync and start the receive loop.
            // This call will hang because no valid response is delivered, but that's acceptable for this test.
            var sendTask = manager.SendRequest<string>(request);

            // Allow time for the receive loop to process the close message.
            await Task.Delay(200);

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

            Func<Task> act = () => manager.SendRequest<string>(request);

            await act.Should().ThrowAsync<Exception>()
                 .WithMessage("Buffer too small for message.");

            manager.Dispose();
        }
    }
}
