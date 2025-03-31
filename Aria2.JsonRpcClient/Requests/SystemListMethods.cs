namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to list the available RPC methods.
    /// </summary>
    public sealed record SystemListMethods : JsonRpcRequest<IReadOnlyList<string>>
    {
        /// <inheritdoc cref="IAria2Client.SystemListMethods"/>/>
        public SystemListMethods(string? id = null) : base("system.listMethods", JsonRpcParameters.Empty, id)
        {
        }
    }
}
