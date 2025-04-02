##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2Peer Model 

---

## Overview

Represents a peer for a BitTorrent download.

---

## Properties
<a id="PeerId"></a>
#### `string` PeerId 

Percent-encoded peer ID.
> JSON key: `peerId`

<a id="Ip"></a>
#### `string` Ip 

IP address of the peer.
> JSON key: `ip`

<a id="Port"></a>
#### `int` Port 

Port number of the peer.
> JSON key: `port`

<a id="Bitfield"></a>
#### `string` Bitfield 

Hexadecimal representation of the download progress of the peer. The highest bit corresponds to the piece at index 0. Set bits indicate the piece is available and unset bits indicate the piece is missing. Any spare bits at the end are set to zero.
> JSON key: `bitfield`

<a id="AmChoking"></a>
#### `bool` AmChoking 

true if aria2 is choking the peer. Otherwise false.
> JSON key: `amChoking`

<a id="PeerChoking"></a>
#### `bool` PeerChoking 

true if the peer is choking aria2. Otherwise false.
> JSON key: `peerChoking`

<a id="DownloadSpeed"></a>
#### `long` DownloadSpeed 

Download speed (byte/sec) that this client obtains from the peer.
> JSON key: `downloadSpeed`

<a id="UploadSpeed"></a>
#### `long` UploadSpeed 

Upload speed(byte/sec) that this client uploads to the peer.
> JSON key: `uploadSpeed`

<a id="Seeder"></a>
#### `bool` Seeder 

true if this peer is a seeder. Otherwise false.
> JSON key: `seeder`


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
