##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# GetGlobalStat

## Overview

Represents a request to get the global statistics of the aria2 client.

---

## Constructors
#### `GetGlobalStat(string? id = null)`

Returns global statistics for the aria2 session.
The returned struct includes overall download/upload speeds and counts of active, waiting, and stopped downloads.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalStat](https://aria2.github.io/manual/en/html/aria2c.html#aria2.getGlobalStat)

**Parameters:**
<a id="GetGlobalStat_string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2GlobalStat](model_Aria2GlobalStat.md) object with global statistics.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
