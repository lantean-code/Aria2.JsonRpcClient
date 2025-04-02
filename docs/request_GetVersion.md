##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetVersion

## Overview

Represents a request to get the version of the aria2 client.

---

## Constructors
#### `GetVersion(string? id = null)`

Returns version information of aria2, including enabled features.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getVersion](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getVersion)

**Parameters:**
<a id="GetVersion_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Version](model_Aria2Version.md) object with version information.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
