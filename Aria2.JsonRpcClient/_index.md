# Aria2.JsonRpcClient

## API Documentation

For more information on the aria2 JSON-RPC API, see the [aria2 documentation](https://aria2.github.io/manual/en/html/aria2c.html#json-rpc-methods).

## Basic Usage
Use the provided extension methods to add the aria2 client to the `IServiceCollection`:
```csharp
using Microsoft.Extensions.DependencyInjection;
using Aria2.JsonRpcClient;

public void ConfigureServices(IServiceCollection services)
{
    // Register the Aria2 client with custom options.
    services.AddAria2Client(options =>
    {
        // Specify the connection type: Http or WebSocket.
        options.ConnectionType = ConnectionType.WebSocket;
        
        // Set whether to receive notifications (only applicable for WebSocket).
        options.ReceiveNotifications = true;
        
        // Set the aria2 JSON‑RPC server host and port.
        options.Host = "localhost";
        options.Port = 6800;
        
        // Optionally, provide a secret for authenticating with the server.
        options.Secret = "your_secret_token";
        
        // Optionally, configure additional WebSocket options.
        options.WebSocketOptions = webSocketOptions =>
        {
            // Customize webSocketOptions here if needed.
        };
    });
}
```

You can then inject [`IAria2Client`](client.md) into your services and use it to interact with the aria2 server.

## Advanced Usage

See the (examples)[examples.md] for more advanced usage scenarios.

## API Reference

- [`IAria2Client`](client.md)
- [Models](models.md)
- [Requests](requests.md)
