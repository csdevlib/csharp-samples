using SkillMap.EventBus.Events;

namespace BackOffice.Domain.Companies.Events
{
    public record RecruiterAddedDomainEvent : DomainEvent
    {

        public string EmployeeId { get; init; }

        public RecruiterAddedDomainEvent(string employeeId) 
        {
            EmployeeId = employeeId ?? throw new ArgumentNullException(nameof(employeeId));
        }

        public override string EventName() => GetType().Name.ToLower();
    }
}
