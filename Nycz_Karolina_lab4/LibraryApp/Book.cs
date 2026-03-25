using System;

namespace LibraryApp
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; protected set; }
        public string? BorrowerName { get; protected set; }

        public Book(int id, string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be empty.");

            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
            BorrowerName = null;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, Available: {IsAvailable}");
        }

        public virtual void Borrow(string borrowerName)
        {
            if (!IsAvailable)
                throw new InvalidOperationException("This book is already borrowed.");

            if (string.IsNullOrWhiteSpace(borrowerName))
                throw new ArgumentException("Borrower name cannot be empty.");

            IsAvailable = false;
            BorrowerName = borrowerName;
        }

        public virtual void Return()
        {
            if (IsAvailable)
                throw new InvalidOperationException("This book was not borrowed.");

            IsAvailable = true;
            BorrowerName = null;
        }
    }
}