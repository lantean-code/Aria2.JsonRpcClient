##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# JsonRpcRequest\<T\> `abstract`

---

## Overview

An abstract Json RPC request with a return type. Inherit from this to add addtional aria2 requests.

**Inherits from:** [`JsonRpcRequest`](JsonRpcRequest.md)

---

## Constructors
#### `JsonRpcRequest(string method, JsonRpcParameters parameters, string? id = null)`

Initializes a new instance of the [JsonRpcRequest{T}](JsonRpcRequest{T}.md) class.

**Parameters:**
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_method"></a>
- `method` (`string`): The name of the method to be called.
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_parameters"></a>
- `parameters` ([`JsonRpcParameters`](JsonRpcParameters.md)): The parameters to be passed to the method.
<a id="JsonRpcRequest_string_method__JsonRpcParameters_parameters__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The id of the request.

---


## Methods
<a id="GetResult(object? value)"></a>
### GetResult

A helper method to cast the response of a [IAria2Client.SystemMulticall(JsonRpcRequest[])](client.md) to the correct type.

**Signature:** `static` `T GetResult(object? value)`


**Parameters:**
<a id="T_GetResult_object__value_value"></a>
- `value` (`object`): 

**Throws:**

`ArgumentNullException`


---

<a id="IsError(object? value, [NotNullWhen(true)] out JsonRpcError? jsonRpcError)"></a>
### IsError

Helper method to determine if the response of a [IAria2Client.SystemMulticall(JsonRpcRequest[])](client.md) is an error.

**Signature:** `static` `bool IsError(object? value, [NotNullWhen(true)] out JsonRpcError? jsonRpcError)`


**Parameters:**
<a id="bool_IsError_object__value___NotNullWhen_true___out_JsonRpcError__jsonRpcError_value"></a>
- `value` (`object`): 
<a id="bool_IsError_object__value___NotNullWhen_true___out_JsonRpcError__jsonRpcError_jsonRpcError"></a>
- `jsonRpcError` ([`JsonRpcError`](JsonRpcError.md)): 

---


## Properties
<a id="ReturnType"></a>
#### `System.Type` ReturnType 

The type of the return value. This is always a .


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
