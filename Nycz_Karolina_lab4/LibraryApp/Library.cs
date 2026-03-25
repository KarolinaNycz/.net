using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class Library : IBookOperations
    {
        private readonly List<Book> _books = new();

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (_books.Any(b => b.Id == book.Id))
                throw new InvalidOperationException("A book with this ID already exists.");

            _books.Add(book);
        }

        public List<Book> ListAvailableBooks()
        {
            return _books.Where(b => b.IsAvailable).ToList();
        }

        public void DisplayAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Library is empty.");
                return;
            }

            foreach (var book in _books)
            {
                book.DisplayInfo();
            }
        }

        public void BorrowBook(int bookId, string borrowerName)
        {
            Book book = _books.FirstOrDefault(b => b.Id == bookId)
                ?? throw new KeyNotFoundException("Book not found.");

            book.Borrow(borrowerName);
        }

        public void ReturnBook(int bookId)
        {
            Book book = _books.FirstOrDefault(b => b.Id == bookId)
                ?? throw new KeyNotFoundException("Book not found.");

            book.Return();
        }
    }
}