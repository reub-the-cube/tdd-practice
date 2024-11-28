namespace AoC._2015.day06.v1;

public record Position(int X, int Y)
{
    public static HashSet<Position> GetPositionsBetween(Position here, Position there)
    {
        var positions = new HashSet<Position>();

        for (int y = here.Y; y < there.Y + 1; y++)
        {
            positions.Add(new Position(here.X, y));
        }

        return positions;
    }
}