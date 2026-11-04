using System;

namespace Lab3
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Hunter player1 = new Hunter("Володимир", 100, 20, 5);
            Hunter player2 = new VeteranHunter("Денис", 100, 20, 5);

            Console.WriteLine("=== Змагання Мисливців Починається! ===");
            player1.PrintInfo();
            player2.PrintInfo();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Володимир: Полювати");
                Console.WriteLine("2. Володимир: Купити 3 стріли (15 золота)");
                Console.WriteLine("3. Денис: Полювати");
                Console.WriteLine("4. Денис: Купити 3 стріли (15 золота)");
                Console.WriteLine("5. Показати статистику обох мисливців");
                Console.WriteLine("0. Завершити змагання");
                Console.Write("Ваш вибір: ");
                
                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": player1.Hunt(); break;
                    case "2": player1.BuyArrows(3); break;
                    case "3": player2.Hunt(); break;
                    case "4": player2.BuyArrows(3); break;
                    case "5": 
                        player1.PrintInfo(); 
                        player2.PrintInfo(); 
                        break;
                    case "0": isRunning = false; break;
                    default: Console.WriteLine("Невідома команда."); break;
                }
            }

            Console.WriteLine("\n=== Результати змагання ===");
            player1.PrintInfo();
            player2.PrintInfo();

            Console.WriteLine();
            if (player1.Prey > player2.Prey)
            {
                Console.WriteLine($"Переможець: {player1.Name}!");
            }
            else if (player2.Prey > player1.Prey)
            {
                Console.WriteLine($"Переможець: {player2.Name}!");
            }
            else
            {
                Console.WriteLine("Нічия! Обидва мисливці здобули однакову кількість здобичі.");
            }
        }
    }
}