##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ChangeUri

## Overview

Represents a request to change the URIs of a download.

---

## Constructors
#### `ChangeUri(string gid, int fileIndex, IEnumerable<string> delUris, IEnumerable<string> addUris, int? position = null, string? id = null)`

Removes URIs specified in [delUris](#ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_delUris) and appends URIs in [addUris](#ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_addUris) for the download (and file index) denoted by [gid](#ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_gid).[fileIndex](#ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_fileIndex) is 1-based. [position](#ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_position) specifies the insertion position after deletion.
Returns an array with two integers: the number of URIs deleted and the number of URIs added.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeUri](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeUri)

**Parameters:**
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_fileIndex"></a>
- `fileIndex` (`int`): The 1-based file index.
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_delUris"></a>
- `delUris` (`System.Collections.Generic.IEnumerable<string>`): List of URIs to remove.
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_addUris"></a>
- `addUris` (`System.Collections.Generic.IEnumerable<string>`): List of URIs to add.
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_position"></a>
- `position` (`int` (optional, default: null)): Optional insertion position (0-based) after deletion.
<a id="ChangeUri_string_gid__int_fileIndex__IEnumerable_string__delUris__IEnumerable_string__addUris__int__position___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An array of two integers: [number deleted, number added].

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
