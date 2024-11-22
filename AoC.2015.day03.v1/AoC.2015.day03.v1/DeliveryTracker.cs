namespace AoC._2015.day03.v1;

public class DeliveryTracker
{
    private readonly HashSet<House> VisitedHouses = [];

    public DeliveryTracker()
    {
        DeliverPresent(new Location(0, 0));
    }

    public void DeliverPresent(Location to)
    {
        var house = new House(to);
        VisitedHouses.Add(house);
        VisitedHouses.TryGetValue(house, out house);
        house?.Visit();
    }

    public IEnumerable<House> VisitedHousesWithDeliveries(int minimumNumberOfPresents)
    {
        return VisitedHouses.Where(h => h.VisitCount >= minimumNumberOfPresents);
    }
}