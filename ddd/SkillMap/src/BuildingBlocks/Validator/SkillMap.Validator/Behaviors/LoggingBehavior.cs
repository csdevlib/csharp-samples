﻿namespace SkillMap.Validator.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"{DateTime.UtcNow.ToShortDateString()} {DateTime.Now.ToShortTimeString()}: Handling command {request.GetGenericTypeName()} ({request})");

        var response = await next();

        _logger.LogInformation($" Command {request.GetGenericTypeName()} handled - response: {response}");

        return response;
    }
}

