using Shared;
using System;

namespace AdvancedTopics.Reflection
{
    public class RepeatAttribute : Attribute
    {
        public int Times { get; }

        public RepeatAttribute(int times)
        {
            Times = times;
        }
    }

    public class AttributeSample : ISample
    {
        [RepeatAttribute(3)]
        public void SomeMethod()
        {

        }

        public void Run()
        {
            var sm = typeof(AttributeSample).GetMethod("SomeMethod");
            foreach (var att in sm.GetCustomAttributes(true))
            {
                Console.WriteLine("Found an attribute: " + att.GetType());
                if (att is RepeatAttribute ra)
                {
                    Console.WriteLine($"Need to repeat {ra.Times} times");
                }
            }
        }

    }
