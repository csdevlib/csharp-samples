using SkillMap.EventBus.Events;

namespace BackOffice.Domain.Tags.Events
{
    public record TagAddedDomainEvent : DomainEvent
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public TagAddedDomainEvent(string id, string name, string description = "")  
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string EventName() => GetType().Name.ToLower();
    }
}
