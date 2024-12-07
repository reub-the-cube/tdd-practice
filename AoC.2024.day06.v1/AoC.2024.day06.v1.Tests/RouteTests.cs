using FluentAssertions;

namespace AoC._2024.day06.v1.Tests
{
    public class RouteTests
    {
        [Fact]
        public void TryAddReturnsTrueIfThePositionAndDirectionDoesNotExist()
        {
            var route = new Route();

            var result = route.TryAdd(new(3, 4), Direction.Up);
            result.Should().BeTrue();

            result = route.TryAdd(new(3, 4), Direction.Right);
            result.Should().BeTrue();
        }

        [Fact]
        public void TryAddReturnsFalseIfThePositionAndDirectionHaveAlreadyBeenAdded()
        {
            var route = new Route();

            _ = route.TryAdd(new(3, 4), Direction.Up);
            bool result = route.TryAdd(new(3, 4), Direction.Up);

            result.Should().BeFalse();
        }

        [Fact]
        public void GoesThroughPositionReturnsTrueIfPositionIsOnTheRoute()
        {
            var route = new Route();

            _ = route.TryAdd(new(4, 3), Direction.Up);

            var result = route.GoesThrough(new(4, 3));

            result.Should().BeTrue();
        }

        [Fact]
        public void GoesThroughPositionReturnsFalseIfPositionIsNotOnTheRoute()
        {
            var route = new Route();

            var result = route.GoesThrough(new(4, 3));

            result.Should().BeFalse();
        }
    }
}
