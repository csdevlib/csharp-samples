namespace SkillMap.EventBus.Interfaces;

public interface IIntegrationEvent : INotification
{
    string EventName();
}
