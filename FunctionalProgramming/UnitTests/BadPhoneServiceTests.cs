using FunctionalProgramming.Builder;
using NUnit.Framework;

namespace UnitTests {
    [TestFixture]
    public class BadPhoneServiceTests {
        [Test]
        public void Test() {
            var gpsMock = new GpsMock();
            gpsMock.SetSteps(5000);

            var service = new PhoneService(new ConnectionMock(), gpsMock, null);

            StepStatus met = service.NumberOfStepsMet();
            Assert.AreEqual(met, StepStatus.Met);
        }

        private PhoneService GetWithConnection(IConnection connection) {
            return new PhoneService(connection, null, null);
        }

        private PhoneService GetWithGpsAndConnection(
            IConnection connection,
            IGps gps) {
            return new PhoneService(connection, gps, null);
        }

        private PhoneService GetWithGpsAndConnectionAndSensor(
            IConnection connection,
            IGps gps,
            ISpeedSensor sensor) {
            return new PhoneService(connection, gps, sensor);
        }
    }
}