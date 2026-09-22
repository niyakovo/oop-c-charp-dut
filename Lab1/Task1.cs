using System;
using System.Globalization;

namespace Lab1
{
    public class Triangle
    {

        // константа похибки для порівняння double чисел
        private const double Epsilon = 1e-9;

        public static bool AreSidesPositive(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0;
        }

        public static bool CanTriangleExist(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        public static double CalculatePerimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double CalculateArea(double a, double b, double c)
        {
            double halfPerimeter = CalculatePerimeter(a, b, c) / 2.0;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
        }

        public static bool IsEquilateral(double a, double b, double c)
        {
            return (Math.Abs(a - b) < Epsilon) && (Math.Abs(b - c) < Epsilon);
        }

        public static bool IsIsosceles(double a, double b, double c)
        {
            return (Math.Abs(a - b) < Epsilon) || (Math.Abs(a - c) < Epsilon) || (Math.Abs(b - c) < Epsilon);
        }

        public static bool IsRightAngled(double a, double b, double c)
        {
            double a2 = a * a;
            double b2 = b * b;
            double c2 = c * c;

            return (Math.Abs(a2 + b2 - c2) < Epsilon) || (Math.Abs(a2 + c2 - b2) < Epsilon) || (Math.Abs(b2 + c2 - a2) < Epsilon);
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            if (IsEquilateral(a, b, c)) return "Рівносторонній";

            bool isIsosceles = IsIsosceles(a, b, c);
            bool isRight = IsRightAngled(a, b, c);

            if (isIsosceles && isRight) return "Прямокутний рівнобедренний";
            if (isRight) return "Прямокутний";
            if (isIsosceles) return "Рівнобедренний";
            
            return "Довільний";
        }

    }
}