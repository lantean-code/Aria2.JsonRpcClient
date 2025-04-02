##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Pause

## Overview

Represents a request to pause a download.

---

## Constructors
#### `Pause(string gid, string? id = null)`

Pauses the download denoted by [gid](#Pause_string_gid__string__id___null_gid).
Returns the GID of the paused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.pause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.pause)

**Parameters:**
<a id="Pause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to pause.
<a id="Pause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the paused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
