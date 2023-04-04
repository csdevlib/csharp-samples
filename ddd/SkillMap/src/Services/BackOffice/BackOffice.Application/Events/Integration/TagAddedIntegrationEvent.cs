using SkillMap.EventBus.Events;

namespace BackOffice.Application.Events.Integration
{
    public record TagAddedIntegrationEvent : IntegrationEvent
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public TagAddedIntegrationEvent(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string EventName() => GetType().Name.ToLower();
    }
}
