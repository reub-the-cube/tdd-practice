using FluentAssertions;

namespace AoC._2024.day06.v1.Tests
{
    public class LabTests
    {
        private readonly Lab Lab;

        public LabTests()
        {
            Lab = MakeTestLab();
        }

        public class CanMoveTo : LabTests
        {
            [Fact]
            public void ReturnsFalseWhenOutOfBoundsInYDirection()
            {
                var canMoveThisHigh = Lab.CanMoveTo(new(0, 10));
                canMoveThisHigh.Should().Be(false);

                var canMoveThisLow = Lab.CanMoveTo(new(0, -1));
                canMoveThisLow.Should().Be(false);
            }

            [Fact]
            public void ReturnsTrueWhenInBoundsAndNotBlocked()
            {
                var result = Lab.CanMoveTo(new(1, 1));

                result.Should().Be(true);
            }

            [Fact]
            public void ReturnsFalseWhenOutOfBoundsInXDirection()
            {
                var canMoveThisFarLeft = Lab.CanMoveTo(new(-1, 0));
                canMoveThisFarLeft.Should().Be(false);

                var canMoveThisFarRight = Lab.CanMoveTo(new(0, 10));
                canMoveThisFarRight.Should().Be(false);
            }

        }

        public class PossibleLoops : LabTests
        {
            [Fact]
            public void ReturnsSixLoopsIfThereWereAnotherObstruction()
            {
                var possibleLoops = Lab.PossibleLoopsWithAdditionalObstacle(new Position(4, 3), Direction.Up);

                possibleLoops.Should().Be(6);
            }
        }

        public class MakeLab
        {
            [Fact]
            public void CanMakeLabFromExampleData()
            {
                var exampleData = File.ReadAllLines("example.txt");

                var lab = Lab.InitialiseFrom(exampleData);

                lab.IsBlocked(new Position(1, 3)).Should().Be(true);
            }
        }

        internal static Lab MakeTestLab()
        {
            /*
                  9 ....#.....
                  8 .........#
                  7 ..........
                  6 ..#.......
                  5 .......#..
                  4 ..........
                  3 .#........
                  2 ........#.
                  1 #.........
                  0 ......#...
                    0123456789
             */
            var obstactles = new List<Position>
            {
                new(0, 1), new(1, 3), new(2,6), new(4,9), new(6, 0), new(7, 5), new(8,2), new(9,8)
            };

            return new Lab(new(9, 9), obstactles);
        }

        internal static Lab MakeTestLoopLab()
        {
            /*
                  9 ....#.....
                  8 .........#
                  7 ..........
                  6 ..#.......
                  5 .......#..
                  4 ..........
                  3 .#.O......
                  2 ........#.
                  1 #.........
                  0 ......#...
                    0123456789
             */
            var obstactles = new List<Position>
            {
                new(0, 1), new(1, 3), new(2,6), new(3, 3), new(4,9), new(6, 0), new(7, 5), new(8,2), new(9,8)
            };

            return new Lab(new(9, 9), obstactles);
        }
    }
}
