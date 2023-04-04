namespace BuildingMonitor.Messages
{
    public sealed class RequestTemperature
    {
        public long RequestId { get; }

        public RequestTemperature(long requestId)
        {
            RequestId = requestId;
        }
    }
}
