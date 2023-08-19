using System;

namespace FunctionalProgramming.Mutable
{
    public class Rectangle {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height) {
            Width = width;
            Height = height;
        }

        public void Scale(int factor) {
            Width *= factor;
            Height *= factor;
        }
    }

    public class Ellipse {
        public double Radius { get; private set; }

        public Ellipse(Rectangle rect) {
            Radius = Math.Sqrt(rect.Width * rect.Width +
                               rect.Height * rect.Height) / 2;
        }
    }

    public class ClientCode {
        public void Caller() {    
            var rect = new Rectangle(10, 20);
            Ellipse el = new Ellipse(rect);

            rect.Scale(2);
        }
    }
}