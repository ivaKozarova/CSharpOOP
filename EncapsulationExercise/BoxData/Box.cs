using Microsoft.VisualBasic;
using System;

namespace BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length , double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get { return this.length; }
            set
            { 
                if(value <=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            } 
        }
        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public string SurfaceArea()
        {
            
            return $"Surface Area - {this.Length * this.Width}";
        }
        public string LateralSurfaceArea()
        {
            return $"Lateral Surface Area - {this.Length * this.Height}";
        }
        public string Volume()
        {
            return $"Volume - {this.Length * this.Width * this.Height}";
        }
    }
}
