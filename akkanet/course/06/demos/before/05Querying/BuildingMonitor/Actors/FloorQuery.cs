using Akka.Actor;
using BuildingMonitor.Messages;
using System;
using System.Collections.Generic;

namespace BuildingMonitor.Actors
{
    public class FloorQuery : UntypedActor
    {
        public static readonly long TemperatureRequestCorrelationId = 42;

        private Dictionary<IActorRef, string> _actorToSensorId;
        private long _requestId;
        private IActorRef _requester;
        private TimeSpan _timeout;

        public FloorQuery(Dictionary<IActorRef, string> actorToSensorId,
                          long requestId,
                          IActorRef requester,
                          TimeSpan timeout)
        {
            _actorToSensorId = actorToSensorId;
            _requestId = requestId;
            _requester = requester;
            _timeout = timeout;
        }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }


        public static Props Props(Dictionary<IActorRef, string> actorToSensorId,
                                  long requestId,
                                  IActorRef requester,
                                  TimeSpan timeout) =>
                    Akka.Actor.Props.Create(() =>
                            new FloorQuery(actorToSensorId, requestId, requester, timeout));
    }
}