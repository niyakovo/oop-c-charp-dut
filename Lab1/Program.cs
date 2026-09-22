using System;

namespace Lab1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Розрахунок параметрів трикутника ===");

            Console.Write("Введіть сторону a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть сторону b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть сторону c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            if (!Triangle.AreSidesPositive(a, b, c))
            {
                Console.WriteLine("\n[Помилка] Сторони повинні бути строго додатними числами (> 0).");
                return;
            }

            if (!Triangle.CanTriangleExist(a, b, c))
            {
                Console.WriteLine("\n[Помилка] Трикутник не існує (сума будь-яких двох сторін має бути більшою за третю).");
                return;
            }

            double perimeter = Triangle.CalculatePerimeter(a, b, c);
            double area = Triangle.CalculateArea(a, b, c);
            string type = Triangle.GetTriangleType(a, b, c);

            Console.WriteLine("\n--- Результати ---");
            Console.WriteLine($"Периметр: {perimeter:F3}");
            Console.WriteLine($"Площа:    {area:F3}");
            Console.WriteLine($"Вид:      {type}");
        }
    }
}