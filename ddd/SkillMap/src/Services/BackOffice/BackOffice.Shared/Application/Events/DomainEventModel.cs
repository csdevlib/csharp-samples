namespace BackOffice.Shared.Application.Events
{
    public record DomainEventModel(string Id , string AggregateId , string Name, string OccurredOn, Dictionary<string, string> Body);
}
