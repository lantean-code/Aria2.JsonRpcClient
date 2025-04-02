##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2Bittorrent Model 

---

## Overview

Represents information retrieved from the .torrent (file).

---

## Properties
<a id="AnnounceList"></a>
#### `System.Collections.Generic.IReadOnlyList<string[]>?` AnnounceList 

List of lists of announce URIs. If the torrent contains announce and no announce-list, announce is converted to the announce-list format.
> JSON key: `announceList`

<a id="Comment"></a>
#### `string` Comment 

The comment of the torrent. comment.utf-8 is used if available.
> JSON key: `comment`

<a id="CreationDate"></a>
#### `long` CreationDate 

The creation date of the torrent. The value is an integer since the epoch, measured in seconds.
> JSON key: `creationDate`

<a id="Mode"></a>
#### [`TorrentModeOptions`](model_TorrentModeOptions.md) Mode 

File mode of the torrent.
> JSON key: `mode`

<a id="Info"></a>
#### [`Aria2TorrentInfo`](model_Aria2TorrentInfo.md) Info 

Contains data from Info dictionary.
> JSON key: `info`


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
