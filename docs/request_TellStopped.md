##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# TellStopped

## Overview

Represents a request to get the list of stopped downloads.

---

## Constructors
#### `TellStopped(int offset, int num, string[]? keys = null, string? id = null)`

Returns a list of stopped downloads.[offset](#TellStopped_int_offset__int_num__string____keys___null__string__id___null_offset) specifies the starting index (can be negative) and [num](#TellStopped_int_offset__int_num__string____keys___null__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped)

**Parameters:**
<a id="TellStopped_int_offset__int_num__string____keys___null__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the stopped queue.
<a id="TellStopped_int_offset__int_num__string____keys___null__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="TellStopped_int_offset__int_num__string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): Optional keys to filter the status objects.
<a id="TellStopped_int_offset__int_num__string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of stopped downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

#### `TellStopped(int offset, int num, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`

Returns a list of stopped downloads.[offset](#TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset) specifies the starting index (can be negative) and [num](#TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num) specifies the maximum number to return.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStopped)

**Parameters:**
<a id="TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_offset"></a>
- `offset` (`int`): The starting index in the stopped queue.
<a id="TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_num"></a>
- `num` (`int`): The maximum number of downloads to return.
<a id="TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): Optional keys to filter the status objects.
<a id="TellStopped_int_offset__int_num__Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

A read-only list of stopped downloads.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
