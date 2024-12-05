namespace AoC._2024.day04.v1
{
    public class WordSearch(string[] letterDistribution)
    {
        public int FindOccurrencesOf(string word)
        {
            var solver = new Solver(word);

            int rowOccurrences = solver.CountOccurrencesIn(letterDistribution);
            int columnOccurrences = solver.CountOccurrencesIn(GetColumns());
            int diagonalOccurences = solver.CountOccurrencesIn(GetDiagonals(word.Length));

            return rowOccurrences + columnOccurrences + diagonalOccurences;
        }

        public int FindXShapeOccurrencesOf(string word)
        {
            var solver = new Solver(word);

            var candidateRowIndexes = Enumerable.Range(0, letterDistribution.Length - word.Length + 1);
            int diagonalOccurrences = candidateRowIndexes.Sum(i => CountDiagonalsForRow(i, word.Length, solver));

            return diagonalOccurrences;
        } 

        private IEnumerable<string> GetColumns()
        {
            return Transpose(letterDistribution);
        }

        private List<string> GetDiagonals(int length)
        {
            var rowsIndexesWithDiagonals = Enumerable.Range(0, letterDistribution.Length - length + 1);
            var diagonals = rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, length, true)).ToList();
            diagonals.AddRange(rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, length, false)).ToList());

            return diagonals;
        }

        private int CountDiagonalsForRow(int row, int length, Solver solver)
        {
            var downAndRight = GetDiagonalsForRow(row, length, true).ToList();
            var downAndLeft = GetDiagonalsForRow(row, length, false).ToList();

            return solver.CountOccurrencesIn([downAndLeft, downAndRight]);
        }

        private IEnumerable<string> GetDiagonalsForRow(int row, int length, bool outFromTop)
        {
            var offsetValues = Enumerable.Range(0, length);

            var offsetStrings = outFromTop ?
                offsetValues.Select(o => new string(letterDistribution[o + row].AsEnumerable().Skip(o).ToArray())) :
                offsetValues.Select(o => new string(letterDistribution[o + row].AsEnumerable().Skip(length - o - 1).ToArray()));

            var offsetWithAdjustedLength = offsetStrings.Select(l => l[..(letterDistribution[0].Length - length + 1)]).ToList();
            return Transpose(offsetWithAdjustedLength);
        }

        private static IEnumerable<string> Transpose(IEnumerable<string> rows)
        {
            IEnumerable<int> columnIndexes = Enumerable.Range(0, rows.First().Length);
            return columnIndexes.Select(c => new string(rows.Select(l => l[c]).ToArray()));
        }
    }
}
