using System.Linq.Expressions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the active downloads.
    /// </summary>
    public sealed record TellActive : JsonRpcRequest<IReadOnlyList<Aria2Status>>
    {
        /// <inheritdoc cref="IAria2Client.TellActive(string[], string)"/>
        public TellActive(string[]? keys = null, string? id = null) : base("aria2.tellActive", [keys], id)
        {
        }

        /// <inheritdoc cref="IAria2Client.TellActive(Expression{Func{Aria2Status, object}}, string?)"/>
        public TellActive(Expression<Func<Aria2Status, object?>> keysSelector, string? id = null) : this(Aria2StatuskeysSelector.Select(keysSelector), id)
        {
        }
    }
}
