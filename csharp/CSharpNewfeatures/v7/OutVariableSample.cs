using Shared;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpNewfeatures
{
    public class OutVariableSample : ISample
    {
        public void Run()
        {
            DateTime date1;

            DateTime.TryParse("01/01/2021", out date1);

            WriteLine($"Date 1: {date1}");

            DateTime.TryParse("03/03/2021", out var date2);

            WriteLine($"Date 2: {date2}");

            WriteLine("Trying convert a string to int and throw default value");

            int.TryParse("Beto", out int number);

            WriteLine($"Trying number, should be 0: {number}");
        }
    }
}
