using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class AlbumCanceledDomainEvent : DomainEvent
    {
        public string AlbumId { get; }

        public AlbumCanceledDomainEvent(string albumId)
        {
            AlbumId = albumId;
        }
    }
}
