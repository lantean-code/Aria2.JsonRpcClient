namespace Aria2.JsonRpcClient
{
    internal class NoOpNotificationHandler : INotificationHandler
    {
        public event Action<string> OnDownloadStarted = (gid) => { };

        public event Action<string> OnDownloadPaused = (gid) => { };

        public event Action<string> OnDownloadStopped = (gid) => { };

        public event Action<string> OnDownloadComplete = (gid) => { };

        public event Action<string> OnDownloadError = (gid) => { };

        public event Action<string> OnBtDownloadComplete = (gid) => { };
    }
}
