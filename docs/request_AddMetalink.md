##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# AddMetalink

## Overview

Represents a request to add a Metalink download.

---

## Constructors
#### `AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`

Adds new downloads from a Metalink file (base64 encoded).[options](#AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs.
If [position](#AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is provided, the downloads are inserted at that position; otherwise, appended.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addMetalink](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addMetalink)

**Parameters:**
<a id="AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_metalink"></a>
- `metalink` (`string`): A base64 encoded Metalink file.
<a id="AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the downloads.
<a id="AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
