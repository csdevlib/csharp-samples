using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionalProgramming.Extending;
using FunctionalProgramming.Immutable;
using FunctionalProgramming.LINQ;
using FunctionalProgramming.Mutable;
using Character = FunctionalProgramming.Mutable.Character;

namespace FunctionalProgramming {
    class Program {
        static void Main(string[] args) {
            
            Console.ReadLine();

            RangeClient.Test();

            Console.ReadLine();
            /*
            DateTime dt1 = new DateTime(2000, 12, 20, 01, 02, 03);
            var result1 = dt1.ToDeviceFormat();
            Console.WriteLine(result1);

            DateTime dt2 = new DateTime(1999, 12, 20, 01, 02, 03);
            var result2 = dt2.ToDeviceFormat();

            Console.WriteLine(result2);

            Console.ReadLine();
            */
            #region hidden

            Character c = new Character(100);
            for (int i = 0; i < 20; i++) {
                Task.Factory.StartNew(() => c.Hit(10));
                Task.Factory.StartNew(() => {
                    if (c.Health == 90) {
                        Console.WriteLine("Right");
                    }
                    else {
                        Console.WriteLine("Reordered");
                    }
                });
            }
            Console.ReadLine();

            #endregion
        }
    }
}