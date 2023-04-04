using SkillMap.EventBus.Events;

namespace BackOffice.Domain.Companies.Events
{
    public record TalentAddedDomainEvent : DomainEvent
    {
        public string TalentId { get; init; }

        public string Name { get; init; }


        public TalentAddedDomainEvent(string talentId, string name)  
        {
            TalentId = talentId ?? throw new ArgumentNullException(nameof(talentId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string EventName() => GetType().Name.ToLower();
    }
}
