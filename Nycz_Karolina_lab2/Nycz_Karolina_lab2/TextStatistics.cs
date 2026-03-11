namespace TextAnalyzer
{
    public class TextStatistics
    {
        public int CharacterCount { get; set; }
        public int CharacterCountNoSpaces { get; set; }
        public int LetterCount { get; set; }
        public int DigitCount { get; set; }
        public int PunctuationCount { get; set; }
        public int WordCount { get; set; }
        public int UniqueWordCount { get; set; }
        public string MostCommonWord { get; set; } = "";
        public double AverageWordLength { get; set; }
        public string LongestWord { get; set; } = "";
        public string ShortestWord { get; set; } = "";
        public int SentenceCount { get; set; }
        public double AverageWordsPerSentence { get; set; }
        public string LongestSentence { get; set; } = "";
    }
}