namespace AoC._2015.day06.v1;

public record Position(int X, int Y)
{
    public static HashSet<Position> GetPositionsBetween(Position here, Position there)
    {
        if (here.X > there.X || here.Y > there.Y)
        {
            throw new ArgumentException("Should be bottom-left position", nameof(here));
        }

        IEnumerable<Position> positions = [];

        for (int x = here.X; x < there.X + 1; x++)
        {
            positions = positions.Union(GetColumnPositions(x, here.Y, there.Y));
        }

        return positions.ToHashSet();
    }

    private static IEnumerable<Position> GetColumnPositions(int x, int fromY, int toY)
    {
        for (int y = fromY; y < toY + 1; y++)
        {
            yield return new Position(x, y);
        }
    }
}