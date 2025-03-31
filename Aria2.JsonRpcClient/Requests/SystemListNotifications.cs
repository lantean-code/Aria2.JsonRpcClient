namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to list the notifications of the aria2 client.
    /// </summary>
    public sealed record SystemListNotifications : JsonRpcRequest<IReadOnlyList<string>>
    {
        /// <inheritdoc cref="IAria2Client.SystemListNotifications"/>/>
        public SystemListNotifications(string? id = null) : base("system.listNotifications", JsonRpcParameters.Empty, id)
        {
        }
    }
}
