using System;

namespace LibraryApp
{
    public class EBook : Book
    {
        public string FileFormat { get; }

        public EBook(int id, string title, string author, string fileFormat)
            : base(id, title, author)
        {
            if (string.IsNullOrWhiteSpace(fileFormat))
                throw new ArgumentException("File format cannot be empty.");

            FileFormat = fileFormat;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, Available: {IsAvailable}, Format: {FileFormat}");
        }
    }
}