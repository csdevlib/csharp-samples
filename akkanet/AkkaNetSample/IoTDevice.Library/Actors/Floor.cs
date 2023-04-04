using Akka.Actor;
using IoTDevice.Library.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace IoTDevice.Library.Actors
{
    public class Floor : UntypedActor
    {
        private string _floorId;
        private Dictionary<string, IActorRef> _sensorIdToActorRefMap = 
                                                    new Dictionary<string, IActorRef>();

        public Floor(string floorId)
        {
            _floorId = floorId;
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestRegisterTemperatureSensor m when m.FloorId == _floorId:
                    if (_sensorIdToActorRefMap.TryGetValue(m.SensorId,
                                                           out var existingSensorActorRef))
                    {
                        existingSensorActorRef.Forward(m);
                    }
                    else
                    {
                        var newSensorActor = Context.ActorOf(
                            TemperatureSensor.Props(_floorId, m.SensorId),
                            $"temperature-sensor-{m.SensorId}");
                        Context.Watch(newSensorActor);
                        _sensorIdToActorRefMap.Add(m.SensorId, newSensorActor);
                        newSensorActor.Forward(m);
                    }
                    break;
                case RequestTemperatureSensorIds m:
                    Sender.Tell(new RespondTemperatureSensorIds(m.RequestId,
                                        ImmutableHashSet.CreateRange(_sensorIdToActorRefMap.Keys)));
                    break;
                case RequestAllTemperatures m:
                    var actorRefToSensorIdMap = new Dictionary<IActorRef, string>();
                    foreach (var item in _sensorIdToActorRefMap)
                    {
                        actorRefToSensorIdMap.Add(item.Value, item.Key);
                    }
                    Context.ActorOf(FloorQuery.Props(actorRefToSensorIdMap,
                                                     m.RequestId,
                                                     Sender,
                                                     TimeSpan.FromSeconds(3)));
                    break;
                case Terminated m:
                    var terminatedTemperatureSensorId = 
                            _sensorIdToActorRefMap.First(x => x.Value == m.ActorRef).Key;
                    _sensorIdToActorRefMap.Remove(terminatedTemperatureSensorId);
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }

        public static Props Props(string floorId) => 
            Akka.Actor.Props.Create(() => new Floor(floorId));
    }
}
