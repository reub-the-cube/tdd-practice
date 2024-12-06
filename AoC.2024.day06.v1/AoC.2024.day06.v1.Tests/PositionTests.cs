using FluentAssertions;

namespace AoC._2024.day06.v1.Tests
{
    public class PositionTests
    {
        [Fact]
        public void NextPositionReturnsPositionAboveWhenDirectionIsUp()
        {
            var position = new Position(3, 4);

            var nextPosition = position.Next(Direction.Up);

            nextPosition.Should().Be(new Position(3, 5));
        }

        [Fact]
        public void NextPositionReturnsPositionRightWhenDirectionIsRight()
        {
            var position = new Position(3, 4);

            var nextPosition = position.Next(Direction.Right);

            nextPosition.Should().Be(new Position(4, 4));
        }

        [Fact]
        public void NextPositionReturnsPositionBelowWhenDirectionIsDown()
        {
            var position = new Position(3, 4);

            var nextPosition = position.Next(Direction.Down);

            nextPosition.Should().Be(new Position(3, 3));
        }

        [Fact]
        public void NextPositionReturnsPositionLeftWhenDirectionIsLeft()
        {
            var position = new Position(3, 4);

            var nextPosition = position.Next(Direction.Left);

            nextPosition.Should().Be(new Position(2, 4));
        }
    }
}
