using MessagePipe;
using MessagePipe.Interprocess.Workers;
using Server;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMessagePipe();
        services.AddMessagePipeNamedPipeInterprocess("sample-pipe", config => 
		{	
			config.InstanceLifetime = InstanceLifetime.Singleton;
			config.HostAsServer = true; // Should be true for server side.
		});
        services.AddSingleton<IAsyncRequestHandler<int, string>, RequestHandler>();
    })
    .Build();

try
{
    // See https://github.com/Cysharp/MessagePipe/issues/99
    using var namedPipeWorker = host.Services.GetRequiredService<NamedPipeWorker>();
    host.Run();
}
catch (System.ObjectDisposedException)
{
    // This is expected due to the workaround above
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR {ex.GetType()} {ex.Message}");
}
