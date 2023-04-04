namespace SkillMap.EventBus.Interfaces;

public interface IDynamicIntegrationEventHandler 
{
    Task Handle(dynamic eventData);
}
