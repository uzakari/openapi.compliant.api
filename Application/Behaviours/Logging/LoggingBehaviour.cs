﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours.Logging;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        var response = await next();
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        return response;
    }
}