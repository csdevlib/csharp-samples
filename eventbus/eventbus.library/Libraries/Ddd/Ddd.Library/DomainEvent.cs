using System;
namespace DDD.Library
{
	public abstract class DomainEvent
	{
		public string DomainEventId { get; set; }
		public string AggregateId { get; private set; }
		public eEVENT_TYPE EventType { get; private set; } = eEVENT_TYPE.DOMAIN_EVENT;
		public string EventName { get; set; }
		public DateTime OcurredOn { get; set; }

		public DomainEvent(string aggregateId, string eventName)
		{
			this.AggregateId = aggregateId;
			this.EventName = eventName;

			this.DomainEventId = Guid.NewGuid().ToString();
			this.OcurredOn = new DateTime().ToUniversalTime();
		}
	}
}

