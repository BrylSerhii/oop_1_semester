using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the shapes
            Triangle triangle = new Triangle(3, 4, 5);
            Quadrilateral quadrilateral = new Quadrilateral(4, 4, 5, 5);
            Pentagon pentagon = new Pentagon(6);

            Console.WriteLine("Triangle Perimeter: " + triangle.Perimeter());
            Console.WriteLine("Triangle Area: " + triangle.Area());
            Console.WriteLine("Is the triangle special (equilateral): " + triangle.IsSpecial());
            Console.WriteLine("Is the convex triangle: " + triangle.IsConvex());

            Console.WriteLine("Quadrilateral Perimeter: " + quadrilateral.Perimeter());
            Console.WriteLine("Quadrilateral Area: " + quadrilateral.Area());
            Console.WriteLine("Is the quadrilateral special (parallelogram): " + quadrilateral.IsSpecial());
            Console.WriteLine("Is the convex Quadrilateral: " + quadrilateral.IsConvex());

            Console.WriteLine("Pentagon Perimeter: " + pentagon.Perimeter());
            Console.WriteLine("Pentagon Area: " + pentagon.Area());
            Console.WriteLine("Is the pentagon special (regular): " + pentagon.IsSpecial());
            Console.WriteLine("Is the convex Pentagon: " + pentagon.IsConvex());
        }
    }
}
