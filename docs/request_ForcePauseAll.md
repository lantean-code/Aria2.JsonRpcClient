##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ForcePauseAll

## Overview

Represents a request to force pause all downloads.

---

## Constructors
#### `ForcePauseAll(string? id = null)`

Forcefully pauses all active and waiting downloads without extra actions.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePauseAll](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePauseAll)

**Parameters:**
<a id="ForcePauseAll_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
