namespace BuildingMonitor.Messages
{
    public sealed class RequestTemperatureSensorIds
    {
        public long RequestId { get; }

        public RequestTemperatureSensorIds(long requestId)
        {
            RequestId = requestId;
        }
    }
}
