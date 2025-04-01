## Client Configuration

### aria2 client using JSON-RPC over HTTP
This is ideal for use in a service side web application where websockets are not supported. 

```csharp
using Microsoft.Extensions.DependencyInjection;
using Aria2.JsonRpcClient;

public void ConfigureServices(IServiceCollection services)
{
    // Register the Aria2 client with custom options.
    services.AddAria2Client(options =>
    {
        options.ConnectionType = ConnectionType.Http;
        
        // Set the aria2 JSON‑RPC server host and port.
        options.Host = "localhost";
        options.Port = 6800;
        
        // Optionally, provide a secret for authenticating with the server.
        options.Secret = "your_secret_token";
    });
}
```

### aria2 client using JSON-RPC over WebSocket
This is ideal for use in a client application where websockets are supported. 
```csharp
using Microsoft.Extensions.DependencyInjection;
using Aria2.JsonRpcClient;

public void ConfigureServices(IServiceCollection services)
{
    // Register the Aria2 client with custom options.
    services.AddAria2Client(options =>
    {
        options.ConnectionType = ConnectionType.WebSocket;
        
        options.ReceiveNotifications = true;
        
        // Set the aria2 JSON‑RPC server host and port.
        options.Host = "localhost";
        options.Port = 6800;
        
        // Optionally, provide a secret for authenticating with the server.
        options.Secret = "your_secret_token";
    });
}
```

## Using the client

### Basic Usage
You can then inject [`IAria2Client`](client.md) into your services and use it to interact with the aria2 server.
```csharp
using Aria2.JsonRpcClient;

public class MyService
{
    private readonly IAria2Client _aria2Client;
    public MyService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task GetVersion()
    {
        var version = await _aria2Client.GetVersion();
        Console.WriteLine($"Aria2 version: {version.Version}");
    }

    public async Task AddUri()
    {
        var gid = await _aria2Client.AddUri(new[] { "http://example.com/file1.zip" });
        Console.WriteLine($"Download started with GID: {gid}");
    }
}
```

### Multicall Requests
You can also send multiple requests in a single call using the `Multicall` method. Requests that return a value have a `IsError()` and `GetResult()` helper methods to check for errors and get the result without needing to cast to the return type manually.
```csharp
using Aria2.JsonRpcClient;
using Aria2.JsonRpcClient.Requests;

public class MyService
{
    private readonly IAria2Client _aria2Client;

    public MyService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task MultiCall()
    {
        var getVersionRequest = new GetVersion();

        var addUriRequest = new AddUri(new[] { "http://example.com/file1.zip" });

        var response = await _aria2Client.SystemMulticall(getVersionRequest, addUriRequest);

        var getVersionResponse = response[0];
        if (GetVersion.IsError(getVersionResponse, out var getVersionError))
        {
            Console.WriteLine($"Error: {getVersionError.Message}");
        }
        else
        {
            Console.WriteLine($"Version: {GetVersion.GetResult(getVersionResponse).Version}");
        }

        var addUriResponse = response[1];
        if (AddUri.IsError(addUriResponse, out var addUriError))
        {
            Console.WriteLine($"Error: {addUriError.Message}");
        }
        else
        {
            Console.WriteLine($"GID: {AddUri.GetResult(addUriResponse)}");
        }
    }
}
```

### Request Execute
You can also send requests directly using the `ExecuteRequest` method.
```csharp
using Aria2.JsonRpcClient;
using Aria2.JsonRpcClient.Requests;

public class MyService
{
    private readonly IAria2Client _aria2Client;

    public MyService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task Execute()
    {
        var getVersionRequest = new GetVersion();

        var response = await _aria2Client.ExecuteRequest(getVersionRequest);

        Console.WriteLine($"Version: {response.Version}");
    }
}
```


### Custom Requests
To extend the client with custom requests, create a new class that inherits from [`JsonRpcRequest`](JsonRpcRequest.md) or [`JsonRpcRequest<T>`](JsonRpcRequestT.md). You can then use the `ExecuteRequest` method to send the request to the server.

```csharp
/// <summary>
    /// Represents a request to move a completed download.
    /// </summary>
    public record MoveDownload : JsonRpcRequest
    {
        public MoveDownload(string gid, string location, string? id = null) : base("moveDownload", [gid, location], id)
        {
        }
    }

    /// <summary>
    /// Represents a request to get the move progress.
    /// </summary>
    public record GetMoveProgress : JsonRpcRequest<decimal>
    {
        public GetMoveProgress(string gid, string? id = null) : base("getMoveProgress", [gid], id)
        {
        }
    }
```

### Notifications
If you are using the WebSocket connection type, you can subscribe to notifications using the [`IAria2Client`](client.md) events.
```csharp
using System;
using Aria2.JsonRpcClient;

public class DownloadNotifier
{
    private readonly IAria2Client _aria2Client;

    public DownloadNotifier(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;

        // Subscribe to notification events.
        _aria2Client.DownloadStarted += OnDownloadStarted;
        _aria2Client.DownloadPaused += OnDownloadPaused;
        _aria2Client.DownloadStopped += OnDownloadStopped;
        _aria2Client.DownloadComplete += OnDownloadComplete;
        _aria2Client.DownloadError += OnDownloadError;
        _aria2Client.BtDownloadComplete += OnBtDownloadComplete;
    }

    private void OnDownloadStarted(string gid)
    {
        Console.WriteLine($"Download started: {gid}");
    }

    private void OnDownloadPaused(string gid)
    {
        Console.WriteLine($"Download paused: {gid}");
    }

    private void OnDownloadStopped(string gid)
    {
        Console.WriteLine($"Download stopped: {gid}");
    }

    private void OnDownloadComplete(string gid)
    {
        Console.WriteLine($"Download complete: {gid}");
    }

    private void OnDownloadError(string gid)
    {
        Console.WriteLine($"Download encountered an error: {gid}");
    }

    private void OnBtDownloadComplete(string gid)
    {
        Console.WriteLine($"BitTorrent download complete: {gid}");
    }
}
```
