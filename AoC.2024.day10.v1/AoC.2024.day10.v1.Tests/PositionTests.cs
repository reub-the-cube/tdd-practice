using FluentAssertions;

namespace AoC._2024.day10.v1.Tests;

public class PositionTests
{
    public class RoutesFrom
    {
        [Fact]
        public void ANinePositionHasAScoreOfOne()
        {
            var map = Doubles.TestMap;
            var position = new Position(0, 0, 9);

            var positionScore = position.Score(map);

            positionScore.Should().Be(1);
        }
    }

    public class Next
    {
        [Fact]
        public void ReturnsEmptyListWhenNothingValid()
        {
            var map = Doubles.TestMap;
            var position = new Position(0, 0, 9);

            var nextPositions = position.Next(map);

            nextPositions.Should().BeEmpty();
        }

        [Fact]
        public void ReturnsPositionLeftWhenValid()
        {
            var map = Doubles.TestMap;
            var position = new Position(1, 0, 8);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(0, 0));
        }

        [Fact]
        public void ReturnsPositionRightWhenValid()
        {
            var map = Doubles.TestMap;
            var position = new Position(1, 0, 8);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(2, 0));
        }

        [Fact]
        public void ReturnsPositionUpWhenValid()
        {
            var map = Doubles.TestMap;
            var position = new Position(0, 0, 0);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(0, 1));
        }
    }
}