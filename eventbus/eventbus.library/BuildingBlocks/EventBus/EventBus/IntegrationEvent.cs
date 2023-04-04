namespace EventBus;

public record IntegrationEvent
{
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        OcurredOn = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime ocurredOn)
    {
        Id = id;
        OcurredOn = ocurredOn;
    }

    [JsonInclude]
    public Guid Id { get; private init; }

    [JsonInclude]
    public DateTime OcurredOn { get; private init; }
}

