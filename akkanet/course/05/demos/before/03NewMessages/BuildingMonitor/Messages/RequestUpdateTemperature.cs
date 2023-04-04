namespace BuildingMonitor.Messages
{
    public sealed class RequestUpdateTemperature
    {
        public long RequestId { get; }
        public double Temperature { get; }

        public RequestUpdateTemperature(long requestId, double temperature)
        {
            RequestId = requestId;
            Temperature = temperature;
        }
    }
}
