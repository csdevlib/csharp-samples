using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class AlbumClosedDomainEvent : DomainEvent
    {
        public string AlbumId { get; }

        public AlbumClosedDomainEvent(string albumId)
        {
            AlbumId = albumId;
        }
    }
}
