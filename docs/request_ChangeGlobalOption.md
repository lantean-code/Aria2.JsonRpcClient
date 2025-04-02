##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# ChangeGlobalOption

## Overview

Represents a request to change the global options of the aria2 client.

---

## Constructors
#### `ChangeGlobalOption(Aria2GlobalOptions options, string? id = null)`

Changes the global options dynamically.[options](#ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_options) is a struct containing option name/value pairs.

> [https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeGlobalOption](https://aria2.github.io/manual/en/html/aria2c.html#aria2.changeGlobalOption)

**Parameters:**
<a id="ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_options"></a>
- `options` ([`Aria2GlobalOptions`](model_Aria2GlobalOptions.md)): The global options to change.
<a id="ChangeGlobalOption_Aria2GlobalOptions_options__string__id___null_id"></a>
- `id` (`string` (optional, default: null)): The tracking id for the request. If this is omitted it will be generated automatically.

---




##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
