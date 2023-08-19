using Shared;
using System;
using static System.Console;

namespace AdvancedTopics.Reflection
{
    public class ConstructionSample : ISample
    {
        public void Run()
        {
            var t = typeof(bool);
            var b = Activator.CreateInstance(t);
            WriteLine(b);
            
            var b2 = Activator.CreateInstance<bool>();
            WriteLine(b2);
            
            var wc = Activator.CreateInstance("System", "System.Timers.Timer");
            WriteLine(wc);

            wc.Unwrap();

            var alType = Type.GetType("System.Collections.ArrayList");
            WriteLine(alType);
            
            var alCtor = alType.GetConstructor(Array.Empty<Type>());
            WriteLine(alCtor);
            
            var al = alCtor.Invoke(Array.Empty<object>());
            WriteLine(al);
            
            var st = typeof(string);
            var ctor = st.GetConstructor(new[] { typeof(char[]) });
            WriteLine(ctor);

            object str = ctor.Invoke(new object[3]);
            WriteLine(str);
            
            var listType = Type.GetType("System.Collection.Generic.List`1");
            WriteLine(listType);
            
            var listOfIntType = listType.MakeGenericType(typeof(int));
            WriteLine(listOfIntType);
            
            var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
            WriteLine(listOfIntCtor);
            
            var theList = listOfIntCtor.Invoke(Array.Empty<object>());
            WriteLine(theList);
            
            var charType = typeof(char);
            WriteLine(Array.CreateInstance(charType, 10));

            var charArrayType = charType.MakeArrayType();
            WriteLine(charArrayType);

            WriteLine(charArrayType.FullName);

            var charArrayCtor = charArrayType.GetConstructor(new[] { typeof(int) });
            WriteLine(charArrayCtor);
            
            var arr = charArrayCtor.Invoke(new object[] { 20 });
            WriteLine(arr);
    }
}
