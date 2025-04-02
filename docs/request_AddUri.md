##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# AddUri

## Overview

Represents a request to add a download from a list of URIs.

---

## Constructors
#### `AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`

Adds a new download. [uris](#AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris) is an array of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource.
If you mix URIs pointing to different resources, the download may fail or be corrupted.
For BitTorrent Magnet URIs, [uris](#AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris) must have only one element.[options](#AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs. If [position](#AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is given (an integer starting at 0),
the new download is inserted at that position in the waiting queue; if omitted or out of range, it is appended to the end.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri)

**Parameters:**
<a id="AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris"></a>
- `uris` (`string[]`): An array of URIs pointing to the same resource.
<a id="AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the download.
<a id="AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
