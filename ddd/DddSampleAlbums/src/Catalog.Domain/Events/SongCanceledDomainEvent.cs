using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Events
{
    public class SongCanceledDomainEvent : DomainEvent
    {
        public string SongId { get; }

        public SongCanceledDomainEvent(string songId)
        {
            SongId = songId;
        }
    }
}
