namespace BackOffice.Shared.Domain.Interfaces
{
    public interface IDomainEventsConsumer
    {
        Task Consume();
    }
}
