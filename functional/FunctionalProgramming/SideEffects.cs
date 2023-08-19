using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming {
    public class SideEffects {
        private int state = 0;


        public double Add(double a, double b) {
            return a + b;
        }

        public int Divide(int a, int b) {
            return a / b;
        }

        public int? Divide3(int a, int b) {
            if (b == 0)
                return null;
            return a / b;
        }

        public int Divide2(int a, NonZeroInteger b) {
            return a / b.Number;
        }

        public double Add2(double a, double b) {
            try {
                Console.WriteLine($"a={a}, b={b}");
            }
            catch (Exception ex) { }
            return a + b;
        }

        public int Calc(int input) {
            state = input;
            return input--;
        }

        public void Do(string info) {
            Database.Save(info);
        }

        public int GetTheAnswer() {
            return 42;
        }

        public int GetSecond() {
            return DateTime.Now.Second;
        }
    }

    public class NonZeroInteger {
        public int Number { get; }

        public NonZeroInteger(int number) {
            Number = number;
            if (number == 0)
                throw new ArgumentException();
        }
    }

    internal class Database {
        internal static void Save(string info) {
            throw new NotImplementedException();
        }
    }
}