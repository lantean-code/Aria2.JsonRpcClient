##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# IAria2Client Interface

## Overview

Provides methods for interacting with aria2 via its JSON‑RPC interface.

---

## Methods
<a id="AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null, string? id = null)"></a>
### AddUri

Adds a new download. [uris](#System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris) is an array of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource.
If you mix URIs pointing to different resources, the download may fail or be corrupted.
For BitTorrent Magnet URIs, [uris](#System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris) must have only one element.[options](#System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs. If [position](#System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is given (an integer starting at 0),
the new download is inserted at that position in the waiting queue; if omitted or out of range, it is appended to the end.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addUri)

**Signature:** `System.Threading.Tasks.Task<string> AddUri(string[] uris, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_uris"></a>
- `uris` (`string[]`): An array of URIs pointing to the same resource.
<a id="System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the download.
<a id="System_Threading_Tasks_Task_string__AddUri_string___uris__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null)"></a>
### AddTorrent

Adds a new BitTorrent download by uploading a torrent file (base64 encoded).[options](#System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs.
If [position](#System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is provided, the new download is inserted at that position in the waiting queue; otherwise, appended.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addTorrent](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addTorrent)

**Signature:** `System.Threading.Tasks.Task<string> AddTorrent(string torrent, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_torrent"></a>
- `torrent` (`string`): A base64 encoded torrent file.
<a id="System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the download.
<a id="System_Threading_Tasks_Task_string__AddTorrent_string_torrent__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null, string? id = null)"></a>
### AddMetalink

Adds new downloads from a Metalink file (base64 encoded).[options](#System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options) is a struct with option name/value pairs.
If [position](#System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position) is provided, the downloads are inserted at that position; otherwise, appended.
Returns the GID of the newly registered download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.addMetalink](https://aria2.github.io/manual/en/html/aria2c.html#aria2.addMetalink)

**Signature:** `System.Threading.Tasks.Task<string> AddMetalink(string metalink, Aria2DownloadOptions? options = null, int? position = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_metalink"></a>
- `metalink` (`string`): A base64 encoded Metalink file.
<a id="System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_options"></a>
- `options` ([`Aria2DownloadOptions`](model_Aria2DownloadOptions.md) (optional, default: null)): Download options.
<a id="System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): The position in the waiting queue to insert the downloads.
<a id="System_Threading_Tasks_Task_string__AddMetalink_string_metalink__Aria2DownloadOptions__options___null__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the newly registered download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="Remove(string gid, string? id = null)"></a>
### Remove

Removes the download denoted by [gid](#System_Threading_Tasks_Task_string__Remove_string_gid__string__id___null_gid) from the download queue.
If the download is in progress, it is stopped first.
Returns the GID of the removed download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.remove](https://aria2.github.io/manual/en/html/aria2c.html#aria2.remove)

**Signature:** `System.Threading.Tasks.Task<string> Remove(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__Remove_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to remove.
<a id="System_Threading_Tasks_Task_string__Remove_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the removed download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ForceRemove(string gid, string? id = null)"></a>
### ForceRemove

Forcefully removes the download denoted by [gid](#System_Threading_Tasks_Task_string__ForceRemove_string_gid__string__id___null_gid) from the download queue without performing time‑consuming actions.
Returns the GID of the removed download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceRemove](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceRemove)

**Signature:** `System.Threading.Tasks.Task<string> ForceRemove(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__ForceRemove_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to forcefully remove.
<a id="System_Threading_Tasks_Task_string__ForceRemove_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the removed download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="Pause(string gid, string? id = null)"></a>
### Pause

Pauses the download denoted by [gid](#System_Threading_Tasks_Task_string__Pause_string_gid__string__id___null_gid).
Returns the GID of the paused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.pause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.pause)

**Signature:** `System.Threading.Tasks.Task<string> Pause(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__Pause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to pause.
<a id="System_Threading_Tasks_Task_string__Pause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the paused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="PauseAll(string? id = null)"></a>
### PauseAll

Pauses all active and waiting downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.pauseAll](https://aria2.github.io/manual/en/html/aria2c.html#aria2.pauseAll)

**Signature:** `System.Threading.Tasks.Task PauseAll(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_PauseAll_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ForcePause(string gid, string? id = null)"></a>
### ForcePause

Forcefully pauses the download denoted by [gid](#System_Threading_Tasks_Task_string__ForcePause_string_gid__string__id___null_gid) without performing extra actions.
Returns the GID of the paused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePause)

**Signature:** `System.Threading.Tasks.Task<string> ForcePause(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__ForcePause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to forcefully pause.
<a id="System_Threading_Tasks_Task_string__ForcePause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the paused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ForcePauseAll(string? id = null)"></a>
### ForcePauseAll

Forcefully pauses all active and waiting downloads without extra actions.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePauseAll](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forcePauseAll)

**Signature:** `System.Threading.Tasks.Task ForcePauseAll(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_ForcePauseAll_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="Unpause(string gid, string? id = null)"></a>
### Unpause

Unpauses the download denoted by [gid](#System_Threading_Tasks_Task_string__Unpause_string_gid__string__id___null_gid), changing its status to waiting.
Returns the GID of the unpaused download.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpause](https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpause)

**Signature:** `System.Threading.Tasks.Task<string> Unpause(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_string__Unpause_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to unpause.
<a id="System_Threading_Tasks_Task_string__Unpause_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The GID of the unpaused download.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="UnpauseAll(string? id = null)"></a>
### UnpauseAll

Unpauses all paused downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpauseAll](https://aria2.github.io/manual/en/html/aria2c.html#aria2.unpauseAll)

**Signature:** `System.Threading.Tasks.Task UnpauseAll(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_UnpauseAll_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellStatus(string gid, string[]? keys = null, string? id = null)"></a>
### TellStatus

Returns the status of the download denoted by [gid](#System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__string____keys___null__string__id___null_gid).
The returned object includes various properties describing the download's progress, speed, and other details.
If [keys](#System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__string____keys___null__string__id___null_keys) is specified, only those keys are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2Status> TellStatus(string gid, string[]? keys = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__string____keys___null__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): An optional array of keys to filter the response.
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Status](model_Aria2Status.md) object describing the download's status.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellStatus(string gid, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)"></a>
### TellStatus

Returns the status of the download denoted by [gid](#System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_gid).
The returned object includes various properties describing the download's progress, speed, and other details.
If [keysSelector](#System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector) is specified, only those keys are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2Status> TellStatus(string gid, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): An optional array of keys to filter the response.
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Status__TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Status](model_Aria2Status.md) object describing the download's status.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetUris(string gid, string? id = null)"></a>
### GetUris

Returns an array of URI objects used by the download denoted by [gid](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Uri___GetUris_string_gid__string__id___null_gid).
Each URI object contains the URI and its status.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getUris](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getUris)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Uri>> GetUris(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Uri___GetUris_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Uri___GetUris_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Uri](model_Aria2Uri.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetFiles(string gid, string? id = null)"></a>
### GetFiles

Returns an array of file objects associated with the download denoted by [gid](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2File___GetFiles_string_gid__string__id___null_gid).
Each file object includes details such as file path, size, and progress.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getFiles](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getFiles)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2File>> GetFiles(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2File___GetFiles_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2File___GetFiles_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2File](model_Aria2File.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetPeers(string gid, string? id = null)"></a>
### GetPeers

Returns an array of peer objects associated with the download denoted by [gid](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Peer___GetPeers_string_gid__string__id___null_gid).
Each peer object contains details such as IP address, port, and speed information.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getPeers](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getPeers)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Peer>> GetPeers(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Peer___GetPeers_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Peer___GetPeers_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Peer](model_Aria2Peer.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetServers(string gid, string? id = null)"></a>
### GetServers

Returns a list of currently connected servers for the download denoted by [gid](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Server___GetServers_string_gid__string__id___null_gid).
Each server object contains the original URI, current URI, and download speed.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getServers](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getServers)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Server>> GetServers(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Server___GetServers_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Server___GetServers_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of [Aria2Server](model_Aria2Server.md) objects.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellActive(string[]? keys = null, string? id = null)"></a>
### TellActive

Returns a list of active downloads.
Each download's status is represented as an [Aria2Status](Aria2Status.md) object.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellActive](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellActive)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellActive(string[]? keys = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellActive_string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellActive_string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of active downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellActive(Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)"></a>
### TellActive

Returns a list of active downloads.
Each download's status is represented as an [Aria2Status](Aria2Status.md) object.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellActive](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellActive)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellActive(Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellActive_Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellActive_Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of active downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellWaiting(int offset, int num, string[]? keys = null, string? id = null)"></a>
### TellWaiting

Returns a list of waiting downloads.[offset](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_offset) specifies the starting index (can be negative) and [num](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellWaiting](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellWaiting)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellWaiting(int offset, int num, string[]? keys = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the waiting queue.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of waiting downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellWaiting(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)"></a>
### TellWaiting

Returns a list of waiting downloads.[offset](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset) specifies the starting index (can be negative) and [num](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellWaiting](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellWaiting)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellWaiting(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the waiting queue.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellWaiting_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of waiting downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellStopped(int offset, int num, string[]? keys = null, string? id = null)"></a>
### TellStopped

Returns a list of stopped downloads.[offset](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_offset) specifies the starting index (can be negative) and [num](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellStopped(int offset, int num, string[]? keys = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the stopped queue.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of stopped downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="TellStopped(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)"></a>
### TellStopped

Returns a list of stopped downloads.[offset](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset) specifies the starting index (can be negative) and [num](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Status>> TellStopped(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the stopped queue.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): Optional keys to filter the status objects.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_Aria2_JsonRpcClient_Models_Aria2Status___TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of stopped downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ChangePosition(string gid, int pos, string how, string? id = null)"></a>
### ChangePosition

Changes the position of the download denoted by [gid](#System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_gid) in the queue.[pos](#System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_pos) is an integer, and [how](#System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_how) specifies the mode: 'POS_SET', 'POS_CUR', or 'POS_END'.
Returns the new position as an integer.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changePosition](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changePosition)

**Signature:** `System.Threading.Tasks.Task<int> ChangePosition(string gid, int pos, string how, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_pos"></a>
- `pos` (`int`): The position value.
<a id="System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_how"></a>
- `how` (`string`): The mode of repositioning.
<a id="System_Threading_Tasks_Task_int__ChangePosition_string_gid__int_pos__string_how__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The new position.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null, string? id = null)"></a>
### ChangeUri

Removes URIs specified in [delUris](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_delUris) and appends URIs in [addUris](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_addUris) for the download (and file index) denoted by [gid](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_gid).[fileIndex](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_fileIndex) is 1-based. [position](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_position) specifies the insertion position after deletion.
Returns an array with two integers: the number of URIs deleted and the number of URIs added.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeUri](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeUri)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<int>> ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_fileIndex"></a>
- `fileIndex` (`int`): The 1-based file index.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_delUris"></a>
- `delUris` (`System.Collections.Generic.IEnumerable<string>`): List of URIs to remove.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_addUris"></a>
- `addUris` (`System.Collections.Generic.IEnumerable<string>`): List of URIs to add.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): Optional insertion position (0-based) after deletion.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_int___ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An array of two integers: [number deleted, number added].

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetOption(string gid, string? id = null)"></a>
### GetOption

Returns the options of the download denoted by [gid](#System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Options__GetOption_string_gid__string__id___null_gid) as a struct.
Only options that have been set or have defaults are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getOption)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2Options> GetOption(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Options__GetOption_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Options__GetOption_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Options](model_Aria2Options.md) object with the download's options.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ChangeOption(string gid, Aria2Options options, string? id = null)"></a>
### ChangeOption

Changes the options for the download denoted by [gid](#System_Threading_Tasks_Task_ChangeOption_string_gid__Aria2Options_options__string__id___null_gid).[options](#System_Threading_Tasks_Task_ChangeOption_string_gid__Aria2Options_options__string__id___null_options) is a struct containing option name/value pairs.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeOption)

**Signature:** `System.Threading.Tasks.Task ChangeOption(string gid, Aria2Options options, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_ChangeOption_string_gid__Aria2Options_options__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download to modify.
<a id="System_Threading_Tasks_Task_ChangeOption_string_gid__Aria2Options_options__string__id___null_options"></a>
- `options` ([`Aria2Options`](model_Aria2Options.md)): The options to change.
<a id="System_Threading_Tasks_Task_ChangeOption_string_gid__Aria2Options_options__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetGlobalOption(string? id = null)"></a>
### GetGlobalOption

Returns the global options as a struct.
Only options that have been set or have defaults are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalOption)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2GlobalOptions> GetGlobalOption(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2GlobalOptions__GetGlobalOption_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A dictionary of global options.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ChangeGlobalOption(Aria2GlobalOptions options, string? id = null)"></a>
### ChangeGlobalOption

Changes the global options dynamically.[options](#System_Threading_Tasks_Task_ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_options) is a struct containing option name/value pairs.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeGlobalOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeGlobalOption)

**Signature:** `System.Threading.Tasks.Task ChangeGlobalOption(Aria2GlobalOptions options, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_options"></a>
- `options` ([`Aria2GlobalOptions`](model_Aria2GlobalOptions.md)): The global options to change.
<a id="System_Threading_Tasks_Task_ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

---

<a id="GetGlobalStat(string? id = null)"></a>
### GetGlobalStat

Returns global statistics for the aria2 session.
The returned struct includes overall download/upload speeds and counts of active, waiting, and stopped downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalStat](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalStat)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2GlobalStat> GetGlobalStat(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2GlobalStat__GetGlobalStat_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2GlobalStat](model_Aria2GlobalStat.md) object with global statistics.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetVersion(string? id = null)"></a>
### GetVersion

Returns version information of aria2, including enabled features.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getVersion](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getVersion)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2Version> GetVersion(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2Version__GetVersion_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Version](model_Aria2Version.md) object with version information.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="GetSessionInfo(string? id = null)"></a>
### GetSessionInfo

Returns session information of the current aria2 session, including the session ID.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getSessionInfo](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getSessionInfo)

**Signature:** `System.Threading.Tasks.Task<Aria2.JsonRpcClient.Models.Aria2SessionInfo> GetSessionInfo(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Aria2_JsonRpcClient_Models_Aria2SessionInfo__GetSessionInfo_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2SessionInfo](model_Aria2SessionInfo.md) object with session information.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="Shutdown(string? id = null)"></a>
### Shutdown

Gracefully shuts down aria2, allowing active downloads to complete.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.shutdown](https://aria2.github.io/manual/en/html/aria2c.html#aria2.shutdown)

**Signature:** `System.Threading.Tasks.Task Shutdown(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_Shutdown_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ForceShutdown(string? id = null)"></a>
### ForceShutdown

Forcefully shuts down aria2 immediately without waiting for active downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceShutdown](https://aria2.github.io/manual/en/html/aria2c.html#aria2.forceShutdown)

**Signature:** `System.Threading.Tasks.Task ForceShutdown(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_ForceShutdown_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="SaveSession(string? id = null)"></a>
### SaveSession

Saves the current session to a file specified by the --save-session option.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.saveSession](https://aria2.github.io/manual/en/html/aria2c.html#aria2.saveSession)

**Signature:** `System.Threading.Tasks.Task SaveSession(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_SaveSession_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="PurgeDownloadResult(string? id = null)"></a>
### PurgeDownloadResult

Purges completed, error, or removed downloads from memory.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.purgeDownloadResult](https://aria2.github.io/manual/en/html/aria2c.html#aria2.purgeDownloadResult)

**Signature:** `System.Threading.Tasks.Task PurgeDownloadResult(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_PurgeDownloadResult_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="RemoveDownloadResult(string gid, string? id = null)"></a>
### RemoveDownloadResult

Removes a download result (completed/error/removed) from memory, identified by [gid](#System_Threading_Tasks_Task_RemoveDownloadResult_string_gid__string__id___null_gid).

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.removeDownloadResult](https://aria2.github.io/manual/en/html/aria2c.html#aria2.removeDownloadResult)

**Signature:** `System.Threading.Tasks.Task RemoveDownloadResult(string gid, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_RemoveDownloadResult_string_gid__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download result to remove.
<a id="System_Threading_Tasks_Task_RemoveDownloadResult_string_gid__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="SystemMulticall(params JsonRpcRequest[] methods)"></a>
### SystemMulticall

Encapsulates multiple method calls in a single request.[methods](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_object____SystemMulticall_params_JsonRpcRequest___methods_methods) is an array of [JsonRpcRequest](JsonRpcRequest.md).
Returns an array of responses.

> [https://aria2.github.io/manual/en/html/aria2c.html#system.multicall](https://aria2.github.io/manual/en/html/aria2c.html#system.multicall)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<object?>> SystemMulticall(params JsonRpcRequest[] methods)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_object____SystemMulticall_params_JsonRpcRequest___methods_methods"></a>
- `methods` (`JsonRpcRequest[]`): A list of method calls to execute.

**Returns:**

A list of responses for the method calls.

---

<a id="SystemMulticall(JsonRpcRequest[] methods, string? id = null)"></a>
### SystemMulticall

Encapsulates multiple method calls in a single request.[methods](#System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_object____SystemMulticall_JsonRpcRequest___methods__string__id___null_methods) is an array of [JsonRpcRequest](JsonRpcRequest.md).
Returns an array of responses.

> [https://aria2.github.io/manual/en/html/aria2c.html#system.multicall](https://aria2.github.io/manual/en/html/aria2c.html#system.multicall)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<object?>> SystemMulticall(JsonRpcRequest[] methods, string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_object____SystemMulticall_JsonRpcRequest___methods__string__id___null_methods"></a>
- `methods` (`JsonRpcRequest[]`): A list of method calls to execute.
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_object____SystemMulticall_JsonRpcRequest___methods__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A list of responses for the method calls.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="SystemListMethods(string? id = null)"></a>
### SystemListMethods

Returns an array of all available RPC method names.

> [https://aria2.github.io/manual/en/html/aria2c.html#system.listMethods](https://aria2.github.io/manual/en/html/aria2c.html#system.listMethods)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<string>> SystemListMethods(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_string___SystemListMethods_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A list of method names.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="SystemListNotifications(string? id = null)"></a>
### SystemListNotifications

Returns an array of all available RPC notification names.

> [https://aria2.github.io/manual/en/html/aria2c.html#system.listNotifications](https://aria2.github.io/manual/en/html/aria2c.html#system.listNotifications)

**Signature:** `System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<string>> SystemListNotifications(string? id = null)`


**Parameters:**
<a id="System_Threading_Tasks_Task_System_Collections_Generic_IReadOnlyList_string___SystemListNotifications_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A list of notification names.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ExecuteRequest(JsonRpcRequest<T> request)"></a>
### ExecuteRequest

Executes the a request with a return type of .

**Signature:** `System.Threading.Tasks.Task<T> ExecuteRequest(JsonRpcRequest<T> request)`


**Parameters:**
<a id="System_Threading_Tasks_Task_T__ExecuteRequest_JsonRpcRequest_T__request_request"></a>
- `request` (`JsonRpcRequest<T>`): 

**Returns:**

The result of the request.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

<a id="ExecuteRequest(JsonRpcRequest request)"></a>
### ExecuteRequest

Executes a request with a void return type.

**Signature:** `System.Threading.Tasks.Task ExecuteRequest(JsonRpcRequest request)`


**Parameters:**
<a id="System_Threading_Tasks_Task_ExecuteRequest_JsonRpcRequest_request_request"></a>
- `request` ([`JsonRpcRequest`](JsonRpcRequest.md)): 

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---


## Events
### DownloadStarted

This notification will be sent when a download is started.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---

### DownloadPaused

This notification will be sent when a download is paused.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---

### DownloadStopped

This notification will be sent when a download is stopped by the user.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---

### DownloadComplete

This notification will be sent when a download is complete.For
BitTorrent downloads, this notification is sent when the download is
complete and seeding is over.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---

### DownloadError

This notification will be sent when a download is stopped due to an error.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---

### BtDownloadComplete

This notification will be sent when a torrent download is complete but seeding
is still going on.
The paramter is the GID of the download.


**Callback:**
`System.Action<string>`


---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
