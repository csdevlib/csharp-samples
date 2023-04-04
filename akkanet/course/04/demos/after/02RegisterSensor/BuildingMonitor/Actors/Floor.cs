using Akka.Actor;
using BuildingMonitor.Messages;

namespace BuildingMonitor.Actors
{
    public class Floor : UntypedActor
    {
        private string _floorId;

        public Floor(string floorId)
        {
            _floorId = floorId;
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestRegisterTemperatureSensor m:
                    var newSensorActor = Context.ActorOf(
                        TemperatureSensor.Props(_floorId, m.SensorId),
                        $"temperature-sensor-{m.SensorId}");
                    newSensorActor.Forward(m);
                    break;

                default:
                    break;
            }
        }

        public static Props Props(string floorId) => 
            Akka.Actor.Props.Create(() => new Floor(floorId));
    }
}
