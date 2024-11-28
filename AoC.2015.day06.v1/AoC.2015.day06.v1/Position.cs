namespace AoC._2015.day06.v1;

public record Position(int X, int Y)
{
    public static IEnumerable<Position> GetPositionsBetween(Position here, Position there)
    {
        yield return here;
    }
}