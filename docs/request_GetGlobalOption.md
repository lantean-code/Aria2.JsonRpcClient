##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetGlobalOption

## Overview

Represents a request to get the global options of the aria2 server.

---

## Constructors
#### `GetGlobalOption(string? id = null)`

Returns the global options as a struct.
Only options that have been set or have defaults are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalOption)

**Parameters:**
<a id="GetGlobalOption_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A dictionary of global options.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
