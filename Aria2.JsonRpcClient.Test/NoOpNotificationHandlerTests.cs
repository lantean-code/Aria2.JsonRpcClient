using System.Reflection;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class NoOpNotificationHandlerTests
    {
        private readonly NoOpNotificationHandler _handler = new();

        private static Delegate GetEventDelegate(NoOpNotificationHandler handler, string eventName)
        {
            // Use reflection to get the underlying delegate of the event.
            var field = typeof(NoOpNotificationHandler)
                .GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field?.GetValue(handler) is not Delegate dlg)
            {
                throw new InvalidOperationException("Failed to get the event delegate.");
            }

            return dlg;
        }

        [Fact]
        public void GIVEN_NoOpNotificationHandler_WHEN_CreatingInstance_THEN_AllEventsHaveOneEmptyLambda()
        {
            var handler = new NoOpNotificationHandler();

            GetEventDelegate(handler, "OnDownloadStarted").GetInvocationList().Should().HaveCount(1);
            GetEventDelegate(handler, "OnDownloadPaused").GetInvocationList().Should().HaveCount(1);
            GetEventDelegate(handler, "OnDownloadStopped").GetInvocationList().Should().HaveCount(1);
            GetEventDelegate(handler, "OnDownloadComplete").GetInvocationList().Should().HaveCount(1);
            GetEventDelegate(handler, "OnDownloadError").GetInvocationList().Should().HaveCount(1);
            GetEventDelegate(handler, "OnBtDownloadComplete").GetInvocationList().Should().HaveCount(1);
        }

        [Theory]
        [InlineData("OnDownloadStarted")]
        [InlineData("OnDownloadPaused")]
        [InlineData("OnDownloadStopped")]
        [InlineData("OnDownloadComplete")]
        [InlineData("OnDownloadError")]
        [InlineData("OnBtDownloadComplete")]
        public void GIVEN_NoOpNotificationHandler_WHEN_InvokingAllEventDelegates_THEN_ShouldNotThrow(string eventName)
        {
            var del = GetEventDelegate(_handler, eventName);
            Action act = () => del.DynamicInvoke("testGid");
            act.Should().NotThrow();
        }
    }
}
