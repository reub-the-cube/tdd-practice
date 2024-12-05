namespace AoC._2024.day04.v1
{
    public class Solver(string word)
    {
        private string ReversedWord => new(word.Reverse().ToArray());

        public int CountOccurrencesIn(IEnumerable<string> checkAgainst)
        {
            return checkAgainst.Sum(Scan);
        }

        public int CountOccurrencesIn(IEnumerable<List<string>> checkAgainst)
        {
            var indexes = Enumerable.Range(0, checkAgainst.First().Count);
            return indexes.Count(i => checkAgainst.All(c => IsMatch(c[i])));
        }

        private int Scan(string text)
        {
            var startIndexes = Enumerable.Range(0, text.Length - word.Length + 1);
            var allSubstrings = startIndexes.Select(s => text.Substring(s, word.Length));
            var numberOfOccurrences = allSubstrings.Count(IsMatch);

            return numberOfOccurrences;
        }

        private bool IsMatch(string against)
        {
            return against == word || against == ReversedWord;
        }
    }
}
