namespace EventStore.Library.Models
{
    public record EventData(string Id, string AggregateId, string EventName, string Data, string AssemblyQualifiedName);
}
