##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetServers

## Overview

Represents a request to get the servers of a download.

---

## Constructors
#### `GetServers(string gid, string? id = null)`

Returns a list of currently connected servers for the download denoted by [gid](#GetServers_string_gid__string__id___null_gid).
Each server object contains the original URI, current URI, and download speed.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getServers](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getServers)

**Parameters:**
<a id="GetServers_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="GetServers_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Server](model_Aria2Server.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
