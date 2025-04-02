##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# AddTorrent

## Overview

Represents a request to add a torrent download.

---

## Constructors
#### `AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`

Adds a new BitTorrent download by uploading a torrent file (base64 encoded).[options](#AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs.
If [position](#AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is provided, the new download is inserted at that position in the waiting queue; otherwise, appended.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addTorrent](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addTorrent)

**Parameters:**
<a id="AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_torrent"></a>
- `torrent` (`string`): A base64 encoded torrent file.
<a id="AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the download.
<a id="AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
