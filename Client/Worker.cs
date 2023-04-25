using MessagePipe;

namespace Client;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IRemoteRequestHandler<int, string> _remoteHandler;

    public Worker(ILogger<Worker> logger, IRemoteRequestHandler<int, string> remoteHandler)
    {
        _logger = logger;
        _remoteHandler = remoteHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            int request = DateTimeOffset.Now.Millisecond;
            _logger.LogDebug("Sending: {request}", request);
            var result = await _remoteHandler.InvokeAsync(request);
            _logger.LogDebug("Received: {result}", result);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
