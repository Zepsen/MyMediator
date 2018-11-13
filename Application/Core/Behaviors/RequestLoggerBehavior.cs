using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Serilog;
using Serilog.Events;


namespace Application.Core.Behaviors
{
    public class RequestLoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public RequestLoggerBehavior()
        {
            
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Log.Information(Environment.NewLine);
            Log.Warning(@"Request {0} begin", typeof(TRequest).Name);
            
            var response = await next();

            Log.Warning(@"Response {0} end" + Environment.NewLine, typeof(TRequest).Name);

            return response;
        }
    }
}
