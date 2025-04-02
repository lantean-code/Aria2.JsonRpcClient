##### Aria2.JsonRpcClient Documentation  - [Home](index.md) | [Client](client.md) | [Requests](requests.md) | [Models](models.md) | [Examples](examples.md)

# Aria2GlobalStat Model 

---

## Overview

Represents global statistics for the aria2 session.

---

## Properties
<a id="DownloadSpeed"></a>
#### `long` DownloadSpeed 

Overall download speed (byte/sec).
> JSON key: `downloadSpeed`

<a id="UploadSpeed"></a>
#### `long` UploadSpeed 

Overall upload speed(byte/sec).
> JSON key: `uploadSpeed`

<a id="NumActive"></a>
#### `int` NumActive 

The number of active downloads.
> JSON key: `numActive`

<a id="NumWaiting"></a>
#### `int` NumWaiting 

The number of waiting downloads.
> JSON key: `numWaiting`

<a id="NumStopped"></a>
#### `int` NumStopped 

The number of stopped downloads in the current session. This value is capped by the --max-download-result option.
> JSON key: `numStopped`

<a id="NumStoppedTotal"></a>
#### `int` NumStoppedTotal 

The number of stopped downloads in the current session and not capped by the --max-download-result option.
> JSON key: `numStoppedTotal`


---



##### [Top](#top)
##### © [lantean-code](https://github.com/lantean-code) - _Generated on 2025-04-02_
