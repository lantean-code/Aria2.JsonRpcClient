##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetOption

## Overview

Represents a request to get the options of a download.

---

## Constructors
#### `GetOption(string gid, string? id = null)`

Returns the options of the download denoted by [gid](#GetOption_string_gid__string__id___null_gid) as a struct.
Only options that have been set or have defaults are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getOption)

**Parameters:**
<a id="GetOption_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="GetOption_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Options](model_Aria2Options.md) object with the download's options.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
