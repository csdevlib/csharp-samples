using System.Collections.Generic;

namespace ESStore.Application.Features.Dtos
{
    public class EventDataDto
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string EventType { get; set; }
        public Dictionary<string, object> EventMetadata { get; set; }
        public string EventDate { get; set; }
        public string StreamId { get; set; }
        public string StreamType { get; set; }
        public string StreamData { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
