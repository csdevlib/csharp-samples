using System;

namespace FunctionalProgramming.Immutable {
    public sealed class Popsicle {
        public bool Frozen { get; private set; }

        private int value;

        public int Value {
            get { return value; }
            set {
                if (Frozen) {
                    throw new InvalidOperationException("Couldn't keep it in, heaven knows I tried!");
                }
                this.value = value;
            }
        }

        public void Freeze() {
            Frozen = true;
        }
    }

    public class PopsicleClient {
        public static void Run() {
            var popsicle = new Popsicle();
            popsicle.Value = 1;
            popsicle.Value = 2;
            popsicle.Freeze();
            Console.WriteLine(popsicle.Value);
            popsicle.Value = 3; // exception!
        }
    }
}