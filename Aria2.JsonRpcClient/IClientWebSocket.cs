using System.Net.WebSockets;

namespace Aria2.JsonRpcClient
{
    internal interface IClientWebSocket : IDisposable
    {
        ClientWebSocketOptions Options { get; }
        WebSocketState State { get; }

        Task ConnectAsync(Uri uri, CancellationToken cancellationToken);

        Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);

        Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken);

        Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken);

        void Refresh();
    }
}
