using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel.DataSharingSync
{
    class BankAccount
    {
        private int balance;

        public int Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public void Deposit(int amount)
        {
            Interlocked.Add(ref balance, amount);
        }

        public void Withdraw(int amount)
        {
            Interlocked.Add(ref balance, -amount);
            //balance -= amount;
        }
    }

    // interlocked class contains atomic operations on variables
    // atomic = cannot be interrupted

    class InterlockedOperations
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var ba = new BankAccount();

            for (int i = 0; i < 10; ++i)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; ++j)
                        ba.Deposit(100);
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; ++j)
                        ba.Withdraw(100);
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance is {ba.Balance}.");

            // show interlocked methods here

            // Interlocked.MemoryBarrier is a wrapper for Thread.MemoryBarrier
            // only required on memory systems that have weak memory ordering (e.g., Itanium)
            // prevents the CPU from reordering the instructions such that those before the barrier
            // execute after those after


            Console.WriteLine("All done here.");
        }
    }
}
