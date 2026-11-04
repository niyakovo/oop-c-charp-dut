using System;
using System.Collections.Generic;

namespace Lab4
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        private List<Book> _rentedBooks;
        public IReadOnlyList<Book> RentedBooks => _rentedBooks.AsReadOnly();

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            _rentedBooks = new List<Book>();
        }

        public void RentBook(Book book)
        {
            _rentedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            _rentedBooks.Remove(book);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Користувач: [{Id}] {Name}. Орендовано книг: {_rentedBooks.Count}");
            foreach (var book in _rentedBooks)
            {
                Console.WriteLine($"  - {book.Title}");
            }
        }
    }
}