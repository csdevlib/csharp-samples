using Shared;
using System;
using System.Collections.Generic;
using static System.Console;

namespace CSharpNewfeatures
{
    public class RefReturnsAndLocalSample : ISample
    {
        public void Run()
        {
            static ref int Find(int[] numbers, int value)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == value)
                        return ref numbers[i];
                }

                // cannot do by value return
                //return -1;

                // cannot return a local
                //int fail = -1;
                //return ref fail;

                throw new ArgumentException("meh");
            }

            static ref int Min(ref int x, ref int y)
            {
                //return x < y ? (ref x) : (ref) y;
                //return ref (x < y ? x : y);
                if (x < y) return ref x;
                return ref y;
            }

            static void MainRRL(string[] args)
            {
                // reference to a local element
                int[] numbers = { 1, 2, 3 };
                ref int refToSecond = ref numbers[1];
                var valueOfSecond = refToSecond;

                // cannot rebind
                // refToSecond = ref numbers[0];

                refToSecond = 123;
                WriteLine(string.Join(",", numbers)); // 1, 123, 3

                // reference persists even after the array is resized
                Array.Resize(ref numbers, 1);
                WriteLine($"second = {refToSecond}, array size is {numbers.Length}");
                refToSecond = 321;
                WriteLine($"second = {refToSecond}, array size is {numbers.Length}");
                //numbers.SetValue(321, 1); // will throw

                // won't work with lists
                var numberList = new List<int> { 1, 2, 3 };
                //ref int second = ref numberList[1]; // property or indexer cannot be out


                int[] moreNumbers = { 10, 20, 30 };
                //ref int refToThirty = ref Find(moreNumbers, 30);
                //refToThirty = 1000;

                // disgusting use of language
                Find(moreNumbers, 30) = 1000;

                WriteLine(string.Join(",", moreNumbers));

                // too many references:
                int a = 1, b = 2;
                ref var minRef = ref Min(ref a, ref b);

                // non-ref call just gets the value
                int minValue = Min(ref a, ref b);
                WriteLine($"min is {minValue}");
            }
        }
    }
}
