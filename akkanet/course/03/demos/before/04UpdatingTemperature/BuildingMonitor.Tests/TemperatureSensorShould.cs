using Xunit;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using BuildingMonitor.Actors;
using BuildingMonitor.Messages;

namespace BuildingMonitor.Tests
{
    public class TemperatureSensorShould : TestKit
    {

        [Fact]
        public void InitializeSensorMetaData()
        {
            var probe = CreateTestProbe();

            var sensor = Sys.ActorOf(TemperatureSensor.Props("a", "1"));

            sensor.Tell(new RequestMetadata(1), probe.Ref);

            var received = probe.ExpectMsg<RespondMetadata>();

            Assert.Equal(1, received.RequestId);
            Assert.Equal("a", received.FloorId);
            Assert.Equal("1", received.SensorId);
        }

        [Fact]
        public void StartWithNoTemperature()
        {
            var probe = CreateTestProbe();

            var sensor = Sys.ActorOf(TemperatureSensor.Props("a", "1"));

            sensor.Tell(new RequestTemperature(1), probe.Ref);

            var received = probe.ExpectMsg<RespondTemperature>();

            Assert.Null(received.Temperature);
        }
    }
}
