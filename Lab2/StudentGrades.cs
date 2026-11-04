using System;

namespace Lab2
{
    public class StudentGrades
    {
        public static double GetAverage(int[] grades)
        {
            double sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;
        }

        public static int GetMin(int[] grades)
        {
            int min = grades[0];
            for (int i = 1; i < grades.Length; i++)
            {
                if (grades[i] < min)
                {
                    min = grades[i];
                }
            }
            return min;
        }

        public static int GetMax(int[] grades)
        {
            int max = grades[0];
            for (int i = 1; i < grades.Length; i++)
            {
                if (grades[i] > max)
                {
                    max = grades[i];
                }
            }
            return max;
        }

        public static int[] GetAllGrades(int[][] groups)
        {
            int totalStudents = 0;
            for (int i = 0; i < groups.Length; i++)
            {
                totalStudents += groups[i].Length;
            }

            int[] allGrades = new int[totalStudents];
            int index = 0;

            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups[i].Length; j++)
                {
                    allGrades[index] = groups[i][j];
                    index++;
                }
            }

            return allGrades;
        }
    }
}