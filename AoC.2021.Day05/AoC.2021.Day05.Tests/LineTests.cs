using Drawing = System.Drawing;
using FluentAssertions;

namespace AoC._2021.Day05.Tests;

public class LineTests
{
    [Fact]
    public void DrawingAVerticalLineCoversStartPoint()
    {
        var from = new Drawing.Point(0, 0);
        var line = new Line(from, from);

        line.Covers(new Drawing.Point(0, 0)).Should().Be(true);
    }

    [Fact]
    public void DrawingAVerticalLineDoesNotCoverAPointOffTheLine()
    {
        var from = new Drawing.Point(0, 0);
        var line = new Line(from, from);

        line.Covers(new Drawing.Point(0, 1)).Should().Be(false);
    }

    [Fact]
    public void DrawingAVerticalLineCoversEndPoint()
    {
        var from = new Drawing.Point(0, 0);
        var to = new Drawing.Point(0, 2);
        var line = new Line(from, to);

        line.Covers(new Drawing.Point(0, 2)).Should().Be(true);
    }

    [Fact]
    public void DrawingAVerticalLineCoversMiddlePoint()
    {
        var from = new Drawing.Point(1, 1);
        var to = new Drawing.Point(1, 3);
        var line = new Line(from, to);

        line.Covers(new Drawing.Point(1, 2)).Should().Be(true);
    }

    [Fact]
    public void DrawingAHorizontalLineCoversExpectedPoints()
    {
        var from = new Drawing.Point(9, 7);
        var to = new Drawing.Point(7, 7);
        var line = new Line(from, to);

        line.Covers(new Drawing.Point(9, 7)).Should().Be(true);
        line.Covers(new Drawing.Point(8, 7)).Should().Be(true);
        line.Covers(new Drawing.Point(7, 7)).Should().Be(true);
    }

        [Fact]
    public void DrawingAVerticalLineDownCoversExpectedPoints()
    {
        var from = new Drawing.Point(3, 6);
        var to = new Drawing.Point(3, 5);
        var line = new Line(from, to);

        line.Covers(new Drawing.Point(3, 6)).Should().Be(true);
        line.Covers(new Drawing.Point(3, 5)).Should().Be(true);
    }
}

// (v) Line 1,1 -> 1,3 covers 1,1 1,2 and 1,3
// (h) Line 9,7 -> 7,7 covers 9,7, 8,7 and 7,7