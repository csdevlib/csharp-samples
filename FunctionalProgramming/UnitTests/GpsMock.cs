using FunctionalProgramming.Builder;

namespace UnitTests
{
    public class GpsMock : IGps
    {
        private int steps;

        public int GetSteps()
        {
            return steps;
        }

        public void SetSteps(int steps)
        {
            this.steps = steps;
        }
    }
}