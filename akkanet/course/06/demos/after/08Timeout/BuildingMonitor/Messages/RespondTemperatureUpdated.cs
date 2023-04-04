namespace BuildingMonitor.Messages
{
    public sealed class RespondTemperatureUpdated
    {
        public long RequestId { get; }

        public RespondTemperatureUpdated(long requestId)
        {
            RequestId = requestId;
        }
    }
}
