using Shared;
using System;
using static System.Console;

namespace AdvancedTopics.Reflection
{
    public class InspectionSample : ISample
    {
        public void Run()
        {
            var t = typeof(Guid);
            WriteLine(t.FullName);
            WriteLine(t.Name);

            var ctors = t.GetConstructors();
            WriteLine(ctors);

            foreach (var ctor in ctors)
            {
                var methods = t.GetMethods();
                WriteLine(methods);

                foreach (var method in methods)
                {
                    WriteLine(t.GetProperties());
                    WriteLine(t.GetEvents());
                }
            }
        }
    }
}
