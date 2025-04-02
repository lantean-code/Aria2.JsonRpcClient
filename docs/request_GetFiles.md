##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetFiles

## Overview

Represents a request to get the files of a download.

---

## Constructors
#### `GetFiles(string gid, string? id = null)`

Returns an array of file objects associated with the download denoted by [gid](#GetFiles_string_gid__string__id___null_gid).
Each file object includes details such as file path, size, and progress.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getFiles](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getFiles)

**Parameters:**
<a id="GetFiles_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="GetFiles_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2File](model_Aria2File.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
