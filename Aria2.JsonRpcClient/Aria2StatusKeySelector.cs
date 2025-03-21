using System.Linq.Expressions;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient
{
    internal class Aria2StatuskeysSelector
    {
        internal static string[] Select(Expression<Func<Aria2Status, object?>> selector)
        {
            string[] keys;

            if (selector.Body is NewExpression newExpression)
            {
                keys = newExpression.Arguments
                    .OfType<MemberExpression>()
                    .Select(me => Aria2Status.Keys.Match(me.Member.Name)).ToArray();
            }
            else
            {
                var memberExpression = selector.Body switch
                {
                    UnaryExpression unary when unary.Operand is MemberExpression me => me,
                    MemberExpression me => me,
                    _ => throw new ArgumentException("Unsupported expression type", nameof(selector))
                };

                keys = [Aria2Status.Keys.Match(memberExpression.Member.Name)];
            }

            return keys;
        }
    }
}
