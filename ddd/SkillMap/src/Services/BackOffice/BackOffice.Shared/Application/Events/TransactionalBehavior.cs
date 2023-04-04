using BackOffice.Shared.Application.Events.Interfaces;
using MediatR;

namespace BackOffice.Shared.Events
{
    public class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _context;

        public TransactionalBehavior(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_context.IsThereATransactionInProgress())
            {
                var result = await next();

                return result;

            }
            var response = default(TResponse);

            try
            {

                await _context.BeginTransaction();

                response = await next();

                await _context.CommitTransaction();

                return response;
            }
            catch
            {
                await _context.RollbackTransaction();

                throw;
            }
        }
    }
}
