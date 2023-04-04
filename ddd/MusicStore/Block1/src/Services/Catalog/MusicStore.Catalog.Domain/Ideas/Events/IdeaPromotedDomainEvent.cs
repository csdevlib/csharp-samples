using MusicStore.Shared.Domain.Bus.Event;

namespace MusicStore.Catalog.Domain.Ideas.Events
{
    public class IdeaPromotedDomainEvent : DomainEvent
    {
        public string Id { get; private set; }


        public IdeaPromotedDomainEvent(string id)
        {
            Id = id;
        }

        public override string EventName()
        {
            return this.GetType().Name.ToString();
        }
        public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
        {
            return new IdeaPromotedDomainEvent(aggregateId);
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            return new Dictionary<string, string>
            {
                { "id", Id }
            };
        }
    }
}
