namespace SkillMap.EventBus.Interfaces;

public interface IDomainEvent : INotification
{
    string EventName();
}
