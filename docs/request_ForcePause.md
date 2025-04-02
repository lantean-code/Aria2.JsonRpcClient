##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ForcePause

## Overview

Represents a request to force pause a download.

---

## Constructors
#### `ForcePause(string gid, string? id = null)`

Forcefully pauses the download denoted by [gid](#ForcePause_string_gid__string__id___null_gid) without performing extra actions.
Returns the GID of the paused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePause)

**Parameters:**
<a id="ForcePause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to forcefully pause.
<a id="ForcePause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the paused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
