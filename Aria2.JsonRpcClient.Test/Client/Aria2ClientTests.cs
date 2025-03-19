using FluentAssertions;
using Moq;

namespace Aria2.JsonRpcClient.Test.Client
{
    public class Aria2ClientTests
    {
        private readonly IRequestHandler _requestHandler = Mock.Of<IRequestHandler>();
        private readonly Mock<INotificationHandler> _notificationHandler = new Mock<INotificationHandler>();
        private readonly Aria2Client _target;

        public Aria2ClientTests()
        {
            _target = new Aria2Client(_requestHandler, _notificationHandler.Object);
        }

        [Fact]
        public void GIVEN_OnDownloadStartedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadStarted()
        {
            string? received = null;
            _target.DownloadStarted += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadStarted += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadPausedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadPaused()
        {
            string? received = null;
            _target.DownloadPaused += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadPaused += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadStoppedEvent_WHEN_Raised_THEN_ShouldInvokeDownloadStopped()
        {
            string? received = null;
            _target.DownloadStopped += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadStopped += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadCompleteEvent_WHEN_Raised_THEN_ShouldInvokeDownloadComplete()
        {
            string? received = null;
            _target.DownloadComplete += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadComplete += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnDownloadErrorEvent_WHEN_Raised_THEN_ShouldInvokeDownloadError()
        {
            string? received = null;
            _target.DownloadError += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnDownloadError += null, testGid);

            received.Should().Be(testGid);
        }

        [Fact]
        public void GIVEN_OnBtDownloadCompleteEvent_WHEN_Raised_THEN_ShouldInvokeBtDownloadComplete()
        {
            string? received = null;
            _target.BtDownloadComplete += gid => received = gid;
            var testGid = "TestGid";

            _notificationHandler.Raise(n => n.OnBtDownloadComplete += null, testGid);

            received.Should().Be(testGid);
        }
    }
}
