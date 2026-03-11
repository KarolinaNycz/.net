using System;
using System.IO;

namespace TextAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "";

            if (args.Length > 0)
            {
                string pathFromArgs = args[0];

                if (!File.Exists(pathFromArgs))
                {
                    Console.WriteLine("Błąd: podana ścieżka z argumentu nie istnieje.");
                    return;
                }

                text = File.ReadAllText(pathFromArgs);

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Błąd: plik jest pusty.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Wybierz źródło tekstu:");
                Console.WriteLine("1 - Wpisz tekst ręcznie");
                Console.WriteLine("2 - Wczytaj z pliku");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Wpisz tekst:");
                    text = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Błąd: nie podano tekstu.");
                        return;
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Podaj ścieżkę do pliku:");
                    string? path = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    {
                        Console.WriteLine("Błąd: nieprawidłowa ścieżka do pliku.");
                        return;
                    }

                    text = File.ReadAllText(path);

                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Błąd: plik jest pusty.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Błąd: nieprawidłowy wybór.");
                    return;
                }
            }

            TextStatistics stats = TextAnalyzer.AnalyzeText(text);

            Console.WriteLine("\n--- Statystyki ---");
            Console.WriteLine($"Liczba znaków (ze spacjami): {stats.CharacterCount}");
            Console.WriteLine($"Liczba znaków (bez spacji): {stats.CharacterCountNoSpaces}");
            Console.WriteLine($"Liczba liter: {stats.LetterCount}");
            Console.WriteLine($"Liczba cyfr: {stats.DigitCount}");
            Console.WriteLine($"Liczba znaków interpunkcyjnych: {stats.PunctuationCount}");
            Console.WriteLine($"Liczba słów: {stats.WordCount}");
            Console.WriteLine($"Liczba unikalnych słów: {stats.UniqueWordCount}");
            Console.WriteLine($"Najczęściej występujące słowo: {stats.MostCommonWord}");
            Console.WriteLine($"Średnia długość słowa: {stats.AverageWordLength:F2}");
            Console.WriteLine($"Najdłuższe słowo: {stats.LongestWord}");
            Console.WriteLine($"Najkrótsze słowo: {stats.ShortestWord}");
            Console.WriteLine($"Liczba zdań: {stats.SentenceCount}");
            Console.WriteLine($"Średnia liczba słów na zdanie: {stats.AverageWordsPerSentence:F2}");
            Console.WriteLine($"Najdłuższe zdanie: {stats.LongestSentence}");
        }
    }
}