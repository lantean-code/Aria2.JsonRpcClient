##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# JsonRpcRequest `abstract`

---

## Overview

An abstract Json RPC request. Inherit from this to add addtional aria2 requests.

---

## Constructors
#### `JsonRpcRequest(string method, JsonRpcParameters parameters, string? id = null)`

Initializes a new instance of the [JsonRpcRequest](JsonRpcRequest.md) class.

**Parameters:**
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_method"></a>
- `method` (`string`): The name of the method to be called.
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_parameters"></a>
- `parameters` ([`JsonRpcParameters`](JsonRpcParameters.md)): The parameters to be passed to the method.
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The id of the request.

---


## Properties
<a id="JsonRpc"></a>
#### `string` JsonRpc 

The JSON-RPC version - for Aira2, this is always "2.0".
> JSON key: `jsonrpc`

<a id="Method"></a>
#### `string` Method 

The name of the method to be called.
> JSON key: `method`

<a id="Parameters"></a>
#### [`JsonRpcParameters`](JsonRpcParameters.md) Parameters 

The parameters to be passed to the method.
> JSON key: `params`

<a id="Id"></a>
#### `string` Id 

The id of the request.
> JSON key: `id`

<a id="ReturnType"></a>
#### `System.Type` ReturnType 

The type of the return value. This will always be typeof(void).


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
