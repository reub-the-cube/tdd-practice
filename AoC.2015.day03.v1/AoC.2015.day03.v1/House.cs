namespace AoC._2015.day03.v1;

public class House(Location location)
{
    public int VisitCount { get; private set; }
    private Location Location { get; init; } = location;

    public void Visit()
    {
        VisitCount += 1;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not House compareTo)
            return false;
        return Location.Equals(compareTo.Location);
    }

    public override int GetHashCode()
    {
        return Location.GetHashCode();
    }
}