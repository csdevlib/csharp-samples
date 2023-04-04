using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class SongCreatedDomainEvent : DomainEvent
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Duration { get; private set; }
        public bool IsDraft { get; private set; }
        public string Author { get; private set; }

        public SongCreatedDomainEvent(string id, string name, string duration, bool isDraft, string author)
        {
            Id = id;
            Name = name;
            Duration = duration;
            IsDraft = isDraft;
            Author = author;
        }
    }
}
