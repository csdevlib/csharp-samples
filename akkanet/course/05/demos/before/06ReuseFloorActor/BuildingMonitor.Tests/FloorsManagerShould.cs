using Akka.Actor;
using Akka.TestKit.Xunit2;
using BuildingMonitor.Actors;
using BuildingMonitor.Messages;
using Xunit;

namespace BuildingMonitor.Tests
{
    public class FloorsManagerShould : TestKit
    {
        [Fact]
        public void ReturnNoFloorIdsWhenNewlyCreated()
        {
            var probe = CreateTestProbe();
            var manager = Sys.ActorOf(FloorsManager.Props());

            manager.Tell(new RequestFloorIds(1), probe.Ref);
            var received = probe.ExpectMsg<RespondFloorIds>();

            Assert.Equal(1, received.RequestId);
            Assert.Empty(received.Ids);
        }

        [Fact]
        public void RegisterNewFloorWhenDoesNotAlreadyExist()
        {
            var probe = CreateTestProbe();
            var manager = Sys.ActorOf(FloorsManager.Props());

            manager.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);
            probe.ExpectMsg<RespondSensorRegistered>(x => x.RequestId == 1);

            manager.Tell(new RequestFloorIds(2), probe.Ref);
            var received = probe.ExpectMsg<RespondFloorIds>();

            Assert.Equal(2, received.RequestId);
            Assert.Equal(1, received.Ids.Count);
            Assert.Contains("a", received.Ids);
        }
    }
}
