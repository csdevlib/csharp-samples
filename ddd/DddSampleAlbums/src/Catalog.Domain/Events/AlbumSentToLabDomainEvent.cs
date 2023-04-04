using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class AlbumSentToLabDomainEvent: DomainEvent
    {
        public string AlbumId { get; }

        public AlbumSentToLabDomainEvent(string albumId)
        {
            AlbumId = albumId;
        }
    }
}
