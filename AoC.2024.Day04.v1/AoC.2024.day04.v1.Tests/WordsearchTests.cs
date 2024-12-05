using FluentAssertions;

namespace AoC._2024.day04.v1.Tests
{
    public class WordsearchTests
    {
        private readonly string[] wordsearchInput =
        {
            "FOORAB",
            "ABCDCB",
            "ABCDCB",
            "XYZXYZ"
        };

        private readonly string[] x_masInput =
        {
            "SASASMSSSMSMSMSMSSMSAMXMAMAMXSXXXMAMMXSAMXMXMXSMMMXXXSXXAXSMMMAMXAXSMSSXXMSASASMXSSMSMSXMMMAMMMXXSAMXSSMXAXSASMMMXMASAXSXMXMAMXAMXXMAXXAMAMX",
            "AASAXAAAAXXASASMXSAXAMXXSMSSMSAXSMSMMASAMAAXMAMAAAMMMMMSMXSAMXSSMSMXMAXMASXAXAMXAAXMAMXAMASAMAAMXMASAMAAMSMSASASMMMMAMSXSMASMMSMSMMASMMMSAMA",
            "MXMXMMMSMMMMMAMXAMXMSSSMAXAAXMAMAAAXMASASMSXMASMMXSAAAAAMAXAMAXAAXAAMXMAMXMSMSMMXMASMSMXSASAXXXSASXMASXMMXAMMMAMMAXMXMMAXXAMAAAAAAMAMAAXSAMA"
        };

        /*
         * 3 letter match examples
         * x FOO 1 forwards
         * x BAR 1 backwards
         * x FAA 1 downwards
         * x BBO 1 upwards
         * x XYZ 2 on same row
         * x FBC, OBA, ZBA, ZDC 1 diagonal
         * x BCDC 2 forwards, 2 backwards
         * x BCD 2 forwards, 2 backwards, 1 diagonal
         * 
         *  M.S     M.M     S.M     S.S
         *  .A.     .A.     .A.     .A.
         *  M.S     S.S     S.M     M.M
         */

        // Looking for a 3x3 block with exactly two MAS diagonals

        private readonly WordSearch _wordSearch;
        public WordsearchTests()
        {
            _wordSearch = new WordSearch(wordsearchInput);
        }

        [Fact]
        public void ForwardWordCanBeFoundInARow()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("FOO");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void BackwardWordCanBeFoundInARow()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("BAR");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void ForwardWordCanBeFoundInDifferentRows()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("ABC");

            occurrences.Should().Be(2);
        }

        [Fact]
        public void ForwardWordCanBeFoundInSameRowMoreThanOnce()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("XYZ");

            occurrences.Should().Be(2);
        }

        [Fact]
        public void WordCanBeFoundForwardsAndBackwards()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("BCDC");

            occurrences.Should().Be(4);
        }

        [Fact]
        public void DownwardWordCanBeFoundInAColumn()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("FAA");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void UpwardWordCanBeFoundInAColumn()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("BBO");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void DiagonalDownAndRightWordCanBeFound()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("FBC");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void DiagonalUpAndLeftWordCanBeFound()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("ZBA");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void DiagonalDownAndLeftWordCanBeFound()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("OBA");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void DiagonalUpAndRightWordCanBeFound()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("ZDC");

            occurrences.Should().Be(1);
        }

        [Fact]
        public void WordInManyDifferentDirectionsCanBeFound()
        {
            var occurrences = _wordSearch.FindOccurrencesOf("BCD");

            occurrences.Should().Be(5);
        }

        [Fact]
        public void FirstLinesOfInputFindsMASInAnXShape()
        {
            var wordSearch = new WordSearch(x_masInput);

            var occurences = wordSearch.FindXShapeOccurrencesOf("MAS");

            occurences.Should().Be(21);
        }
    }
}
