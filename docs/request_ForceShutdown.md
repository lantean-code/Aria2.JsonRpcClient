##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ForceShutdown

## Overview

Represents a request to force shutdown the aria2 server.

---

## Constructors
#### `ForceShutdown(string? id = null)`

Forcefully shuts down aria2 immediately without waiting for active downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceShutdown](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceShutdown)

**Parameters:**
<a id="ForceShutdown_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
