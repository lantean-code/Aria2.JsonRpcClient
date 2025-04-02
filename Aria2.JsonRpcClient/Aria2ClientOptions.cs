using System.Net.WebSockets;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Represents the options for the aria2 client.
    /// </summary>
    public record Aria2ClientOptions
    {
        /// <summary>
        /// Gets or sets the connection type to use.
        /// </summary>
        public ConnectionType ConnectionType { get; set; } = ConnectionType.WebSocket;

        /// <summary>
        /// Gets or sets a value indicating whether to receive notifications from the server.
        /// </summary>
        public bool ReceiveNotifications { get; set; } = false;

        /// <summary>
        /// Gets or sets the host of the aria2 server.
        /// </summary>
        public string Host { get; set; } = "localhost";

        /// <summary>
        /// Gets or sets the port of the aria2 server.
        /// </summary>
        public int Port { get; set; } = 6800;

        /// <summary>
        /// Gets or sets the secret token to use for authentication.
        /// </summary>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the options for the Web Socket.
        /// </summary>
        public Action<ClientWebSocketOptions>? WebSocketOptions { get; set; }
    }
}
