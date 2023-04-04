using Akka.Actor;
using Akka.TestKit.Xunit;
using IoTDevice.Library.Actors;
using IoTDevice.Library.Messages;
using System;
using System.Collections.Generic;
using Xunit;

namespace IoTDevice.Library.Tests
{
    public class FloorQueryShould : TestKit
    {
        [Fact]
        public void ReturnTemperatures()
        {
            var queryRequester = CreateTestProbe();

            var temperatureSensor1 = CreateTestProbe();
            var temperatureSensor2 = CreateTestProbe();

            var floorQuery = Sys.ActorOf(FloorQuery.Props(
                actorToSensorId: new Dictionary<IActorRef, string>
                {
                    [temperatureSensor1.Ref] = "sensor1",
                    [temperatureSensor2.Ref] = "sensor2"
                },
                requestId: 1,
                requester: queryRequester.Ref,
                timeout: TimeSpan.FromSeconds(3)
            ));

            temperatureSensor1.ExpectMsg<RequestTemperature>((m, sender) =>
            {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            temperatureSensor2.ExpectMsg<RequestTemperature>((m, sender) =>
            {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, 23.9), temperatureSensor1.Ref);

            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, 32.4), temperatureSensor2.Ref);

            var response = queryRequester.ExpectMsg<RespondAllTemperatures>();

            Assert.Equal(1, response.RequestId);
            Assert.Equal(2, response.TemperatureReadings.Count);

            var temperatureReading1 = Assert.IsAssignableFrom<TemperatureAvailable>(
                response.TemperatureReadings["sensor1"]);
            Assert.Equal(23.9, temperatureReading1.Temperature);

            var temperatureReading2 = Assert.IsAssignableFrom<TemperatureAvailable>(
                response.TemperatureReadings["sensor2"]);
            Assert.Equal(32.4, temperatureReading2.Temperature);
        }

        [Fact]
        public void ReturnNoTemperatureAvailableResults()
        {
            var queryRequester = CreateTestProbe();

            var temperatureSensor1 = CreateTestProbe();
            var temperatureSensor2 = CreateTestProbe();

            var floorQuery = Sys.ActorOf(FloorQuery.Props(
                actorToSensorId: new Dictionary<IActorRef, string>
                {
                    [temperatureSensor1.Ref] = "sensor1",
                    [temperatureSensor2.Ref] = "sensor2"
                },
                requestId: 1,
                requester: queryRequester.Ref,
                timeout: TimeSpan.FromSeconds(3)
            ));


            temperatureSensor1.ExpectMsg<RequestTemperature>((m, sender) => {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            temperatureSensor2.ExpectMsg<RequestTemperature>((m, sender) => {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });



            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, null), temperatureSensor1.Ref);

            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, 32.4), temperatureSensor2.Ref);

            var response = queryRequester.ExpectMsg<RespondAllTemperatures>();

            Assert.Equal(1, response.RequestId);
            Assert.Equal(2, response.TemperatureReadings.Count);

            Assert.IsAssignableFrom<NoTemperatureReadingRecordedYet>(
                    response.TemperatureReadings["sensor1"]);

            var temperatureReading2 = Assert.IsAssignableFrom<TemperatureAvailable>(
                    response.TemperatureReadings["sensor2"]);
            Assert.Equal(32.4, temperatureReading2.Temperature);
        }

        [Fact]
        public void RecognizeSensorsThatStopDuringQuery()
        {
            var queryRequester = CreateTestProbe();

            var temperatureSensor1 = CreateTestProbe();
            var temperatureSensor2 = CreateTestProbe();

            var floorQuery = Sys.ActorOf(FloorQuery.Props(
                actorToSensorId: new Dictionary<IActorRef, string>
                {
                    [temperatureSensor1.Ref] = "sensor1",
                    [temperatureSensor2.Ref] = "sensor2"
                },
                requestId: 1,
                requester: queryRequester.Ref,
                timeout: TimeSpan.FromSeconds(3)
            ));


            temperatureSensor1.ExpectMsg<RequestTemperature>((m, sender) => {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            temperatureSensor2.ExpectMsg<RequestTemperature>((m, sender) => {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });



            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, 23.9), temperatureSensor1.Ref);

            temperatureSensor2.Tell(PoisonPill.Instance);

            var response = queryRequester.ExpectMsg<RespondAllTemperatures>();

            Assert.Equal(1, response.RequestId);
            Assert.Equal(2, response.TemperatureReadings.Count);

            var temperatureReading1 = Assert.IsAssignableFrom<TemperatureAvailable>(
                response.TemperatureReadings["sensor1"]);
            Assert.Equal(23.9, temperatureReading1.Temperature);

            Assert.IsAssignableFrom<TemperatureSensorNotAvailable>(
                response.TemperatureReadings["sensor2"]);
        }

        [Fact]
        public void TimoutWhenSomeSensorsDoNotReturnTimelyResponse()
        {
            var queryRequester = CreateTestProbe();

            var temperatureSensor1 = CreateTestProbe();
            var temperatureSensor2 = CreateTestProbe();

            var floorQuery = Sys.ActorOf(FloorQuery.Props(
                actorToSensorId: new Dictionary<IActorRef, string>
                {
                    [temperatureSensor1.Ref] = "sensor1",
                    [temperatureSensor2.Ref] = "sensor2"
                },
                requestId: 1,
                requester: queryRequester.Ref,
                timeout: TimeSpan.FromSeconds(3)
            ));


            temperatureSensor1.ExpectMsg<RequestTemperature>((m, sender) =>
            {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            temperatureSensor2.ExpectMsg<RequestTemperature>((m, sender) =>
            {
                Assert.Equal(FloorQuery.TemperatureRequestCorrelationId, m.RequestId);
                Assert.Equal(floorQuery, sender);
            });

            floorQuery.Tell(new RespondTemperature(
                FloorQuery.TemperatureRequestCorrelationId, 23.9), temperatureSensor1.Ref);

            // Don't respond from sensor2            

            var response = queryRequester.ExpectMsg<RespondAllTemperatures>(TimeSpan.FromSeconds(5));

            Assert.Equal(1, response.RequestId);
            Assert.Equal(2, response.TemperatureReadings.Count);

            var temperatureReading1 = Assert.IsAssignableFrom<TemperatureAvailable>(
                response.TemperatureReadings["sensor1"]);
            Assert.Equal(23.9, temperatureReading1.Temperature);

            Assert.IsAssignableFrom<TemperatureSensorTimedOut>(
                response.TemperatureReadings["sensor2"]);            
        }
    }
}
