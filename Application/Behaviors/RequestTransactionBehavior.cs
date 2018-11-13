using System;
using System.Threading;
using System.Threading.Tasks;
using Dom;
using MediatR;
using Serilog;


namespace Application.Behaviors
{
    public class RequestTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly MyAppContext _context;

        public RequestTransactionBehavior(MyAppContext context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await _context.Database.BeginTransactionAsync(cancellationToken);
                var response = await next();
                
                _context.Database.CommitTransaction();
                return response;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                Log.Error("Rollback request");
                throw;
            }
        }
    }
}
