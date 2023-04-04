namespace IoTDevice.Library.Messages
{
    public class ResponseTemperature
    {
        public long RequestId { get; }
        public double? Temperature { get; }

        public ResponseTemperature(long requestId, double? temperature)
        {
            RequestId = requestId;  
            Temperature = temperature;  
        }
    }
}
