##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ChangePosition

## Overview

Represents a request to change the position of a download.

---

## Constructors
#### `ChangePosition(string gid, int pos, string how, string? id = null)`

Changes the position of the download denoted by [gid](#ChangePosition_string_gid__int_pos__string_how__string__id___null_gid) in the queue.[pos](#ChangePosition_string_gid__int_pos__string_how__string__id___null_pos) is an integer, and [how](#ChangePosition_string_gid__int_pos__string_how__string__id___null_how) specifies the mode: 'POS_SET', 'POS_CUR', or 'POS_END'.
Returns the new position as an integer.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changePosition](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changePosition)

**Parameters:**
<a id="ChangePosition_string_gid__int_pos__string_how__string__id___null_gid"></a>
- `gid` (`string`): The GID of the download.
<a id="ChangePosition_string_gid__int_pos__string_how__string__id___null_pos"></a>
- `pos` (`int`): The position value.
<a id="ChangePosition_string_gid__int_pos__string_how__string__id___null_how"></a>
- `how` (`string`): The mode of repositioning.
<a id="ChangePosition_string_gid__int_pos__string_how__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

**Returns:**

The new position.

**Throws:**

[`Aria2Exception`](Aria2Exception.md)
Thrown when an aria2 error occurs.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
