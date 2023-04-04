using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class SongPromotedDomainEvent : DomainEvent
    {
        public string SongId { get; }

        public SongPromotedDomainEvent(string songId)
        {
            SongId = songId;
        }
    }
}
