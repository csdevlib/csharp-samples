using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class AlbumSentToSalesDomainEvent : DomainEvent
    {
        public string AlbumId { get; }

        public AlbumSentToSalesDomainEvent(string albumId)
        {
            AlbumId = albumId;
        }
    }
}
