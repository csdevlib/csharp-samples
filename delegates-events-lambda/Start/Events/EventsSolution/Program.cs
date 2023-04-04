using System;

namespace EventsSolution
{
    public delegate void BudgetChangeHandler(decimal value);

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            BudgetWatcher bw = new BudgetWatcher();
            MyBudget myBudget = new MyBudget();

            myBudget.BudgetChange += ChangeBudget;
            myBudget.BudgetChange += bw.Watch;
            myBudget.BudgetChangeHandler += ChangeBudgetArgs;

            do
            {
                Console.WriteLine("\nENTER BUDGET:");

                var budget = Console.ReadLine();

                decimal budgetParsed = decimal.Parse(budget);

                if (budgetParsed > 0)
                    myBudget.Budget += budgetParsed;
                else
                    myBudget.Budget -= budgetParsed;

                cki = Console.ReadKey(true);


            } while (cki.Key != ConsoleKey.X);
        }

        static void ChangeBudget(decimal value)
        {
            Console.WriteLine($"The Budget value changed to: {value}");
        }

        static void ChangeBudgetArgs(object sender, BudgetChangedArgs e)
        {
            Console.WriteLine("{0} had the '{1}' property changed", sender.GetType(), e.PropChanched);
        }
    }

    class BudgetWatcher
    {
        public void Watch(decimal amount)
        {
            if (amount > 500.0m)
                Console.WriteLine("You reached your savings goal! You have {0}", amount);
        }
    }

    class BudgetChangedArgs : EventArgs
    {
        public string PropChanched;
    }

    class MyBudget
    {
        public event BudgetChangeHandler BudgetChange;
        public event EventHandler<BudgetChangedArgs> BudgetChangeHandler;

        private decimal budget;

        public decimal Budget {
            get { return budget; }
            set 
            {
                budget = value;
                this.BudgetChange(budget);
                this.BudgetChangeHandler(this, new BudgetChangedArgs() { PropChanched = "Budget" }); 
            } 
        }
    }
}
