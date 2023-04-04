
using MusicStore.Shared.Domain.Bus.Event;

namespace MusicStore.Catalog.Domain.Ideas.Events
{
    public class IdeaCreatedDomainEvent : DomainEvent
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDraft { get; private set; }


        public IdeaCreatedDomainEvent(string id, string name)
        {
            Id = id;
            Name = name;
            IsDraft = false;
        }

        public override string EventName()
        {
            return this.GetType().Name.ToString();
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            return new Dictionary<string, string>
            {
                { "name", Name },
                { "eventName", this.GetType().Name.ToString() },
                { "id", Id }
            };
        }

        public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
        {
            return new IdeaCreatedDomainEvent(aggregateId, body["name"]);
        }
    }
}
