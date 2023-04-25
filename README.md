# Interprocess Communication in .NET with MessagePipe and named pipes

This quick example shows how to use the [MessagePipe](https://github.com/Cysharp/MessagePipe) project with named pipes to achieve IPC in .NET.

## Getting started

1. Run the Server app
2. Run the Client app

```
PS .\MessagePipeSample\Server> dotnet run
Building...
<6> [ 25/04/2023 11:40:44 ] Microsoft.Hosting.Lifetime[0] Application started. Press Ctrl+C to shut down.
<6> [ 25/04/2023 11:40:44 ] Microsoft.Hosting.Lifetime[0] Hosting environment: Development
<6> [ 25/04/2023 11:40:44 ] Microsoft.Hosting.Lifetime[0] Content root path: .\MessagePipeSample\Server
<7> [ 25/04/2023 11:40:54 ] Server.Worker[0] Running
<7> [ 25/04/2023 11:40:55 ] Server.RequestHandler[0] Received: 320
<7> [ 25/04/2023 11:40:55 ] Server.RequestHandler[0] Sending: ECHO:320
<7> [ 25/04/2023 11:40:56 ] Server.RequestHandler[0] Received: 404
<7> [ 25/04/2023 11:40:56 ] Server.RequestHandler[0] Sending: ECHO:404
<7> [ 25/04/2023 11:40:57 ] Server.RequestHandler[0] Received: 421
<7> [ 25/04/2023 11:40:57 ] Server.RequestHandler[0] Sending: ECHO:421
```

```
PS .\MessagePipeSample\Client> dotnet run
Building...
<6> [ 25/04/2023 11:40:55 ] Microsoft.Hosting.Lifetime[0] Application started. Press Ctrl+C to shut down.
<6> [ 25/04/2023 11:40:55 ] Microsoft.Hosting.Lifetime[0] Hosting environment: Development
<6> [ 25/04/2023 11:40:55 ] Microsoft.Hosting.Lifetime[0] Content root path: .\MessagePipeSample\Client
<7> [ 25/04/2023 11:40:55 ] Client.Worker[0] Sending: 320
<7> [ 25/04/2023 11:40:55 ] Client.Worker[0] Received: ECHO:320
<7> [ 25/04/2023 11:40:56 ] Client.Worker[0] Sending: 404
<7> [ 25/04/2023 11:40:56 ] Client.Worker[0] Received: ECHO:404
<7> [ 25/04/2023 11:40:57 ] Client.Worker[0] Sending: 421
<7> [ 25/04/2023 11:40:57 ] Client.Worker[0] Received: ECHO:421
```
