using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Triangle : Shape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double Perimeter()
        {
            return SideA + SideB + SideC;
        }

        public override double Area()
        {
            // Using Heron's formula for the area of a triangle
            double s = Perimeter() / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public override bool IsSpecial()
        {
            return SideA == SideB && SideB == SideC; // Equilateral triangle
        }

        public bool IsConvex()
        {
            // Calculate internal angles of the triangle
            double angleA = Math.Acos((SideB * SideB + SideC * SideC - SideA * SideA) / (2 * SideB * SideC)) * (180 / Math.PI);
            double angleB = Math.Acos((SideA * SideA + SideC * SideC - SideB * SideB) / (2 * SideA * SideC)) * (180 / Math.PI);
            double angleC = 180 - angleA - angleB;

            // Check convexity
            var angles = new List<double> { angleA, angleB, angleC };
            return ConvexityChecker.IsConvex(angles);
        }
    }

}
