namespace AoC._2024.day10.v1;

public class Position(int X, int Y, int Height)
{
    internal int Height { get; set; } = Height;

    public IEnumerable<Position> Next(Map map)
    {
        // left / west
        if (X - 1 > -1 && map.PositionAt(X - 1, Y).Height == Height + 1)
        {
            yield return map.PositionAt(X - 1, Y);
        }

        // right / east
        if (X + 1 < map.Width && map.PositionAt(X + 1, Y).Height == Height + 1)
        {
            yield return map.PositionAt(X + 1, Y);
        }

        // up / north
        if (Y + 1 < map.Height && map.PositionAt(X, Y + 1).Height == Height + 1)
        {
            yield return map.PositionAt(X, Y + 1);
        }

        // down / south
        if (Y - 1 > -1 && map.PositionAt(X, Y - 1).Height == Height + 1)
        {
            yield return map.PositionAt(X, Y - 1);
        }
    }

    public int Score(Map map)
    {
        return map.ScoreFrom(this);
    }
}
