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
    }
}
