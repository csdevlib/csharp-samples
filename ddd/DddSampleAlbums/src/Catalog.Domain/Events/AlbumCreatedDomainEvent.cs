using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class AlbumCreatedDomainEvent : DomainEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AlbumTypeId { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string[] Tags { get; set; }

        public AlbumCreatedDomainEvent(int albumTypeId, string id, string name, string description, string author, string[] tags)
        {
            AlbumTypeId = albumTypeId;
            Id = id;
            Name = name;
            Description = description;
            Author = author;
            Tags = tags;
        }
    }
}
