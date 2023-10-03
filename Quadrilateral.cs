using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Quadrilateral : Shape
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }
        public double Side4 { get; private set; }

        public Quadrilateral(double side1, double side2, double side3, double side4)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Side4 = side4;
        }

        public override double Perimeter()
        {
            return Side1 + Side2 + Side3 + Side4;
        }

        public override double Area()
        {
            // For quadrilaterals, additional logic would be needed to calculate the area
            return 0;
        }

        public override bool IsSpecial()
        {
            return Side1 == Side3 && Side2 == Side4; // Opposite sides are equal (parallelogram)
        }

        public bool IsConvex()
        {
            // Calculate internal angles of the quadrilateral
            double angle1 = Math.Acos((Side1 * Side1 + Side2 * Side2 - Side3 * Side3) / (2 * Side1 * Side2)) * (180 / Math.PI);
            double angle2 = Math.Acos((Side2 * Side2 + Side3 * Side3 - Side4 * Side4) / (2 * Side2 * Side3)) * (180 / Math.PI);
            double angle3 = Math.Acos((Side3 * Side3 + Side4 * Side4 - Side1 * Side1) / (2 * Side3 * Side4)) * (180 / Math.PI);
            double angle4 = 180 - angle1 - angle2 - angle3;

            // Check convexity
            var angles = new List<double> { angle1, angle2, angle3, angle4 };
            return ConvexityChecker.IsConvex(angles);
        }
    }


}
