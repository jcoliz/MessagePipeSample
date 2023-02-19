using MessagePipe;
using Server;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMessagePipe();
        services.AddMessagePipeNamedPipeInterprocess("sample-pipe");
    })
    .Build();

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