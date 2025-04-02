##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Unpause

## Overview

Represents a request to unpause a download.

---

## Constructors
#### `Unpause(string gid, string? id = null)`

Unpauses the download denoted by [gid](#Unpause_string_gid__string__id___null_gid), changing its status to waiting.
Returns the GID of the unpaused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpause)

**Parameters:**
<a id="Unpause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to unpause.
<a id="Unpause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the unpaused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
