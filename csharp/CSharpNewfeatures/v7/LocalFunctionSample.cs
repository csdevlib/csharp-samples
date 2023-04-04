using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewfeatures
{
    public class LocalFunctionSample : ISample
    {

        public class EquationSolver
        {
            //private Func<double, double, double, double> CalculateDiscriminant = (aa, bb, cc) => bb * bb - 4 * aa * cc;

            public static Tuple<double, double> SolveQuadratic(double a, double b, double c)
            {
                //var CalculateDiscriminant = new Func<double, double, double, double>((aa, bb, cc) => bb * bb - 4 * aa * cc);

                //double CalculateDiscriminant(double aa, double bb, double cc)
                //{
                //  return bb * bb - 4 * aa * cc;
                //}
                //double CalculateDiscriminant(double aa, double bb, double cc) => bb * bb - 4 * aa * cc;
                //double CalculateDiscriminant() => b * b - 4 * a * c;

                //var disc = CalculateDiscriminant(a, b, c);
                var disc = CalculateDiscriminant();

                var rootDisc = Math.Sqrt(disc);
                return Tuple.Create(
                  (-b + rootDisc) / (2 * a),
                  (-b - rootDisc) / (2 * a)
                );

                // can place here
                double CalculateDiscriminant() => b * b - 4 * a * c;
            }

            //private static double CalculateDiscriminant(double a, double b, double c)
            //{
            //  return b * b - 4 * a * c;
            //}
        }

        public class LocalFunctions
        {
            static void MainT(string[] args)
            {
                
            }
        }

        public void Run()
        {
            var result = EquationSolver.SolveQuadratic(1, 10, 16);
            Console.WriteLine(result);
        }
    }
}
