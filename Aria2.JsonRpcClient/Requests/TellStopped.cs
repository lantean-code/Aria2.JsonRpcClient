using System.Linq.Expressions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to get the list of stopped downloads.
    /// </summary>
    public sealed record TellStopped : JsonRpcRequest<IReadOnlyList<Aria2Status>>
    {
        /// <inheritdoc cref="IAria2Client.TellStopped(int, int, string[], string?)"/>
        public TellStopped(int offset, int num, string[]? keys = null, string? id = null) : base("aria2.tellStopped", [offset, num, keys], id)
        {
        }

        /// <inheritdoc cref="IAria2Client.TellStopped(int, int, Expression{Func{Aria2Status, object}}, string?)"/>
        public TellStopped(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null) : this(offset, num, Aria2StatuskeysSelector.Select(keysSelector), id)
        {
        }
    }
}
