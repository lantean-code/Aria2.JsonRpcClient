namespace Aria2.JsonRpcClient.Services
{
    internal interface INotificationHandler
    {
        /// <summary>
        /// This notification will be sent when a download is started.
        /// </summary>
        event Action<string> OnDownloadStarted;

        /// <summary>
        /// This notification will be sent when a download is paused.
        /// </summary>
        event Action<string> OnDownloadPaused;

        /// <summary>
        /// This notification will be sent when a download is stopped by the user.
        /// </summary>
        event Action<string> OnDownloadStopped;

        /// <summary>
        /// This notification will be sent when a download is complete. For BitTorrent downloads, this notification is sent when the download is complete and seeding is over.
        /// </summary>
        event Action<string> OnDownloadComplete;

        /// <summary>
        /// This notification will be sent when a download is stopped due to an error.
        /// </summary>
        event Action<string> OnDownloadError;

        /// <summary>
        /// This notification will be sent when a torrent download is complete but seeding is still going on.
        /// </summary>
        event Action<string> OnBtDownloadComplete;
    }
}
