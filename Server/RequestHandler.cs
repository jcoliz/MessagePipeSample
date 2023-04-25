using MessagePipe;

namespace Server;

public class RequestHandler : IAsyncRequestHandler<int, string>
{
    private readonly ILogger<RequestHandler> _logger;

    public RequestHandler(ILogger<RequestHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<string> InvokeAsync(int request, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Received: {request}", request);

        await Task.Delay(1);
        if (request == -1)
        {
            throw new Exception("NO -1");
        }
        else
        {
            var result = $"ECHO:{request}";
            _logger.LogDebug("Sending: {result}", result);
            return result;
        }
    }
}