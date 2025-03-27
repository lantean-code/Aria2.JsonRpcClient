namespace Aria2.JsonRpcClient.Services
{
    internal interface IRequestHandler
    {
        Task<JsonRpcResponse<TResponse>> SendRequest<TResponse>(JsonRpcRequest jsonRpcRequest);

        Task<JsonRpcResponse> SendRequest(JsonRpcRequest jsonRpcRequest);
    }
}
