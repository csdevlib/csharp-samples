namespace BackOffice.Shared.Application.Events.Interfaces
{

    public interface IDomainEventSource
    {
        public IReadOnlyList<object> Get();
    }
}
