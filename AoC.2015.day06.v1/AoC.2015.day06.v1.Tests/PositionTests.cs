using FluentAssertions;

namespace AoC._2015.day06.v1.Tests;

public class PositionTests
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    public void GetPositionsBetweenThrowsExceptionIfFromPositionIsNotBottomLeft(int thereX, int thereY)
    {
        var here = new Position(1, 1);
        var there = new Position(thereX, thereY);

        HashSet<Position> positions() => Position.GetPositionsBetween(here, there);

        Assert.Throws<ArgumentException>((Func<HashSet<Position>>)positions);
    }

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

    [Fact]
    public void GetPositionsBetweenTwoPositionsOnTheSameColumnIncludesEveryPositionBetweenAndInclusive()
    {
        var here = new Position(1, 1);
        var there = new Position(10, 1);

        var positions = Position.GetPositionsBetween(here, there);

        positions.Should().HaveCount(10);
        positions.Should().Contain(here);
        positions.Should().Contain(there);
    }

    [Fact]
    public void GetPositionsBetweenTwoPositionsOnSquareIncludesAllFourCorners()
    {
        var here = new Position(1, 1);
        var there = new Position(10, 10);

        var positions = Position.GetPositionsBetween(here, there);

        positions.Should().HaveCount(100);
        positions.Should().Contain(here);
        positions.Should().Contain(there);
        positions.Should().Contain(new Position(1, 10));
        positions.Should().Contain(new Position(10, 1));
    }
}