##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# RemoveDownloadResult

## Overview

Represents a request to remove a download result.

---

## Constructors
#### `RemoveDownloadResult(string gid, string? id = null)`

Removes a download result (completed/error/removed) from memory, identified by [gid](#RemoveDownloadResult_string_gid__string__id___null_gid).

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.removeDownloadResult](https://aria2.github.io/manual/en/html/aria2c.html#aria2.removeDownloadResult)

**Parameters:**
<a id="RemoveDownloadResult_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download result to remove.
<a id="RemoveDownloadResult_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
