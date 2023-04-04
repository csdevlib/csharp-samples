using Shared;
using System;
using static System.Console;
namespace AdvancedTopics.Reflection
{
    public class SystemTypeSample : ISample
    {
        public void Run()
        {
            Type t = typeof(int);
            t.GetMethods();

            Type t2 = "hello".GetType(); ;
            WriteLine(t2.FullName);

            WriteLine(t2.GetFields());


            WriteLine(t2.GetMethods());

            var a = typeof(string).Assembly;
            WriteLine(a);
            
            var types = a.GetTypes();
            WriteLine(types[10]);

            WriteLine(types[10].FullName);

            WriteLine(types[10].GetMethods());

            var t3 = Type.GetType("System.Int64");
            WriteLine(t3.FullName);

            WriteLine(t3.GetMethods());
        
            var t4 = Type.GetType("System.Collections.Generic.List`1");
            WriteLine(t4.FullName);

            WriteLine(t4.GetFields());
            WriteLine(t4.GetMethods());
        }
    }
}
