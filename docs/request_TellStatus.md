##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# TellStatus

## Overview

Represents a request to get the status of a download.

---

## Constructors
#### `TellStatus(string gid, string[]? keys = null, string? id = null)`

Returns the status of the download denoted by [gid](#TellStatus_string_gid__string____keys___null__string__id___null_gid).
The returned object includes various properties describing the download's progress, speed, and other details.
If [keys](#TellStatus_string_gid__string____keys___null__string__id___null_keys) is specified, only those keys are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus)

**Parameters:**
<a id="TellStatus_string_gid__string____keys___null__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="TellStatus_string_gid__string____keys___null__string__id___null_keys"></a>
- `keys` (`string[]` (optional, default: null)): An optional array of keys to filter the response.
<a id="TellStatus_string_gid__string____keys___null__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Status](model_Aria2Status.md) object describing the download's status.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---

#### `TellStatus(string gid, Expression<Func<Aria2Status, object?>> keysSelector, string? id = null)`

Returns the status of the download denoted by [gid](#TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_gid).
The returned object includes various properties describing the download's progress, speed, and other details.
If [keysSelector](#TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector) is specified, only those keys are returned.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus](https://aria2.github.io/manual/en/html/aria2c.html#aria2.tellStatus)

**Parameters:**
<a id="TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_keysSelector"></a>
- `keysSelector` (`System.Linq.Expressions.Expression<System.Func<Aria2.JsonRpcClient.Models.Aria2Status, object?>>`): An optional array of keys to filter the response.
<a id="TellStatus_string_gid__Expression_Func_Aria2Status__object____keysSelector__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

An [Aria2Status](model_Aria2Status.md) object describing the download's status.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
