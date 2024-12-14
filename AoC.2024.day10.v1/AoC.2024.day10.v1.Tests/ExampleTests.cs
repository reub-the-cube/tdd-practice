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

        [Fact]
        public void ReturnsARatingOfThreeForTheFourthExample()
        {
            var map = new Map(Doubles.ExampleFourInput);
            var rating = map.RatingFromTrailheads();

            rating.Should().Be(3);
        }

        [Fact]
        public void ReturnsARatingOfThirteenForTheFifthExample()
        {
            var map = new Map(Doubles.ExampleFiveInput);
            var rating = map.RatingFromTrailheads();

            rating.Should().Be(13);
        }

        [Fact]
        public void ReturnsARatingOf227ForTheSixthExample()
        {
            var map = new Map(Doubles.ExampleSixInput);
            var rating = map.RatingFromTrailheads();

            rating.Should().Be(227);
        }

        [Fact]
        public void ReturnsARatingOf81ForTheThirdExample()
        {
            var map = new Map(Doubles.ExampleThreeInput);
            var rating = map.RatingFromTrailheads();

            rating.Should().Be(81);
        }
    }
}
