using Akka.Actor;
using BuildingMonitor.Messages;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BuildingMonitor.Actors
{
    public class FloorsManager : UntypedActor
    {
        private Dictionary<string, IActorRef> _floorIdToActorRefMap = 
                                                        new Dictionary<string, IActorRef>();
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestFloorIds m:
                    Sender.Tell(new RespondFloorIds(m.RequestId, 
                                    ImmutableHashSet.CreateRange(_floorIdToActorRefMap.Keys)));
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }

        public static Props Props() => Akka.Actor.Props.Create<FloorsManager>();
    }

}
