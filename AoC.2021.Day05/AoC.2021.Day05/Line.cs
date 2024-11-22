using System.Drawing;

namespace AoC._2021.Day05;

public class Line
{
    private readonly List<Point> points = new();

    public Line(Point from, Point to)
    {
        if (from.X == to.X)
        {
            AddVerticalPoints(from.X, Math.Min(from.Y, to.Y), Math.Max(from.Y, to.Y));
        }

        if (from.Y == to.Y)
        {
            AddHorizontalPoints(from.Y, to.X, from.X);
        }
    }

    public bool Covers(Point point)
    {
        return points.Contains(point);
    }

    private void AddHorizontalPoints(int y, int fromX, int toX)
    {
        for (int x = fromX; x <= toX; x++)
        {
            points.Add(new Point(x, y));
        }
    }

    private void AddVerticalPoints(int x, int fromY, int toY)
    {
        for (int y = fromY; y <= toY; y++)
        {
            points.Add(new Point(x, y));
        }
    }
}