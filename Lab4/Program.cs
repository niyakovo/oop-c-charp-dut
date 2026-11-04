using System;

namespace Lab4
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();

            library.AddBook(new Book(1, "Метро 2033", "Дмитро Глуховський"));
            library.AddBook(new Book(2, "Метро 2034", "Дмитро Глуховський"));
            library.AddBook(new Book(3, "Чистий код", "Роберт Мартін"));

            library.AddUser(new User(1, "Володимир"));
            library.AddUser(new User(2, "Денис"));

            Console.WriteLine("=== Система Бібліотеки ===");

            library.PrintAvailableBooks();

            Console.WriteLine("\n[Операція] Володимир бере 'Метро 2033'...");
            library.RentBook(1, 1);

            Console.WriteLine("\n[Операція] Денис намагається взяти 'Метро 2033'...");
            library.RentBook(2, 1);

            Console.WriteLine("\n[Операція] Денис намагається повернути 'Метро 2033'...");
            library.ReturnBook(2, 1);

            Console.WriteLine("\n[Операція] Володимир повертає 'Метро 2033'...");
            library.ReturnBook(1, 1);

            library.PrintAvailableBooks();
            library.PrintAllUsers();
        }
    }
}