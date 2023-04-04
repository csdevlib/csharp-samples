using MusicStore.Shared.Domain.Bus.Event;

namespace MusicStore.Catalog.Domain.Ideas.Events
{
    public class IdeaTagCreatedDomainEvent : DomainEvent
    {
        public string Name { get; }
        
        public IdeaTagCreatedDomainEvent(string name)
        {
            Name = name;
        }

        public override string EventName()
        {
            return this.GetType().Name.ToString();
        }

        public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
        {
          
          return new IdeaTagCreatedDomainEvent(body["name"]);
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            return new Dictionary<string, string>
            {
                { "name", Name },
            };
        }
    }
}
