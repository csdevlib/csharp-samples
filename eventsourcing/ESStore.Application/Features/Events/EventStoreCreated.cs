using BeyondNet.Patterns.NetDdd.Core.Impl;
using System;
using System.Collections.Generic;

namespace ESStore.Application.Features.Events
{
    public class EventStoreCreated : AbstractDomainEvent
    {
        public string EventId { get; set; }
        public string EventType { get; set; }
        public IDictionary<string, object> EventMetadata { get; set; }
        public DateTime EventDate { get; set; }
        public string StreamId { get; set; }
        public string StreamType { get; set; }
        public object StreamData { get; set; }
        public string Creator{ get; set; }

        public EventStoreCreated(string eventId, 
                                 string eventType,  
                                 IDictionary<string, object> eventMetadata,
                                 DateTime eventDate,
                                 string streamId, 
                                 string streamType, 
                                 object streamData, 
                                 string creator)
        {
            EventId = eventId;
            EventType = eventType;
            EventMetadata = eventMetadata;
            EventDate = eventDate;
            StreamId = streamId;
            StreamType = streamType;
            StreamData = streamData;
            Creator = creator;
        }
    }
}
