##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# PurgeDownloadResult

## Overview

Represents a request to purge the download result of a completed/error/removed download.

---

## Constructors
#### `PurgeDownloadResult(string? id = null)`

Purges completed, error, or removed downloads from memory.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.purgeDownloadResult](https://aria2.github.io/manual/en/html/aria2c.html#aria2.purgeDownloadResult)

**Parameters:**
<a id="PurgeDownloadResult_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
