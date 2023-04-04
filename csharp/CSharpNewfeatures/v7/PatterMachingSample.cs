using Shared;
using System;
using System.Collections.Generic;

namespace CSharpNewfeatures
{
    public class Shape
    {

    }

    public class Rectangle : Shape
    {
        public int Width, Height;
    }

    public class Circle : Shape
    {
        public int Diameter;
    }

    public class PatterMachingSample : ISample
    {
        public void Run()
        {
            List<Shape> shapes = new() { new Circle(), new Rectangle() };

            foreach (var shape in shapes)
            {
                PatternMatching.DisplayShape(shape);
            }
        }

        public class PatternMatching
        {
            public static void DisplayShape(Shape shape)
            {
                //if (shape is Rectangle)
                //{
                //    var rc = (Rectangle)shape;

                //}
                //else if (shape is Circle)
                //{
                //    // ...
                //}


                //var rect = shape as Rectangle;
                //if (rect != null) // nonnull
                //{
                //    //...
                //}

                if (shape is Rectangle r)
                {
                    Console.WriteLine($"Matching: H x W {r.Height * r.Width}");
                }

                // can also do the invserse
                if (shape is Circle cc)
                {
                    Console.WriteLine($"Matching: Diameter {cc.Diameter}");
                }


                switch (shape)
                {
                    case Circle c:
                        Console.WriteLine($"Matching: Diameter {c.Diameter}");
                        break;
                    case Rectangle sq when (sq.Width == sq.Height):
                        Console.WriteLine($"Matching: H x W {sq.Height * sq.Width}");
                        break;
                    case Rectangle rr:
                        Console.WriteLine($"Matching: H x W {rr.Height * rr.Width}");
                        break;
                }

                //var z = (23, 32);

                //switch (z)
                //{
                //  case (0, 0):
                //    WriteLine("origin");
                //}
            }
        }
    }
}
