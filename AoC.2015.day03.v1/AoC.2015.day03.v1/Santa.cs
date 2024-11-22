namespace AoC._2015.day03.v1;

public class Santa
{
    private int X = 0;
    private int Y = 0;

    public Location Move(IEnumerable<char> directions)
    {
        if (directions.Any())
        {
            UpdateLocation(directions.First());
            Move(directions.Skip(1));
        }

        return new Location(X, Y);
    }

    public Location Move(char direction)
    {
        return Move([direction]);
    }

    private void UpdateLocation(char direction)
    {
        SetXLocation(direction);
        SetYLocation(direction);
    }

    private void SetXLocation(char direction)
    {
        if (direction == '>')
        {
            X += 1;
        }

        if (direction == '<')
        {
            X -= 1;
        }
    }

    private void SetYLocation(char direction)
    {
        if (direction == '^')
        {
            Y += 1;
        }

        if (direction == 'v')
        {
            Y -= 1;
        }
    }
}
