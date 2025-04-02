##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# SystemListMethods

## Overview

Represents a request to list the available RPC methods.

---

## Constructors
#### `SystemListMethods(string? id = null)`

Returns an array of all available RPC method names.

> [https://aria2.github.io/manual/en/html/aria2c.html#system.listMethods](https://aria2.github.io/manual/en/html/aria2c.html#system.listMethods)

**Parameters:**
<a id="SystemListMethods_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A list of method names.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
