using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private List<User> _users = new List<User>();

        public void AddBook(Book book) => _books.Add(book);
        public void AddUser(User user) => _users.Add(user);

        public void RentBook(int userId, int bookId)
        {
            User? user = _users.FirstOrDefault(u => u.Id == userId);
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);

            if (user == null)
            {
                Console.WriteLine($"[Помилка] Користувача з ID {userId} не знайдено.");
                return;
            }
            if (book == null)
            {
                Console.WriteLine($"[Помилка] Книгу з ID {bookId} не знайдено.");
                return;
            }
            if (!book.IsAvailable)
            {
                Console.WriteLine($"[Помилка] Книга \"{book.Title}\" вже перебуває в оренді.");
                return;
            }

            book.MarkAsBorrowed();
            user.RentBook(book);
            Console.WriteLine($"[Успіх] Користувач {user.Name} взяв в оренду книгу \"{book.Title}\".");
        }

        public void ReturnBook(int userId, int bookId)
        {
            User? user = _users.FirstOrDefault(u => u.Id == userId);
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null) return;

            if (user.RentedBooks.Contains(book))
            {
                book.MarkAsReturned();
                user.ReturnBook(book);
                Console.WriteLine($"[Успіх] Користувач {user.Name} повернув книгу \"{book.Title}\".");
            }
            else
            {
                Console.WriteLine($"[Помилка] Користувач {user.Name} не орендував книгу \"{book.Title}\".");
            }
        }

        public void PrintAvailableBooks()
        {
            Console.WriteLine("\n--- Доступні книги ---");
            var availableBooks = _books.Where(b => b.IsAvailable).ToList();
            
            if (availableBooks.Count == 0)
                Console.WriteLine("Немає доступних книг.");
            else
                foreach (var book in availableBooks) Console.WriteLine(book.ToString());
        }
        
        public void PrintAllUsers()
        {
            Console.WriteLine("\n--- Статус користувачів ---");
            foreach (var user in _users)
            {
                user.PrintInfo();
            }
        }
    }
}