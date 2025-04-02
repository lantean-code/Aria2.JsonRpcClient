##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ChangeOption

## Overview

Represents a request to change the options of a download.

---

## Constructors
#### `ChangeOption(string gid, Aria2Options options, string? id = null)`

Changes the options for the download denoted by [gid](#ChangeOption_string_gid__Aria2Options_options__string__id___null_gid).[options](#ChangeOption_string_gid__Aria2Options_options__string__id___null_options) is a struct containing option name/value pairs.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeOption)

**Parameters:**
<a id="ChangeOption_string_gid__Aria2Options_options__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to modify.
<a id="ChangeOption_string_gid__Aria2Options_options__string__id___null_options"></a>
- `options` ([`Aria2Options`](model_Aria2Options.md)): The options to change.
<a id="ChangeOption_string_gid__Aria2Options_options__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
