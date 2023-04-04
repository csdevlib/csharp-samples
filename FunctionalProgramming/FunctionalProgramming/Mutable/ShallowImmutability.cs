using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalProgramming.Mutable {
    public class Account {
        public string Name { get; }
        public IReadOnlyCollection<string> EMails { get; }

        public Account(string name, IReadOnlyCollection<string> emails) {
            Name = name;
            EMails = emails;            
        }
    }

    public class AccountClient {
        public static void Run() {
            var emails = new List<string>();
            var acc = new Account("NoName", emails);

            emails.Add("abcd@gmail.com");
            Console.WriteLine(acc.EMails.Count);

            //acc.EMails.Add("efgh@gmail.com");
            Console.WriteLine(acc.EMails.Count);
        }
    }
}