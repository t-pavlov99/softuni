using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BoxData
{
    internal class Box
    {
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double length;
        private double width;
        private double height;

        public double Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (length * width + length * height + width * height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (length + width) * height;
        }

        public double Volume()
        {
            return length * width * height;
        }
    }
}
