using System.Linq.Expressions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the status of a download.
    /// </summary>
    public sealed record TellStatus : JsonRpcRequest<Aria2Status>
    {
        /// <inheritdoc cref="IAria2Client.TellStatus(string, string[], string?)"/>
        public TellStatus(string gid, string[]? keys = null, string? id = null) : base("aria2.tellStatus", [gid, keys], id)
        {
        }

        /// <inheritdoc cref="IAria2Client.TellStatus(string, Expression{Func{Aria2Status, object}}, string?)"/>
        public TellStatus(string gid, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null) : this(gid, Aria2StatusKeysSelector.Select(keysSelector), id)
        {
        }
    }
}
