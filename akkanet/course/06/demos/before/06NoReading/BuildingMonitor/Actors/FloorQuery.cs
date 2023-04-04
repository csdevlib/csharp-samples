using Akka.Actor;
using BuildingMonitor.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BuildingMonitor.Actors
{
    public class FloorQuery : UntypedActor
    {
        public static readonly long TemperatureRequestCorrelationId = 42;

        private Dictionary<IActorRef, string> _actorToSensorId;
        private long _requestId;
        private IActorRef _requester;
        private TimeSpan _timeout;

        private Dictionary<string, ITemperatureQueryReading> _repliesReceived = new Dictionary<string, ITemperatureQueryReading>();

        private HashSet<IActorRef> _stillAwaitingReply;

        public FloorQuery(Dictionary<IActorRef, string> actorToSensorId,
                          long requestId,
                          IActorRef requester,
                          TimeSpan timeout)
        {
            _actorToSensorId = actorToSensorId;
            _requestId = requestId;
            _requester = requester;
            _timeout = timeout;

            _stillAwaitingReply = new HashSet<IActorRef>(_actorToSensorId.Keys);
        }

        protected override void PreStart()
        {
            foreach (var temperatureSensor in _actorToSensorId.Keys)
            {
                temperatureSensor.Tell(new RequestTemperature(TemperatureRequestCorrelationId));
            }
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RespondTemperature m when m.RequestId == TemperatureRequestCorrelationId:
                    ITemperatureQueryReading reading = null;
                    reading = new TemperatureAvailable(m.Temperature.Value);
                    RecordSensorResponse(Sender, reading);
                    break;

                default:
                    Unhandled(message);
                    break;
            }
        }

        private void RecordSensorResponse(IActorRef sensorActor,
                                          ITemperatureQueryReading reading)
        {
            var sensorId = _actorToSensorId[sensorActor];

            _stillAwaitingReply.Remove(sensorActor);
            _repliesReceived.Add(sensorId, reading);

            var allRepliesHaveBeenRecieved = _stillAwaitingReply.Count == 0;

            if (allRepliesHaveBeenRecieved)
            {
                _requester.Tell(new RespondAllTemperatures(
                    _requestId,
                    _repliesReceived.ToImmutableDictionary()));
            }
        }

        public static Props Props(Dictionary<IActorRef, string> actorToSensorId,
                                  long requestId,
                                  IActorRef requester,
                                  TimeSpan timeout) =>
                    Akka.Actor.Props.Create(() =>
                            new FloorQuery(actorToSensorId, requestId, requester, timeout));
    }
}