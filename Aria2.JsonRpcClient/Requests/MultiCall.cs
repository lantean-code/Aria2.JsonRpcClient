using System.Text.Json;
using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    /// <summary>
    /// Represents a request to execute multiple requests in a single call.
    /// </summary>
    public sealed record MultiCall : JsonRpcRequest<IReadOnlyList<JsonElement[]>>
    {
        /// <inheritdoc cref="IAria2Client.SystemMulticall(JsonRpcRequest[])"/>/>
        public MultiCall(JsonRpcRequest[] requests) : base("system.multicall", [requests.Select(MapRequest).ToArray()])
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
