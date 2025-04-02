##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# UriSelectorOptions Enum

## Overview

Represents URI selection algorithm.

---

## Members
#### `Inorder`
URI is tried in the order appeared in the URI list.
> JSON value: `inorder`
#### `Feedback`
aria2 uses download speed observed in the previous downloads and choose fastest server in the URI list. This also effectively skips dead mirrors.
> JSON value: `feedback`
#### `Adaptive`
Selects one of the best mirrors for the first and reserved connections. For supplementary ones, it returns mirrors which has not been tested yet, and if each of them has already been tested, returns mirrors which has to be tested again. Otherwise, it doesn't select anymore mirrors.
> JSON value: `adaptive`



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
