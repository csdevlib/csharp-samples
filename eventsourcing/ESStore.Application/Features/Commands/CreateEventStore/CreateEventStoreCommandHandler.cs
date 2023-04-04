using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESStore.Application.Contracts.Store;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ESStore.Application.Features.Commands.CreateEventStore
{
    public class CreateEventStoreCommandHandler : IRequestHandler<CreateEventStoreCommand, bool>
    {
        private readonly IAggregateStore _aggregatoreStore;
        
        private readonly IMapper _mapper;
        
        private readonly ILogger<CreateEventStoreCommandHandler> _logger;

        public CreateEventStoreCommandHandler(IAggregateStore aggregatoreStore, IMapper mapper, ILogger<CreateEventStoreCommandHandler> logger)
        {
            _aggregatoreStore = aggregatoreStore ?? throw new ArgumentNullException(nameof(aggregatoreStore));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateEventStoreCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();

            await _aggregatoreStore.Save(request.Aggregate, id);

            return true;
        }
    }
}
