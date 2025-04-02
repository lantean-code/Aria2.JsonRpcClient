##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetSessionInfo

## Overview

Represents a request to get the session information of the aria2 client.

---

## Constructors
#### `GetSessionInfo(string? id = null)`

Returns session information of the current aria2 session, including the session ID.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getSessionInfo](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getSessionInfo)

**Parameters:**
<a id="GetSessionInfo_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2SessionInfo](model_Aria2SessionInfo.md) object with session information.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
