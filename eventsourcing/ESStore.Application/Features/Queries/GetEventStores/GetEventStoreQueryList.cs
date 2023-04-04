using System.Collections.Generic;
using ESStore.Application.Features.Dtos;
using ESStore.Domain.Aggregates;
using MediatR;

namespace ESStore.Application.Features.Queries.GetEventStores
{
    public class GetEventStoreQueryList : IRequest<List<EventDataDto>>
    {
        public string AggregatorId { get; set; }
        public string EventType { get; set; }
        public string StreamType { get; set; }
        public EEventStoreStatus Status { get; set; }

        public GetEventStoreQueryList(EvenStoreFilterQuery filterQuery)
        {
            AggregatorId = filterQuery.AggregateId;
            EventType = filterQuery.EventType;
            StreamType = filterQuery.StreamType;
            Status = filterQuery.Status;
        }
    }
}
