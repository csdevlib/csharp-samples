using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    class WaitingForTimeToPass
    {
        static void Main(string[] args)
        {
            // we've already seen the classic Thread.Sleep

            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("You have 5 seconds to disarm this bomb by pressing a key");
                bool canceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(canceled ? "Bomb disarmed." : "BOOM!!!!");
            }, token);
            t.Start();

            // unlike sleep and waitone
            // thread does not give up its turn
            // avoiding a context switch
            Thread.SpinWait(10000);
            SpinWait.SpinUntil(() => false);
            Console.WriteLine("Are you still here?");

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
}