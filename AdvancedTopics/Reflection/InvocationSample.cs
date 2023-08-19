using Shared;
using System;
using static System.Console;

namespace AdvancedTopics.Reflection
{
    public class InvocationSample : ISample
    {
        public void Run()
        {
            var s = "abracadabra";
            var t = typeof(string);
            WriteLine(t);

            var trimMethod = t.GetMethod("Trim", Array.Empty<Type>());
            WriteLine(trimMethod);

            var result = trimMethod.Invoke(s, Array.Empty<object>());
            WriteLine(result);
            
            var numberString = "123";
            var parseMethod = typeof(int).GetMethod("TryParse");
            WriteLine(parseMethod);

            // [Boolean TryParse(System.String, Int32 ByRef)]

            object[] args = { numberString, null };
            var ok = parseMethod.Invoke(null, args);
            WriteLine(ok);
            WriteLine(args[1]);

            var at = typeof(Activator);
            var method = at.GetMethod("CreateInstance", Array.Empty<Type>());
            WriteLine(method);
            
            var ciGeneric = method.MakeGenericMethod(typeof(Guid));
            WriteLine(ciGeneric);
            
            var guid = ciGeneric.Invoke(null, null);
            WriteLine(guid);
        }
    }
}
