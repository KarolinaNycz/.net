using NUnit.Framework;
using NUnit.Framework.Legacy;
using TextAnalyzer;

namespace TextAnalyzer.Tests
{
    public class TextAnalyzerTests
    {
        [Test]
        public void CountCharacters_ShouldReturnCorrectNumber()
        {
            string text = "Hello, world!";
            int result = TextAnalyzer.CountCharacters(text);

            ClassicAssert.AreEqual(13, result);
        }

        [Test]
        public void CountWords_ShouldReturnCorrectNumber()
        {
            string text = "Hello world!";
            int result = TextAnalyzer.CountWords(text);

            ClassicAssert.AreEqual(2, result);
        }

        [Test]
        public void CountSentences_ShouldReturnCorrectNumber()
        {
            string text = "Hello world! How are you? I am fine.";
            int result = TextAnalyzer.CountSentences(text);

            ClassicAssert.AreEqual(3, result);
        }

        [Test]
        public void MostCommonWord_ShouldReturnCorrectWord()
        {
            string text = "apple banana apple orange apple banana";
            string result = TextAnalyzer.FindMostCommonWord(text);

            ClassicAssert.AreEqual("apple", result);
        }

        [Test]
        public void AnalyzeText_WithEmptyString_ShouldReturnZeroes()
        {
            string text = "";
            TextStatistics result = TextAnalyzer.AnalyzeText(text);

            ClassicAssert.AreEqual(0, result.CharacterCount);
            ClassicAssert.AreEqual(0, result.WordCount);
            ClassicAssert.AreEqual(0, result.SentenceCount);
        }
    }
}