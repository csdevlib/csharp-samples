using Akka.Actor;

namespace IoTDevice.Library.Messages
{
    public class RespondedSensorRegistered
    {
        public long RequestId { get; }
        public IActorRef SensorReference { get; }

        public RespondedSensorRegistered(long requestId, IActorRef sensorReference)
        {
            RequestId = requestId;
            SensorReference = sensorReference;  
        }
    }
}
