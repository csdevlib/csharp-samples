namespace BackOffice.Shared.Events
{
    public abstract class @Event
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    }
}
