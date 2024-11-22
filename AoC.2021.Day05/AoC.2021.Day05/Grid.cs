using System.Drawing;

namespace AoC._2021.Day05;

public class Grid
{
    private int pointsCovered = 0;

    public void DrawVerticalLine(Point from, Point to)
    {
        pointsCovered = 1;
    }

    public int NumberOfPointsThatHaveBeenCovered()
    {
        return pointsCovered;
    }
}
