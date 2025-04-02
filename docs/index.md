##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

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

## Others

| Type | Summary |
|------------|---------|
| [Aria2ClientOptions](Aria2ClientOptions.md) |  Represents the options for the Aria2 client. |
| [Aria2Exception](Aria2Exception.md) |  Represents an exception thrown by the Aria2 client. |
| [ConnectionType](ConnectionType.md) |  Represents the type of connection to use when communicating with the aria2 server. |
| [JsonRpcError](JsonRpcError.md) |  An object representing an aria2 error. |
| [JsonRpcParameters](JsonRpcParameters.md) |  A collection of parameters for a JSON-RPC request. |
| [JsonRpcRequest](JsonRpcRequest.md) |  An abstract Json RPC request. Inherit from this to add addtional aria2 requests. |
| [JsonRpcRequestT](JsonRpcRequestT.md) |  An abstract Json RPC request with a return type. Inherit from this to add addtional aria2 requests. |



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
