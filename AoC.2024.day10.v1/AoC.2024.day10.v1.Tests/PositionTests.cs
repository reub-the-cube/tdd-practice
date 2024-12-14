using FluentAssertions;

namespace AoC._2024.day10.v1.Tests;

public class PositionTests
{
    public class Next
    {
        [Fact]
        public void ReturnsEmptyListWhenNothingValid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(0, 0, 9);

            var nextPositions = position.Next(map);

            nextPositions.Should().BeEmpty();
        }

        [Fact]
        public void ReturnsPositionLeftWhenValid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(1, 0, 8);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(0, 0));
        }

        [Fact]
        public void DoesNotReturnPositionLeftWhenInvalid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(1, 0, 7);

            var nextPositions = position.Next(map);

            nextPositions.Should().NotContain(map.PositionAt(0, 0));
        }

        [Fact]
        public void ReturnsPositionRightWhenValid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(1, 0, 8);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(2, 0));
        }

        [Fact]
        public void DoesNotReturnPositionRightWhenInvalid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(1, 0, 7);

            var nextPositions = position.Next(map);

            nextPositions.Should().NotContain(map.PositionAt(2, 0));
        }

        [Fact]
        public void ReturnsPositionUpWhenValid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(0, 0, 0);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(0, 1));
        }

        [Fact]
        public void DoesNotReturnPositionUpWhenInvalid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(0, 0, 1);

            var nextPositions = position.Next(map);

            nextPositions.Should().NotContain(map.PositionAt(0, 1));
        }

        [Fact]
        public void ReturnsPositionDownWhenValid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(0, 1, 8);

            var nextPositions = position.Next(map);

            nextPositions.Should().Contain(map.PositionAt(0, 0));
        }

        [Fact]
        public void DoesNotReturnPositionDownWhenInvalid()
        {
            var map = new Map(Doubles.TestMapInput);
            var position = new Position(0, 1, 7);

            var nextPositions = position.Next(map);

            nextPositions.Should().NotContain(map.PositionAt(0, 0));
        }
    }
}