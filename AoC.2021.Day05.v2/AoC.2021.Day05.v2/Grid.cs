
using System.Drawing;

namespace AoC._2021.Day05.v2;
public class Grid
{
    public HashSet<Point> AllPoints = new();
    public HashSet<Point> OverlappingPoints = new();

    public void DrawLine(Point from, Point to)
    {
        for (int y = from.Y; y <= to.Y; y++)
        {
            DrawPoint(new Point(from.X, y));
        }
    }

    public int NumberOfOverlappingPoints()
    {
        return OverlappingPoints.Count;
    }

    private void DrawPoint(Point point)
    {
        if (AllPoints.Contains(point))
        {
            OverlappingPoints.Add(point);
            return;
        }

        AllPoints.Add(point);
    }
}
