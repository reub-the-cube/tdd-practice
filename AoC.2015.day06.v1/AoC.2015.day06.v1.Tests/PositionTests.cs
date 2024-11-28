using FluentAssertions;

namespace AoC._2015.day06.v1.Tests;

public class PositionTests
{
    [Fact]
    public void GetPositionsBetweenReturnsOnePointForTheSamePoint()
    {
        var here = new Position(1, 1);
        var there = here;

        var positions = Position.GetPositionsBetween(here, there);

        positions.Should().HaveCount(1);
    }
}