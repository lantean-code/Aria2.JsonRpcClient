##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetPeers

## Overview

Represents a request to get the peers of a download.

---

## Constructors
#### `GetPeers(string gid, string? id = null)`

Returns an array of peer objects associated with the download denoted by [gid](#GetPeers_string_gid__string__id___null_gid).
Each peer object contains details such as IP address, port, and speed information.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getPeers](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getPeers)

**Parameters:**
<a id="GetPeers_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="GetPeers_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Peer](model_Aria2Peer.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
