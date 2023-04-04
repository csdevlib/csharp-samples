namespace BuildingMonitor.Messages
{
    public sealed class RequestRegisterTemperatureSensor
    {
        public long RequestId { get; }
        public string FloorId { get; }
        public string SensorId { get; }

        public RequestRegisterTemperatureSensor(long requestId, string floorId, string sensorId)
        {
            RequestId = requestId;
            FloorId = floorId;
            SensorId = sensorId;
        }
    }
}