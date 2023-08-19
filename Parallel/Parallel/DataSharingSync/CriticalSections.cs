using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel.DataSharingSync
{
    class CriticalSections
    {
        class BankAccount
        {
            public object padlock = new object();
            public int Balance { get; private set; }

            public void Deposit(int amount)
            {

                lock (padlock)
                {
                    // += is really two operations
                    // op1 is temp <- get_Balance() + amount
                    // op2 is set_Balance(temp)
                    // something can happen _between_ op1 and op2

                    Balance += amount;
                }
            }

            public void Withdraw(int amount)
            {
                lock (padlock)
                {
                    Balance -= amount;
                }
            }
        }

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


            Console.WriteLine("All done here.");
        }
    }
}
