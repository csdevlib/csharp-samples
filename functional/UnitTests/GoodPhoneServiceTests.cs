using FunctionalProgramming.Builder;
using NUnit.Framework;

namespace UnitTests {
    [TestFixture]
    public class GoodTests {
        [Test]
        public void Test() {
            var gpsMock = new GpsMock();
            gpsMock.SetSteps(5000);

            var service = new PhoneServiceBuilder()
                .WithConnection(new ConnectionMock())
                .WithGps(gpsMock)
                .Build();

            StepStatus met = service.NumberOfStepsMet();
            Assert.AreEqual(StepStatus.Met, met);
        }
    }
}