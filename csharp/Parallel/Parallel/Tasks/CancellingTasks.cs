using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    class CancellingTasks
    {
        static void Main(string[] args)
        {
            CancelableTasks();
            MonitoringCancelation();
            CompositeCancelationToken();

            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }

        private static void WaitingForTimeToPass()
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
            Thread.SpinWait(10000);
            Console.WriteLine("Are you still here?");

            Console.ReadKey();
            cts.Cancel();
        }

        private static void CompositeCancelationToken()
        {
            // it's possible to create a 'composite' cancelation source that involves several tokens
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            // make a token source that is linked on their tokens
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
              planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.Write($"{i++}\t");
                    Thread.Sleep(100);
                }
            }, paranoid.Token);

            paranoid.Token.Register(() => Console.WriteLine("Cancelation requested"));

            Console.ReadKey();

            // use any of the aforementioned token soures
            emergency.Cancel();
        }

        private static void MonitoringCancelation()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            // register a delegate to fire
            token.Register(() =>
            {
                Console.WriteLine("Cancelation has been requested.");
            });

            Task t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    if (token.IsCancellationRequested) // 1. Soft exit
                                                       // RanToCompletion
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{i++}\t");
                        Thread.Sleep(100);
                    }
                }
            });
            t.Start();

            // canceling multiple tasks
            Task t2 = Task.Factory.StartNew(() =>
            {
                char c = 'a';
                while (true)
                {
                    // alternative to what's below
                    token.ThrowIfCancellationRequested(); // 2. Hard exit, Canceled

                    if (token.IsCancellationRequested) // same as above, start HERE
                    {
                        // release resources, if any
                        throw new OperationCanceledException("No longer interested in printing letters.");
                    }
                    else
                    {
                        Console.Write($"{c++}\t");
                        Thread.Sleep(200);
                    }
                }
            }, token); // don't do token, show R# magic

            // cancellation on a wait handle
            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle released, thus cancelation was requested");
            });

            Console.ReadKey();

            cts.Cancel();

            Thread.Sleep(1000); // cancelation is non-instant

            Console.WriteLine($"Task has been canceled. The status of the canceled task 't' is {t.Status}.");
            Console.WriteLine($"Task has been canceled. The status of the canceled task 't2' is {t2.Status}.");
            Console.WriteLine($"t.IsCanceled = {t.IsCanceled}, t2.IsCanceled = {t2.IsCanceled}");
        }

        private static void CancelableTasks()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    if (token.IsCancellationRequested) // task cancelation is cooperative, no-one kills your thread
                        break;
                    else
                        Console.WriteLine($"{i++}\t");
                }
            });
            t.Start();

            // don't forget CancellationToken.None

            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Task has been canceled.");
        }
    }
}
