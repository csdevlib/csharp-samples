using BackOffice.Application.Events.Integration;
using SkillMap.EventBus.Interfaces;

namespace BackOffice.Api.Extensions
{
    public static class UseServiceBusExtension
    {
        public static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TagAddedIntegrationEvent, IIntegrationEventHandler<TagAddedIntegrationEvent>>();

            return app;
        }
    }
}
