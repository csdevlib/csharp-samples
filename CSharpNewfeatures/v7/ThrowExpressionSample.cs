using Shared;
using System;
using static System.Console;

namespace CSharpNewfeatures.v7
{

    public class ThrowExpressions
    {
        public string Name { get; set; }

        public ThrowExpressions(string name)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        }

        public int GetValue(int n)
        {
            return n > 0 ? n + 1 : throw new Exception();
        }
    }

    public class ThrowExpressionSample : ISample
    {
        public void Run()
        {
            int v = -1;
            try
            {
                var te = new ThrowExpressions("");
                v = te.GetValue(-1); // does not get defaulted!
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                WriteLine(v);
            }
        }
    }
}
