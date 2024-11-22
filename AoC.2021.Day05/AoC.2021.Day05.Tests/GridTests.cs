using System.Drawing;
using FluentAssertions;

namespace AoC._2021.Day05.Tests;

public class GridTests
{
    [Fact]
    public void PointsOnTheGridWithoutALineReturnsZero()
    {
        var grid = new Grid();

        grid.NumberOfPointsThatHaveBeenCovered().Should().Be(0);
    }

    [Fact]
    public void PointsOnTheGridAfterALineReturnsOne()
    {
        var grid = new Grid();

        grid.DrawVerticalLine(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0));

        grid.NumberOfPointsThatHaveBeenCovered().Should().Be(1);
    }
}