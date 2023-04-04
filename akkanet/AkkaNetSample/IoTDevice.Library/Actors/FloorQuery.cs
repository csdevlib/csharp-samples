using Akka.Actor;
using IoTDevice.Library.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace IoTDevice.Library.Actors
{
    public class FloorQuery : UntypedActor
    {
        public static readonly long TemperatureRequestCorrelationId = 42;

        private ICancelable queryTimeoutTimer;

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

            queryTimeoutTimer = Context.System.Scheduler.ScheduleTellOnceCancelable(
                timeout, Self, QueryTimeout.Instance, Self);
        }

        protected override void PreStart()
        {
            foreach (var temperatureSensor in _actorToSensorId.Keys)
            {
                Context.Watch(temperatureSensor);
                temperatureSensor.Tell(new RequestTemperature(TemperatureRequestCorrelationId));
            }
        }

        protected override void PostStop()
        {
            queryTimeoutTimer.Cancel();
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RespondTemperature m when m.RequestId == TemperatureRequestCorrelationId:
                    ITemperatureQueryReading reading = null;
                    if (m.Temperature.HasValue)
                    {
                        reading = new TemperatureAvailable(m.Temperature.Value);
                    }
                    else
                    {
                        reading = NoTemperatureReadingRecordedYet.Instance;
                    }
                    RecordSensorResponse(Sender, reading);
                    break;

                case QueryTimeout m:
                    foreach (var sensor in _stillAwaitingReply)
                    {
                        var sensorId = _actorToSensorId[sensor];
                        _repliesReceived.Add(sensorId, TemperatureSensorTimedOut.Instance);
                    }
                    _requester.Tell(new RespondAllTemperatures(
                                _requestId, _repliesReceived.ToImmutableDictionary()));
                    Context.Stop(Self);
                    break;

                case Terminated m:
                    RecordSensorResponse(m.ActorRef, TemperatureSensorNotAvailable.Instance);
                    break;

                default:
                    Unhandled(message);
                    break;
            }
        }

        private void RecordSensorResponse(IActorRef sensorActor,
                                          ITemperatureQueryReading reading)
        {
            Context.Unwatch(sensorActor);

            var sensorId = _actorToSensorId[sensorActor];

            _stillAwaitingReply.Remove(sensorActor);
            _repliesReceived.Add(sensorId, reading);

            var allRepliesHaveBeenReceived = _stillAwaitingReply.Count == 0;

            if (allRepliesHaveBeenReceived)
            {
                _requester.Tell(new RespondAllTemperatures(
                    _requestId,
                    _repliesReceived.ToImmutableDictionary())); 
                Context.Stop(Self); 
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