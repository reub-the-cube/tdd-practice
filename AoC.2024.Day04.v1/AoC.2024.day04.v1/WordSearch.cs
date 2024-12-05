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
            int diagonalOccurences = 0;// solver.CountOccurrencesIn(GetDiagonals(word.Length));

            for (int i = 0; i < letterDistribution.Length - word.Length + 1; i++)
            {
                var rowCount = 0;
                var downAndRightDiagonals = GetDiagonalsForRow(i, word.Length, true).ToList();
                var downAndLeftDiagonals = GetDiagonalsForRow(i, word.Length, false).ToList();
                for (int j = 0; j < downAndLeftDiagonals.Count; j++)
                {
                    string reversedWord = new(word.Reverse().ToArray());
                    if ((downAndLeftDiagonals[j] == word || downAndLeftDiagonals[j] == reversedWord) &&
                        (downAndRightDiagonals[j] == word || downAndRightDiagonals[j] == reversedWord))
                        rowCount++;
                }
                diagonalOccurences += rowCount;
            }


            return diagonalOccurences;
        } 

        private IEnumerable<string> GetColumns()
        {
            return Transpose(letterDistribution);
        }

        private List<string> GetDiagonals(int length)
        {
            var rowsIndexesWithDiagonals = Enumerable.Range(0, letterDistribution.Length - length + 1);
            var downAndRightDiagonals = rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, length, true)).ToList();
            var downAndLeftDiagonals = rowsIndexesWithDiagonals.SelectMany(row => GetDiagonalsForRow(row, length, false)).ToList();

            downAndRightDiagonals.AddRange(downAndLeftDiagonals);
            return downAndRightDiagonals;
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
