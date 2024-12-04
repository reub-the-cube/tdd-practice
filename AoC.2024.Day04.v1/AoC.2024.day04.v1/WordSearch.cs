namespace AoC._2024.day04.v1
{
    public class WordSearch(string[] letterDistribution)
    {
        public int FindOccurrencesOf(string word)
        {
            int rowOccurrences = CountOccurrencesIn(letterDistribution, word);
            int columnOccurrences = CountOccurrencesIn(GetColumns(letterDistribution), word);
            int diagonalOccurences = CountOccurrencesIn(GetDiagonals(word), word);

            return rowOccurrences + columnOccurrences + diagonalOccurences;
        }

        private static int CountOccurrencesIn(IEnumerable<string> checkAgainst, string word)
        {
            return checkAgainst.Sum(c => Scan(c, word));
        }

        private static IEnumerable<string> GetColumns(IEnumerable<string> rows)
        {
            IEnumerable<int> columnIndexes = Enumerable.Range(0, rows.First().Length);
            return columnIndexes.Select(c => new string(rows.Select(l => l[c]).ToArray()));
        }

        private List<string> GetDiagonals(string word)
        {
            var rowsIndexesWithDiagonals = Enumerable.Range(0, letterDistribution.Length - word.Length + 1);
            var downAndRightDiagonals = rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, word, true)).ToList();
            var downAndLeftDiagonals = rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, word, false)).ToList();

            downAndRightDiagonals.AddRange(downAndLeftDiagonals);
            return downAndRightDiagonals;
        }

        private IEnumerable<string> GetDiagonalsForRow(int row, string word, bool outFromTop)
        {
            var offsetValues = Enumerable.Range(0, word.Length);

            var offsetStrings = outFromTop ?
                offsetValues.Select(o => new string(letterDistribution[o + row].AsEnumerable().Skip(o).ToArray())) :
                offsetValues.Select(o => new string(letterDistribution[o + row].AsEnumerable().Skip(word.Length - o - 1).ToArray()));

            var offsetWithAdjustedLength = offsetStrings.Select(l => l[..(letterDistribution[0].Length - word.Length + 1)]).ToList();
            return GetColumns(offsetWithAdjustedLength);
        }

        private static int Scan(string row, string word)
        {
            string reversedWord = new(word.Reverse().ToArray());

            var startIndexes = Enumerable.Range(0, row.Length - word.Length + 1);
            var allSubstrings = startIndexes.Select(s => row.Substring(s, word.Length));
            var numberOfOccurrences = allSubstrings.Count(s => s == word || s == reversedWord);

            return numberOfOccurrences;
        }
    }
}
