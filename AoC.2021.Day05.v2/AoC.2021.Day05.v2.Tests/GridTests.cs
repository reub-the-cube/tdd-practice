using System.Drawing;
using FluentAssertions;

namespace AoC._2021.Day05.v2.Tests;

public class GridTests
{
    [Fact]
    public void NewGridHasNoOverlappingPoints()
    {
        var grid = new Grid();

        grid.NumberOfOverlappingPoints().Should().Be(0);
    }

    [Fact]
    public void GridWithOneLineHasNoOverlappingPoints()
    {
        var grid = new Grid();
        grid.DrawLine(From(0, 0), To(0, 1));

        grid.NumberOfOverlappingPoints().Should().Be(0);
    }

    [Fact]
    public void GridWithTwoLinesAndOverlappingEndPoint()
    {
        var grid = new Grid();
        grid.DrawLine(From(0, 0), To(0, 1));
        grid.DrawLine(From(0, 1), To(0, 2));

        grid.NumberOfOverlappingPoints().Should().Be(1);
    }

    [Fact]
    public void GridWithTwoLinesAndOverlappingEndPoints()
    {
        var grid = new Grid();
        grid.DrawLine(From(0, 0), To(0, 1));
        grid.DrawLine(From(0, 0), To(0, 2));

        grid.NumberOfOverlappingPoints().Should().Be(2);
    }


    private static Point From(int x, int y)
    {
        return new Point(x, y);
    }

    private static Point To(int x, int y)
    {
        return new Point(x, y);
    }
}

/*

Draw a line has no overlapping points
Draw second line with an overlapping point
Draw second line in other direction with overlapping point
Grid.DrawLine etc etc
Grid.NumberOfOverlappingPoints


OR...
Field.PlotPoints(List)
 


({} → nil) no code at all → code that employs nil
(nil → constant)
(constant → constant+) a simple constant to a more complex constant
(constant → scalar) replacing a constant with a variable or an argument
(statement → statements) adding more unconditional statements.
(unconditional → if) splitting the execution path
(scalar → array)
(array → container)
(statement → tail-recursion)
(if → while)
(statement → non-tail-recursion)
(expression → function) replacing an expression with a function or algorithm
(variable → assignment) replacing the value of a variable.
(case) adding a case (or else) to an existing switch or if

*/