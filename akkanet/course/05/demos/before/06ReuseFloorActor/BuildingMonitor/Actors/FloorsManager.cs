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
                case RequestRegisterTemperatureSensor m:
                    if (_floorIdToActorRefMap.TryGetValue(m.FloorId, out var existingFloorActorRef))
                    {
                        existingFloorActorRef.Forward(m);
                    }
                    else
                    {
                        var newFloorActor = Context.ActorOf(Floor.Props(m.FloorId),
                                                            $"floor-{m.FloorId}");
                        _floorIdToActorRefMap.Add(m.FloorId, newFloorActor);
                        newFloorActor.Forward(m);
                    }
                    break;
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
