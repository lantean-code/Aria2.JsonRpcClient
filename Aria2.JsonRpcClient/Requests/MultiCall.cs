using System.Text.Json;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to execute multiple requests in a single call.
    /// </summary>
    public sealed record MultiCall : JsonRpcRequest<IReadOnlyList<object>>
    {
        /// <inheritdoc cref="IAria2Client.SystemMulticall(JsonRpcRequest[], string?)"/>/>
        public MultiCall(JsonRpcRequest[] requests, string? id = null) : base("system.multicall", [requests.Select(MapRequest).ToArray()], id)
        {
        }

        /// <inheritdoc cref="IAria2Client.SystemMulticall(JsonRpcRequest[])"/>/>
        public MultiCall(params JsonRpcRequest[] requests) : this(requests, null)
        {
        }

        private static SystemMulticallRequest MapRequest(JsonRpcRequest request)
        {
            return new SystemMulticallRequest
            {
                MethodName = request.Method,
                Parameters = request.Parameters
            };
        }
    }
}
