using System.Runtime.CompilerServices;

namespace AoC._2021.Day05.Tests;

public class Point
{
    private System.Drawing.Point point;
    private int coverCounter = 0;

    public Point(int x, int y)
    {
        point = new System.Drawing.Point(x, y);
    }

    public void Cover()
    {
        coverCounter += 1;
    }

    public int IsCoveredBy()
    {
        return coverCounter;
    }
}