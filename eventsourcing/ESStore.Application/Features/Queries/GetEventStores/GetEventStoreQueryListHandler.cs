using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESStore.Application.Contracts.Store;
using ESStore.Application.Features.Dtos;
using MediatR;

namespace ESStore.Application.Features.Queries.GetEventStores
{
    public class GetEventStoreQueryListHandler : IRequestHandler<GetEventStoreQueryList, List<EventDataDto>>
    {
        private readonly IMapper _mapper;

        private readonly IAggregateStore _aggregateStore;

        public GetEventStoreQueryListHandler(IMapper mapper, IAggregateStore aggregateStore)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _aggregateStore = aggregateStore ?? throw new ArgumentNullException(nameof(aggregateStore));
        }

        public Task<List<EventDataDto>> Handle(GetEventStoreQueryList request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
