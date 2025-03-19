
namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to change the position of a download.
    /// </summary>
    public sealed record ChangePosition : JsonRpcRequest<int>
    {
        /// <inheritdoc cref="IAria2Client.ChangePosition"/>
        public ChangePosition(string gid, int pos, string how, string? id = null) : base("aria2.changePosition", [gid, pos, how], id)
        {
        }
    }
}
