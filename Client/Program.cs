using Client;
using MessagePipe;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMessagePipe();
        services.AddMessagePipeNamedPipeInterprocess("sample-pipe", config => config.InstanceLifetime = InstanceLifetime.Singleton );
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();