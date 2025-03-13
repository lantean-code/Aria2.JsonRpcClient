namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Represents the type of connection to use when communicating with the aria2 server.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// Represents an HTTP connection.
        /// </summary>
        Http,

        /// <summary>
        /// Represents a WebSocket connection.
        /// </summary>
        WebSocket
    }
}
