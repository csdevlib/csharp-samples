using MusicStore.Shared.Domain.Bus.Event;

namespace MusicStore.Catalog.Domain.Ideas.Events
{
    public class IdeaResourceCreatedDomainEvent : DomainEvent
    {
        public string Id { get; }
        public string Name { get; }
        public string Path { get; }
        public bool IsExternal { get; }

        public IdeaResourceCreatedDomainEvent(string id, string name, string path, bool isExternal)
        {
            Id = id;
            Name = name;
            Path = path;
            IsExternal = isExternal;
        }

        public override string EventName()
        {
            return this.GetType().Name.ToString();
        }

        public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
        {
            try
            {
                bool.TryParse(body["isExternal"], out bool isExternal);

                return new IdeaResourceCreatedDomainEvent(aggregateId, body["name"], body["path"], isExternal);
            }
            catch (Exception ex)
            {
                throw new DomainException($"Event:{EventName()} has an invalid IsExternal value. {ex.Message}");
            }
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            return new Dictionary<string, string>
            {
                { "path", Path },
                { "name", Name },
                { "isExternal", IsExternal.ToString()},
                { "eventName", this.GetType().Name.ToString() },
                { "id", Id }
            };
        }
    }
}
