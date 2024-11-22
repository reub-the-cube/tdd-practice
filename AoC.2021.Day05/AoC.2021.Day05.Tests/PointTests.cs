using FluentAssertions;

namespace AoC._2021.Day05.Tests;

public class PointTests
{
    [Fact]
    public void AnUncoveredPointReturnsZero()
    {
        var point = new Point(0, 0);

        point.IsCoveredBy().Should().Be(0);
    }

    [Fact]
    public void ACoveredPointReturnsOne()
    {
        var point = new Point(0, 0);

        point.Cover();

        point.IsCoveredBy().Should().Be(1);
    }

    [Fact]
    public void ACoveredPointReturnsTwo()
    {
        var point = new Point(0, 0);

        point.Cover();
        point.Cover();

        point.IsCoveredBy().Should().Be(2);
    }
}