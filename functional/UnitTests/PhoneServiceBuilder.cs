using System;
using FunctionalProgramming.Builder;
using NUnit.Framework;

namespace UnitTests {
    public class PhoneServiceBuilder {
        private IConnection connection;
        private IGps gps;
        private ISpeedSensor speedSensor;

        public PhoneServiceBuilder WithConnection(IConnection connection) {
            this.connection = connection;
            return this;
        }
        public PhoneServiceBuilder WithGps(IGps gps)
        {
            this.gps= gps;
            return this;
        }
        public PhoneServiceBuilder WithSpeedSensor(ISpeedSensor sensor) {
            this.speedSensor = sensor;
            return this;
        }

        public PhoneService Build() {
            return new PhoneService(connection, gps, speedSensor);
        }
    }
}