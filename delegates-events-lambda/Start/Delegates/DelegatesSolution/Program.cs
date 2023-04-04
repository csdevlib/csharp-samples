using System;

namespace DelegatesSolution
{
    class Program
    {
        public delegate double FuncHighCalc(double value);

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            FuncHighCalc handler = new Fee().HighFee;

            do
            {
                Console.WriteLine("\nENTER ZONE:");

                var zone = Console.ReadLine();

                Console.WriteLine("\nENTER PRICE:");

                var price = Console.ReadLine();

                var location = FeedRepository.GetLocations(zone);

                var fee = location.Fee;

                if (location.isHighRisk)
                {
                    fee = handler(fee);
                }

                Console.WriteLine($"YOU NEW FEE is {fee}");

                cki = Console.ReadKey(true);
                Console.WriteLine("You pressed the '{0}' key.", cki.Key);
            } while (cki.Key != ConsoleKey.X);

            Console.Read();
        }
    }
}
