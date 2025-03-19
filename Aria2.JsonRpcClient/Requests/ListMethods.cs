namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to list the available RPC methods.
    /// </summary>
    public sealed record ListMethods : JsonRpcRequest<IReadOnlyList<string>>
    {
        /// <inheritdoc cref="IAria2Client.SystemListMethods"/>/>
        public ListMethods(string? id = null) : base("system.listMethods", JsonRpcParameters.Empty, id)
        {
        }
    }
}
