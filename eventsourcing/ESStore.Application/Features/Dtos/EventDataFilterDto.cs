namespace ESStore.Application.Features.Dtos
{
    public class EventDataFilterDto
    {
        public string StreamId { get; set; }
        public string EventId { get; set; }
        public string AggregateId { get; set; }
    }
}
