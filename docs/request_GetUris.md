##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetUris

## Overview

Represents a request to get the URIs of a download.

---

## Constructors
#### `GetUris(string gid, string? id = null)`

Returns an array of URI objects used by the download denoted by [gid](#GetUris_string_gid__string__id___null_gid).
Each URI object contains the URI and its status.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getUris](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getUris)

**Parameters:**
<a id="GetUris_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="GetUris_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Uri](model_Aria2Uri.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
