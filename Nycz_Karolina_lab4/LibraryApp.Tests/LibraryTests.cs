using System;
using Xunit;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void BorrowBook_ShouldMarkBookAsUnavailable()
        {
            Library library = new Library();
            Book book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);

            library.BorrowBook(1, "Alice");

            Assert.False(book.IsAvailable);
            Assert.Equal("Alice", book.BorrowerName);
        }

        [Fact]
        public void BorrowBook_ShouldThrowException_WhenBookAlreadyBorrowed()
        {
            Library library = new Library();
            Book book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);
            library.BorrowBook(1, "Alice");

            Assert.Throws<InvalidOperationException>(() => library.BorrowBook(1, "Bob"));
        }

        [Fact]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            Library library = new Library();
            Book book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);
            library.BorrowBook(1, "Alice");

            library.ReturnBook(1);

            Assert.True(book.IsAvailable);
            Assert.Null(book.BorrowerName);
        }

        [Fact]
        public void ReturnBook_ShouldThrowException_WhenBookWasNotBorrowed()
        {
            Library library = new Library();
            Book book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);

            Assert.Throws<InvalidOperationException>(() => library.ReturnBook(1));
        }
    }
}