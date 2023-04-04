using System.Globalization;

namespace SkillMap.EventBus.EvenLogF.Model
{
    public class IntegrationEventLogEntry
    {
        public string EventId { get; private set; }
        public string DomainEventId { get; private set; }
        public string? EventTypeName { get; private set; }

        [NotMapped]
        public string? EventTypeShortName => EventTypeName?.Split('.')?.Last();
        [NotMapped]
        public IntegrationEvent IntegrationEvent { get; private set; }

        public EventStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime CreationTime { get; private set; }
        public string Content { get; private set; }
        public string TransactionId { get; private set; }

        private IntegrationEventLogEntry() { }
        public IntegrationEventLogEntry(IntegrationEvent @event, string transactionId)
        {
            if (@event == null) return;

            EventId = @event.IntegrationEventId;

            DomainEventId = @event.DomainEventId;

            CreationTime = StringToDate(@event.OccurredOn);

            EventTypeName = @event.GetType().FullName;

            Content = JsonSerializer.Serialize(@event, @event.GetType(), new JsonSerializerOptions
            {
                WriteIndented = true
            });
            State = EventStateEnum.NotPublished;
            TimesSent = 0;
            TransactionId = transactionId.ToString();
        }

        private DateTime StringToDate(string date)
        {
            return DateTime.ParseExact(date, "s", CultureInfo.CurrentCulture);
        }

        public IntegrationEventLogEntry DeserializeJsonContent(Type type)
        {
            if (!string.IsNullOrEmpty(Content)) {

                IntegrationEvent = JsonSerializer.Deserialize(Content, type, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) as IntegrationEvent;
            }
            
            return this;
        }
    }
}
