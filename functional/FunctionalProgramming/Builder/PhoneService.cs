using System.Runtime.Remoting.Messaging;

namespace FunctionalProgramming.Builder {
    public class PhoneService {
        private IConnection connection;
        private IGps gps;
        private ISpeedSensor speedSensor;

        public PhoneService(IConnection connection, IGps gps, ISpeedSensor speedSensor) {
            this.connection = connection;
            this.gps = gps;
            this.speedSensor = speedSensor;
        }

        public StepStatus NumberOfStepsMet() {
            connection.Connect();
            int steps = gps.GetSteps();

            const int dailyRequirement = 5000;
            if (steps >= dailyRequirement)
                return StepStatus.Met;
            if (dailyRequirement - steps <= 1000)
                return StepStatus.AlmostMet;
            return StepStatus.NotEvenClose;
        }
    }


    public class Connection : IConnection {
        public void Connect() { }
    }

    public interface ISpeedSensor { }

    public interface IGps {
        int GetSteps();
    }

    public interface IConnection {
        void Connect();
    }
}