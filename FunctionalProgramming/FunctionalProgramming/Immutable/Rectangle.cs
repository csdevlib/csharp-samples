using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Immutable {
    public class Rectangle {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height) {
            Width = width;
            Height = height;
        }

        public Rectangle Scale(int factor) {
            return new Rectangle(Width * factor, Height * factor);
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

            Rectangle newRect = rect.Scale(2);
        }
    }
}