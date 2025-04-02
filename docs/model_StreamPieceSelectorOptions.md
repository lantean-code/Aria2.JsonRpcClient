##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# StreamPieceSelectorOptions Enum

## Overview

Represents the algorithm used for selecting pieces in segmented downloads.

---

## Members
#### `Default`
Select a piece to reduce the number of connections established. This is reasonable default behavior because establishing a connection is an expensive operation.
> JSON value: `default`
#### `Inorder`
Select a piece closest to the beginning of the file. This is useful for viewing movies while downloading.  option may be useful to reduce re-connection overhead. Note that aria2 honors  option, so it will be necessary to specify a reasonable value to  option.
> JSON value: `inorder`
#### `Random`
Select a piece randomly. Like [Inorder](Inorder.md),  option is honored.
> JSON value: `random`
#### `Geom`
When starting to download a file, select a piece closest to the beginning of the file like [Inorder](Inorder.md), but then exponentially increases space between pieces. This reduces the number of connections established, while at the same time downloads the beginning part of the file first. This is useful for viewing movies while downloading.
> JSON value: `geom`



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
