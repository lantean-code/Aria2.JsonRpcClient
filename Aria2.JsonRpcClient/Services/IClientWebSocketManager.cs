using System.Text.Json;

namespace Aria2.JsonRpcClient.Services
{
    internal interface IClientWebSocketManager
    {
        event Action<JsonElement>? OnMessageReceived;

        Task SendWebSocketRequestAsync<T>(T request);
    }
}
