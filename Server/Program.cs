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
        services.AddSingleton<IAsyncRequestHandler<int, string>, MyAsyncHandler>();
    })
    .Build();

// See https://github.com/Cysharp/MessagePipe/issues/99
using var namedPipeWorker = host.Services.GetRequiredService<NamedPipeWorker>(); 

host.Run();

public class MyAsyncHandler : IAsyncRequestHandler<int, string>
{
    public async ValueTask<string> InvokeAsync(int request, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1);
        if (request == -1)
        {
            throw new Exception("NO -1");
        }
        else
        {
            return "ECHO:" + request.ToString();
        }
    }
}