using FluentAssertions;

namespace AoC._2015.day06.v1.Tests;

public class PositionTests
{
    [Fact]
    public void GetPositionsBetweenTheSameStartAndEndPositionIsASinglePosition()
    {
        var here = new Position(1, 1);
        var there = here;

        var positions = Position.GetPositionsBetween(here, there);

        positions.Should().HaveCount(1);
    }

    [Fact]
    public void GetPositionsBetweenTwoPositionsOnTheSameRowIncludesEveryPositionBetweenAndInclusive()
    {
        var here = new Position(1, 1);
        var there = new Position(1, 10);

        var positions = Position.GetPositionsBetween(here, there);

        positions.Should().HaveCount(10);
        positions.Should().Contain(here);
        positions.Should().Contain(there);
    }
}