##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ForceRemove

## Overview

Represents a request to force remove a download.

---

## Constructors
#### `ForceRemove(string gid, string? id = null)`

Forcefully removes the download denoted by [gid](#ForceRemove_string_gid__string__id___null_gid) from the download queue without performing time‑consuming actions.
Returns the GID of the removed download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceRemove](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceRemove)

**Parameters:**
<a id="ForceRemove_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to forcefully remove.
<a id="ForceRemove_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the removed download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
