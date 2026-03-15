using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.PipelineBehaviours.Contract;

namespace Application.PipelineBehaviours
{
    public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>,ILogMe
    {
        private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;
        public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest,TResponse>>logger)
        {
            _logger = logger;
            
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("currently handling request:{request}",typeof(TRequest).Name);
            var response =await next();
            _logger.LogInformation(" currently handling Response: {response}",typeof(TResponse).Name);
            return response;
        }
    }
}
