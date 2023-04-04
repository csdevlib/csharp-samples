using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FunctionalProgramming.Builder {
    public sealed class Person {
        public int Age { get; }
        public string Name { get; }
        public IReadOnlyCollection<string> Phones { get; }

        public Person() { }

        public Person(string name, int age, IReadOnlyCollection<string> phones) {
            Name = name;
            Age = age;
            Phones = phones;
        }

        public Person WithName(string name) {
            return new Person(name, Age, Phones);
        }

        public Person WithAge(int age) {
            return new Person(Name, age, Phones);
        }

        public Person WithPhones(IReadOnlyCollection<string> phones) {
            return new Person(Name, Age, phones);
        }
    }

    public class PersonClient {
        public static void Run() {
            var jon = new Person(
                name: null,
                age: 30,
                phones: new ReadOnlyCollection<string>(new List<string>() {"12345", "67890"}));

            var realJon = jon.WithName("Jon Skeet")
                             .WithAge(35);
        }
    }
}