using System;
using System.Collections.Generic;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book(1, "C# Programming", "John Doe"));
            library.AddBook(new Book(2, "Design Patterns", "Gamma et al."));
            library.AddBook(new EBook(3, "Clean Code", "Robert C. Martin", "PDF"));

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== LIBRARY MENU =====");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Show all books");
                Console.WriteLine("3. Show available books");
                Console.WriteLine("4. Borrow book");
                Console.WriteLine("5. Return book");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookMenu(library);
                        break;

                    case "2":
                        library.DisplayAllBooks();
                        break;

                    case "3":
                        List<Book> availableBooks = library.ListAvailableBooks();

                        if (availableBooks.Count == 0)
                        {
                            Console.WriteLine("No available books.");
                        }
                        else
                        {
                            foreach (var book in availableBooks)
                            {
                                book.DisplayInfo();
                            }
                        }
                        break;

                    case "4":
                        BorrowBookMenu(library);
                        break;

                    case "5":
                        ReturnBookMenu(library);
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddBookMenu(Library library)
        {
            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write("Enter title: ");
                string title = Console.ReadLine()!;

                Console.Write("Enter author: ");
                string author = Console.ReadLine()!;

                Console.Write("Is this an e-book? (y/n): ");
                string? isEbook = Console.ReadLine();

                if (isEbook?.ToLower() == "y")
                {
                    Console.Write("Enter file format: ");
                    string format = Console.ReadLine()!;
                    library.AddBook(new EBook(id, title, author, format));
                }
                else
                {
                    library.AddBook(new Book(id, title, author));
                }

                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void BorrowBookMenu(Library library)
        {
            try
            {
                Console.Write("Enter book ID: ");
                int bookId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter borrower name: ");
                string borrowerName = Console.ReadLine()!;

                library.BorrowBook(bookId, borrowerName);
                Console.WriteLine("Book borrowed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ReturnBookMenu(Library library)
        {
            try
            {
                Console.Write("Enter book ID: ");
                int bookId = int.Parse(Console.ReadLine()!);

                library.ReturnBook(bookId);
                Console.WriteLine("Book returned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}