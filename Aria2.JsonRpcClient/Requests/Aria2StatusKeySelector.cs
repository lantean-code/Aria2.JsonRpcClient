using System.Linq.Expressions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    internal static class Aria2StatusKeysSelector
    {
        internal static string[] Select(Expression<Func<Aria2Status, object?>> selector)
        {
            return selector.Body switch
            {
                NewExpression newExpression => newExpression.Arguments
                                            .OfType<MemberExpression>()
                                            .Select(me => Aria2Status.Keys.Match(me.Member.Name)).ToArray(),
                MemberExpression memberExpression => [Aria2Status.Keys.Match(memberExpression.Member.Name)],
                _ => throw new ArgumentException("Unsupported expression type", nameof(selector)),
            };
        }
    }
}
