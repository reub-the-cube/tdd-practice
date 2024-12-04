namespace AoC._2024.day04.v1
{
    public class Solver(string word)
    {
        private string ReversedWord => new(word.Reverse().ToArray());

        public int CountOccurrencesIn(IEnumerable<string> checkAgainst)
        {
            return checkAgainst.Sum(Scan);
        }

        private int Scan(string text)
        {
            var startIndexes = Enumerable.Range(0, text.Length - word.Length + 1);
            var allSubstrings = startIndexes.Select(s => text.Substring(s, word.Length));
            var numberOfOccurrences = allSubstrings.Count(s => s == word || s == ReversedWord);

            return numberOfOccurrences;
        }
    }
}
