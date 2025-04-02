##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2File Model 

---

## Overview

Represents a file within a download.

---

## Properties
<a id="Index"></a>
#### `int` Index 

Index of the file, starting at 1, in the same order as files appear in the multi-file torrent.
> JSON key: `index`

<a id="Path"></a>
#### `string` Path 

File path.
> JSON key: `path`

<a id="Length"></a>
#### `long` Length 

File size in bytes.
> JSON key: `length`

<a id="CompletedLength"></a>
#### `long` CompletedLength 

Completed length of this file in bytes. Please note that it is possible that sum of [CompletedLength](#CompletedLength) is less than the  returned by the [IAria2Client.GetFiles](client.md) method. This is because completedLength in [IAria2Client.GetFiles](client.md) only includes completed pieces. On the other hand, completedLength in [IAria2Client.TellStatus(string, string[], string?)](client.md) also includes partially completed pieces.
> JSON key: `completedLength`

<a id="Selected"></a>
#### `bool` Selected 

true if this file is selected by [Aria2DownloadOptions.SelectFile](model_SelectFile.md) option. If[Aria2DownloadOptions.SelectFile](model_SelectFile.md) is not specified or this is single-file torrent or not a torrent download at all, this value is always true. Otherwise false.
> JSON key: `selected`

<a id="Uris"></a>
#### `System.Collections.Generic.IReadOnlyList<Aria2.JsonRpcClient.Models.Aria2Uri>?` Uris 

Returns a list of URIs for this file.
> JSON key: `uris`


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
