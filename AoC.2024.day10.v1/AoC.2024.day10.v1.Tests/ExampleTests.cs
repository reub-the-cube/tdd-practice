using FluentAssertions;

namespace AoC._2024.day10.v1.Tests
{
    public class ExampleTests
    {
        [Fact]
        public void ReturnsAScoreOfOneForTheFirstExampleWhenProvidingTheStartPosition()
        {
            var map = new Map(Doubles.ExampleOneInput);
            var startPosition = new Position(0, 3, 0);
            var score = map.ScoreFrom(startPosition);

            score.Should().Be(1);
        }

        [Fact]
        public void ReturnsAScoreOfTwoForTheSecondExampleWhenProvidingTheStartPosition()
        {
            var map = new Map(Doubles.ExampleTwoInput);
            var startPosition = new Position(3, 6, 0);
            var score = map.ScoreFrom(startPosition);

            score.Should().Be(2);
        }

        [Fact]
        public void ReturnsAScoreOfTwoForTheThirdExample()
        {
            var map = new Map(Doubles.ExampleThreeInput);
            var score = map.ScoreFromTrailheads();

            score.Should().Be(36);
        }
    }
}
