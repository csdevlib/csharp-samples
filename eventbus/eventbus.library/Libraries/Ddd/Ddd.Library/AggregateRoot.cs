using System;
using DDD.Library.Core.Interfaces;

namespace DDD.Library
{
	public abstract class AggregateRoot<TEventBase>: Entity, IAggregateRoot where TEventBase: DomainEvent
		
	{
		private List<TEventBase> _domainEvents { get ; set; }

		public IReadOnlyCollection<TEventBase>? DomainEvents => _domainEvents?.AsReadOnly();

		private AggregateRoot(string createdBy):base(createdBy)
		{
		}

		public void ClearDomainEvents()
		{
			this._domainEvents?.Clear();
		}

		public void AddDomainEvent(TEventBase domainEvent)
		{
			_domainEvents = _domainEvents ?? new List<TEventBase>();

			if (this._domainEvents.Exists(@event => @event.EventName.ToLower() == domainEvent.EventName.ToLower())) return;

			this._domainEvents.Add(domainEvent);
		}

		public void RemoveDomainEvent(TEventBase domainEvent)
		{
            if (!this._domainEvents.Exists(@event => @event.EventName.ToLower() == domainEvent.EventName.ToLower())) return;

			this._domainEvents.Remove(domainEvent);
        }

    }
}

