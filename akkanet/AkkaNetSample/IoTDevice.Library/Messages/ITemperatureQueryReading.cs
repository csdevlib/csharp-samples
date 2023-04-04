namespace IoTDevice.Library.Messages
{
    public interface ITemperatureQueryReading {}

    public sealed class TemperatureAvailable : ITemperatureQueryReading
    {
        public double Temperature { get; }

        public TemperatureAvailable(double temperature)
        {
            Temperature = temperature;
        }
    }

    public sealed class NoTemperatureReadingRecordedYet : ITemperatureQueryReading
    {
        public static NoTemperatureReadingRecordedYet Instance { get; } = new NoTemperatureReadingRecordedYet();
        private NoTemperatureReadingRecordedYet() { }
    }

    public sealed class TemperatureSensorNotAvailable : ITemperatureQueryReading
    {
        public static TemperatureSensorNotAvailable Instance { get; } = new TemperatureSensorNotAvailable();
        private TemperatureSensorNotAvailable() { }
    }

    public sealed class TemperatureSensorTimedOut : ITemperatureQueryReading
    {
        public static TemperatureSensorTimedOut Instance { get; } = new TemperatureSensorTimedOut();
        private TemperatureSensorTimedOut() { }
    }
}
