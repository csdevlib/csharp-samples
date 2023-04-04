using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class SongReleasedDomainEvent : DomainEvent
    {
        public string SongId { get; }

        public SongReleasedDomainEvent(string songId)
        {
            SongId = songId;
        }
    }
}
