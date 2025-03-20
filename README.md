# Aria2.JsonRpcClient

**Aria2.JsonRpcClient** is a C# client library that simplifies interaction with aria2’s JSON‑RPC interface. It encapsulates the complexities of JSON‑RPC and provides an intuitive, asynchronous API for managing downloads via either WebSocket or HTTP.

**Supported Frameworks:**  
This library supports **.NET Standard 2.0**, **.NET 8.0**, and **.NET 9.0**.

## Features

- **Simple Download Management:**  
  Easily add downloads (using URIs, torrents, or metalinks), pause/resume, remove, and query downloads.
  
- **Flexible Connection Options:**  
  Choose between WebSocket and HTTP connections by configuring the `ConnectionType` option.
  
- **Robust Communication:**  
  Optionally receive notifications (only applicable when using WebSocket) and integrate custom retry policies with Polly.
  
- **Seamless Dependency Injection:**  
  Register and configure the client easily with Microsoft's Dependency Injection using the `AddAria2Client` extension method.
  
- **Comprehensive JSON‑RPC Models:**  
  Includes models for download options, status, global statistics, and more, reflecting the full capabilities of aria2's JSON‑RPC interface.

- **Uses System.Text.Json:**  
  For .NET 8.0 and above, source generators are use to improve performance. NET Standard 2.0 falls back to reflection based type discovery.

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package Aria2.JsonRpcClient
```

Or via the Package Manager Console in Visual Studio:

```powershell
Install-Package Aria2.JsonRpcClient
```

## Getting Started

### Registering the Client

Register the client in your DI container using the `AddAria2Client` extension method. Configure it with your server’s host, port, connection type, and other options via `Aria2ClientOptions`.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Aria2.JsonRpcClient;
using Polly;

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

    // Optionally, register a custom retry policy for WebSocket communications.
    services.AddWebSocketRetryPolicy(
        Policy.Handle<Exception>().RetryAsync(3)
    );

    // Optionally, register a custom retry policy for HTTP communications.
    services.AddHttpGetRetryPolicy(
        Policy.Handle<Exception>().RetryAsync(3)
    );
}
```

### Using the Client

After registration, you can inject `IAria2Client` into your services and use its methods to manage downloads:

```csharp
using System;
using System.Threading.Tasks;
using Aria2.JsonRpcClient;

public class DownloadService
{
    private readonly IAria2Client _aria2Client;

    public DownloadService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task StartDownloadAsync()
    {
        // Example: Add a download using a URI.
        string[] uris = { "http://example.com/file.zip" };
        string downloadId = await _aria2Client.AddUri(uris);
        Console.WriteLine($"Download added with GID: {downloadId}");
    }
}
```

Requests can be made using the client methods or by instantiating the a request class directly and getting the client to execute it.

```csharp
using System;
using System.Threading.Tasks;
using Aria2.JsonRpcClient;

public class DownloadService
{
    private readonly IAria2Client _aria2Client;

    public DownloadService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task StartDownloadAsync()
    {
        // Example: Add a download using a URI.
        string[] uris = { "http://example.com/file.zip" };
        var request = new AddUri(uris);
        string downloadId = await _aria2Client.ExecuteRequest<string>(request);
        Console.WriteLine($"Download added with GID: {downloadId}");
    }
}
```

Aria2 Multi Call is also supported, allowing multiple requests to be sent in a single call.
```csharp
using System;
using System.Threading.Tasks;
using Aria2.JsonRpcClient;

public class DownloadService
{
    private readonly IAria2Client _aria2Client;

    public StatusService(IAria2Client aria2Client)
    {
        _aria2Client = aria2Client;
    }

    public async Task GetSystemStatusAsync()
    {
        var multi = await _aria2Client.SystemMulticall(new GetGlobalOption(), new GetGlobalStat(), new GetVersion());
        var globalOptions = multi[0] as IReadOnlyDictionary<string, string?>;
        var stats = multi[1] as Aria2GlobalStat;
        var version = multi[2] as Aria2Version;
    }
}
```

### Handling Notification Events

When using WebSocket connections and enabling notifications (by setting `ReceiveNotifications` to `true`), you can subscribe to events provided by the `IAria2Client`. For example:

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

To register and use notifications, you can inject your `DownloadNotifier` (or instantiate it directly) after registering the client in DI:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Aria2.JsonRpcClient;
using Polly;

public void ConfigureServices(IServiceCollection services)
{
    // Register the Aria2 client with options.
    services.AddAria2Client(options =>
    {
        options.ConnectionType = ConnectionType.WebSocket;
        options.ReceiveNotifications = true;
        options.Host = "localhost";
        options.Port = 6800;
        options.Secret = "your_secret_token";
    });

    // Optionally, add custom retry policies.
    services.AddWebSocketRetryPolicy(Policy.Handle<Exception>().RetryAsync(3));
    services.AddHttpGetRetryPolicy(Policy.Handle<Exception>().RetryAsync(3));

    // Register the DownloadNotifier to subscribe to events.
    services.AddTransient<DownloadNotifier>();
}
```

## Configuration Options

The client is configured via the `Aria2ClientOptions` class, which includes:

- **`ConnectionType`**:  
  Set to either `ConnectionType.Http` or `ConnectionType.WebSocket` (default is `WebSocket`).

- **`ReceiveNotifications`**:  
  A boolean indicating whether to receive notifications (default is `false`).

- **`Host`**:  
  The aria2 JSON‑RPC server host (default is `"localhost"`).

- **`Port`**:  
  The server port (default is `6800`).

- **`Secret`**:  
  An optional secret/token for authenticating with the aria2 server.

- **`WebSocketOptions`**:  
  An optional delegate to configure additional WebSocket options (of type `Action<ClientWebSocketOptions>`).

## Advanced Usage

- **Comprehensive Download Management:**  
  The library supports adding downloads (via `AddUri`, `AddTorrent`, and `AddMetalink`), controlling download state (pause, resume, remove), and querying detailed status (files, peers, and global statistics).

- **Notification Handling:**  
  When notifications are enabled, subscribe to events such as download start, pause, complete, and errors for real-time updates.

- **Custom Retry Policies:**  
  Use the provided extension methods `AddWebSocketRetryPolicy` and `AddHttpGetRetryPolicy` to register custom Polly retry policies for resilient communication.

- **Extensibility:**  
  Add new requests by inheriting the `JsonRpcRequest` record and calling `ExecuteRequest<T>` or `ExecuteRequest` on the client.`

For more details, refer to the inline XML documentation in the source code.

## References
- [aria2 GitHub Repository](https://github.com/aria2/aria2)
- [aria2 Manual](https://aria2.github.io/manual/en/html/aria2c.html)

## Contributing

Contributions are welcome! Please fork the repository, create your feature branch, and submit a pull request. For major changes, please open an issue to discuss what you would like to change.

## License

This project is licensed under the MIT License. See the [LICENSE](https://raw.githubusercontent.com/lantean-code/Aria2.JsonRpcClient/refs/heads/master/LICENSE.txt) file for details.
