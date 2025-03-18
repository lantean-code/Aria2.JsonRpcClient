namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the global options of the aria2 server.
    /// </summary>
    public sealed record GetGlobalOption : JsonRpcRequest<IReadOnlyDictionary<string, string?>>
    {
        /// <inheritdoc cref="IAria2Client.GetGlobalOption"/>
        public GetGlobalOption(string? id = null) : base("aria2.getGlobalOption", JsonRpcParameters.Empty, id)
        {
        }
    }
}
