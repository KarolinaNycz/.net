using System;
using System.Linq;

namespace TextAnalyzer
{
    public static class TextAnalyzer
    {
        public static int CountCharacters(string text)
        {
            return text.Length;
        }

        public static int CountCharactersNoSpaces(string text)
        {
            return text.Count(c => !char.IsWhiteSpace(c));
        }

        public static int CountLetters(string text)
        {
            return text.Count(char.IsLetter);
        }

        public static int CountDigits(string text)
        {
            return text.Count(char.IsDigit);
        }

        public static int CountPunctuation(string text)
        {
            return text.Count(char.IsPunctuation);
        }

        public static int CountWords(string text)
        {
            return text
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Length;
        }

        public static int CountSentences(string text)
        {
            return text.Count(c => c == '.' || c == '!' || c == '?');
        }

        public static string FindMostCommonWord(string text)
        {
            var words = text
                .ToLower()
                .Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?', '\"', '\'', '(', ')', '[', ']' },
                    StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return "";

            return words
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .First()
                .Key;
        }

        public static TextStatistics AnalyzeText(string text)
        {
            TextStatistics stats = new TextStatistics();

            if (string.IsNullOrWhiteSpace(text))
                return stats;

            var words = text
                .Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?', '\"', '\'', '(', ')', '[', ']' },
                    StringSplitOptions.RemoveEmptyEntries);

            var sentences = text
                .Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => s.Length > 0)
                .ToArray();

            stats.CharacterCount = CountCharacters(text);
            stats.CharacterCountNoSpaces = CountCharactersNoSpaces(text);
            stats.LetterCount = CountLetters(text);
            stats.DigitCount = CountDigits(text);
            stats.PunctuationCount = CountPunctuation(text);
            stats.WordCount = words.Length;
            stats.UniqueWordCount = words.Select(w => w.ToLower()).Distinct().Count();
            stats.MostCommonWord = FindMostCommonWord(text);

            if (words.Length > 0)
            {
                stats.AverageWordLength = words.Average(w => w.Length);
                stats.LongestWord = words.OrderByDescending(w => w.Length).First();
                stats.ShortestWord = words.OrderBy(w => w.Length).First();
            }

            stats.SentenceCount = CountSentences(text);

            if (sentences.Length > 0)
            {
                stats.AverageWordsPerSentence = (double)words.Length / sentences.Length;

                stats.LongestSentence = sentences
                    .OrderByDescending(s => s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length)
                    .First();
            }

            return stats;
        }
    }
}