using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient.Requests
{
    internal sealed record MultiCall : JsonRpcRequest<IReadOnlyList<object?>>
    {
        public MultiCall(JsonRpcRequest[] requests, string? id = null) : base("system.multicall", [requests.Select(MapRequest).ToArray()], id)
        {
        }

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
