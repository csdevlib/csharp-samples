using Akka.Actor;
using Akka.TestKit.Xunit2;
using BuildingMonitor.Actors;
using BuildingMonitor.Messages;
using Xunit;

namespace BuildingMonitor.Tests
{
    public class FloorShould : TestKit
    {
        [Fact]
        public void RegisterNewTemperatureSensorsWhenDoesNotAlreadyExist()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);

            var received = probe.ExpectMsg<RespondSensorRegistered>();
            Assert.Equal(1, received.RequestId);

            var sensorActor = probe.LastSender;
            // Check sensor was created ok and is accepting messages
            sensorActor.Tell(new RequestUpdateTemperature(42, 100), probe.Ref);
            probe.ExpectMsg<RespondTemperatureUpdated>();
        }

        [Fact]
        public void ReturnExistingTemperatureSensorWhenReRegisteringSameSensor()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);
            var received = probe.ExpectMsg<RespondSensorRegistered>();
            Assert.Equal(1, received.RequestId);
            var firstSensor = probe.LastSender;

            floor.Tell(new RequestRegisterTemperatureSensor(2, "a", "42"), probe.Ref);
            received = probe.ExpectMsg<RespondSensorRegistered>();
            Assert.Equal(2, received.RequestId);
            var secondSensor = probe.LastSender;

            Assert.Equal(firstSensor, secondSensor);
        }

        [Fact]
        public void NotRegisterWhenMismatchedFloor()
        {
            var probe = CreateTestProbe();
            var eventStreamProbe = CreateTestProbe();

            Sys.EventStream.Subscribe(eventStreamProbe, typeof(Akka.Event.UnhandledMessage));

            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "b", "42"), probe);
            probe.ExpectNoMsg();

            var unhandled = eventStreamProbe.ExpectMsg<Akka.Event.UnhandledMessage>();
            Assert.IsType<RequestRegisterTemperatureSensor>(unhandled.Message);
            Assert.Equal(floor, unhandled.Recipient);
        }

        [Fact]
        public void ReturnAllTemperatureSensorsIds()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);
            probe.ExpectMsg<RespondSensorRegistered>();

            floor.Tell(new RequestRegisterTemperatureSensor(2, "a", "90"), probe.Ref);
            probe.ExpectMsg<RespondSensorRegistered>();

            floor.Tell(new RequestTemperatureSensorIds(1), probe.Ref);
            var response = probe.ExpectMsg<RespondTemperatureSensorIds>();

            Assert.Equal(2, response.Ids.Count);
            Assert.Contains("42", response.Ids);
            Assert.Contains("90", response.Ids);
        }

        [Fact]
        public void ReturnEmptyListOfTemperatureSensorsIdsIfNoneExists()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestTemperatureSensorIds(1), probe.Ref);
            var response = probe.ExpectMsg<RespondTemperatureSensorIds>();

            Assert.Equal(0, response.Ids.Count);
        }

        [Fact]
        public void ReturnTemperatureSensorsIdsOnlyFromActiveActors()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);
            probe.ExpectMsg<RespondSensorRegistered>();
            var firstSensorAdded = probe.LastSender;

            floor.Tell(new RequestRegisterTemperatureSensor(2, "a", "90"), probe.Ref);
            probe.ExpectMsg<RespondSensorRegistered>();

            // Stop one of the actors
            probe.Watch(firstSensorAdded);
            firstSensorAdded.Tell(PoisonPill.Instance);
            probe.ExpectTerminated(firstSensorAdded);

            floor.Tell(new RequestTemperatureSensorIds(1), probe.Ref);
            var response = probe.ExpectMsg<RespondTemperatureSensorIds>();

            Assert.Equal(1, response.Ids.Count);
            Assert.Contains("90", response.Ids);
        }
    }
}
