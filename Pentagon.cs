using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Pentagon : Shape
    {
        public double Side { get; private set; }

        public Pentagon(double side)
        {
            Side = side;
        }

        public override double Perimeter()
        {
            return 5 * Side;
        }

        public override double Area()
        {
            double tan36 = Math.Tan(Math.PI / 5);
            return (5 * Side * Side) / (4 * tan36);
        }


        public override bool IsSpecial()
        {
            return true; // All sides are equal (regular pentagon)
        }

        public bool IsConvex()
        {
            // Calculate internal angles of the regular pentagon
            double angle = 108; // Each internal angle of a regular pentagon

            // Check convexity
            var angles = new List<double> { angle, angle, angle, angle, angle };
            return ConvexityChecker.IsConvex(angles);
        }
    }

}
