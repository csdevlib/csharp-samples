namespace ESStore.Application.Features.Queries.GetEventStores
{
    public class EvenStoreFilterQuery 
    {
        public string AggregateId { get; set; }
        public string EventType { get; set; }
        public string StreamType { get; set; }  
    }
}
