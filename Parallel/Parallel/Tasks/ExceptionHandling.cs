using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    class ExceptionHandling
    {
        public static void BasicHandling()
        {
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Can't do this!") { Source = "t" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                var e = new AccessViolationException("Can't access this!");
                e.Source = "t2";
                throw e;
            });

            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    Console.WriteLine($"Exception {e.GetType()} from {e.Source}.");
                }
            }
        }

        static void Main()
        {
            BasicHandling();

            //      try
            //      {
            //        IterativeHandling();
            //      }
            //      catch (AggregateException ae)
            //      {
            //        Console.WriteLine("Some exceptions we didn't expect:");
            //        foreach (var e in ae.InnerExceptions)
            //          Console.WriteLine($" - {e.GetType()}");
            //      }

            // escalation policy (use Insert Signature CA)
            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs args) =>
            {
                // this exception got handled
                args.SetObserved();

                var ae = args.Exception as AggregateException;
                ae?.Handle(ex =>
                {
                    Console.WriteLine($"Policy handled {ex.GetType()}.");
                    return true;
                });
            };

            IterativeHandling(); // throws


            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }

        private static void IterativeHandling()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(100);
                }
            }, token);

            var t2 = Task.Factory.StartNew(() =>
            {
                throw null;
            });

            cts.Cancel();

            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                // handle exceptions depending on whether they were expected or
                // handles all expected exceptions ('return true'), throws the
                // unhandled ones back as an AggregateException
                ae.Handle(e =>
                {
                    if (e is OperationCanceledException)
                    {
                        Console.WriteLine("Whoops, tasks were canceled.");
                        return true; // exception was handled
                    }
                    else
                    {
                        Console.WriteLine($"Something went wrong: {e}");
                        return false; // exception was NOT handled
                    }
                });
            }
            finally
            {
                // what happened to the tasks?
                Console.WriteLine("\tfaulted\tcompleted\tcancelled");
                Console.WriteLine($"t\t{t.IsFaulted}\t{t.IsCompleted}\t{t.IsCanceled}");
                Console.WriteLine($"t1\t{t2.IsFaulted}\t{t2.IsCompleted}\t{t2.IsCanceled}");
            }
        }
    }
}
