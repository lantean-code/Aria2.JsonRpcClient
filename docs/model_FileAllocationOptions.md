##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# FileAllocationOptions Enum

## Overview

Represents file allocation method.

---

## Members
#### `None`
No file allocation method is specified.
> JSON value: `none`
#### `Prealloc`
Pre-allocate file space before download begins.
> JSON value: `prealloc`
#### `Trunc`
Allocate file space as the download progresses.
> JSON value: `trunc`
#### `Falloc`
Use the file system's fallocate function to pre-allocate space.
> JSON value: `falloc`



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
