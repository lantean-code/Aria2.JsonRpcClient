##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# SaveSession

## Overview

Represents a request to save the current session of the aria2 client.

---

## Constructors
#### `SaveSession(string? id = null)`

Saves the current session to a file specified by the --save-session option.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.saveSession](https://aria2.github.io/manual/en/html/aria2c.html#aria2.saveSession)

**Parameters:**
<a id="SaveSession_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
