using System;

namespace Shapes.Models
{
    class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height ,double width)
        {
            this.height = height;
            this.width = width;
        }
        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            var perimeter = this.height * 2 + this.width * 2;
            return perimeter;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }

    }
}
