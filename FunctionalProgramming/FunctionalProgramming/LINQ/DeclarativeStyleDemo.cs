using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming.LINQ {
    public class Demo {
        public static void Do(List<Customer> customers) {      
            var maleCustomers = GetMaleCustomers(customers);
            var privelegedCustomers = GetPrivelegedCustomers(maleCustomers);
        }

        public static void Do2(List<Customer> customers) {
            var privCustomers = customers.Where(customer => customer.Sex == Sex.Male)
                                         .Cast<PrivilegedCustomer>();
        }

        private static List<PrivilegedCustomer> GetPrivelegedCustomers(List<Customer> maleCustomers) {
            var privilegedCustomers = new List<PrivilegedCustomer>();
            foreach (var maleCustomer in maleCustomers) {
                privilegedCustomers.Add((PrivilegedCustomer) maleCustomer);
            }
            return privilegedCustomers;
        }

        private static List<Customer> GetMaleCustomers(List<Customer> customers) {
            var maleCustomers = new List<Customer>();
            foreach (var customer in customers) {
                if (customer.Sex == Sex.Male) {
                    maleCustomers.Add(customer);
                }
            }
            return maleCustomers;
        }


        public void LoopStatementForEach() {
            var array = new int[] {1, 2, 3};
            int sum = 0; // initialization is required 
            foreach (var i in array) {
                sum += i;
            }

            Console.WriteLine("sum={0}", sum);
        }

        public void LoopExpression() {
            var array = new int[] {1, 2, 3};

            var sum = array.Aggregate(0, (sumSoFar, i) => sumSoFar + i);

            Console.WriteLine("sum={0}", sum);
        }
    }

    public enum Sex {
        Male,
        Female
    }

    public class Customer {
        public Sex Sex { get; }

        public Customer(Sex sex) {
            Sex = sex;
        }
    }

    public class PrivilegedCustomer : Customer {
        public PrivilegedCustomer(Sex sex) : base(sex) { }
    }

    public class DeclarativeStyleDemo { }
}