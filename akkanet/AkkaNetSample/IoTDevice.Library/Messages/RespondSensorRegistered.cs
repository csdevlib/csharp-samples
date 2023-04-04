using Akka.Actor;

namespace IoTDevice.Library.Messages
{
    public sealed class RespondSensorRegistered
    {
        public long RequestId { get; }
        public IActorRef SensorReference { get; }

        public RespondSensorRegistered(long requestId, IActorRef sensorReference)
        {
            RequestId = requestId;
            SensorReference = sensorReference;
        }
    }
}
