using System;

namespace Lab2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[][] groups = new int[3][];
            groups[0] = GenerateGrades(10); 
            groups[1] = GenerateGrades(15);
            groups[2] = GenerateGrades(12);

            Console.WriteLine("=== Статистика по групах ===");
            for (int i = 0; i < groups.Length; i++)
            {
                double avg = StudentGrades.GetAverage(groups[i]);
                int min = StudentGrades.GetMin(groups[i]);
                int max = StudentGrades.GetMax(groups[i]);

                Console.WriteLine($"Група {i + 1}: Середній бал = {avg:F2}, Мін = {min}, Макс = {max}");
            }

            Console.WriteLine("\n=== Статистика по потоку ===");
            int[] allGrades = StudentGrades.GetAllGrades(groups);
            
            double totalAvg = StudentGrades.GetAverage(allGrades);
            int totalMin = StudentGrades.GetMin(allGrades);
            int totalMax = StudentGrades.GetMax(allGrades);

            Console.WriteLine($"Потік: Середній бал = {totalAvg:F2}, Мін = {totalMin}, Макс = {totalMax}");
        }

        private static int[] GenerateGrades(int studentCount)
        {
            Random random = new Random();
            int[] grades = new int[studentCount];
            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = random.Next(1, 101);
            }
            return grades;
        }
    }
}