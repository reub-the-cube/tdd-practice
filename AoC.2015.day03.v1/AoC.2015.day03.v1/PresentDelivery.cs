namespace AoC._2015.day03.v1;

public class PresentDelivery
{
    private readonly DeliveryTracker deliveryTracker = new();
    private readonly List<Santa> santas = [];

    public PresentDelivery(int numberOfSantas)
    {
        for (int i = 0; i < numberOfSantas; i++)
        {
            santas.Add(new Santa());
        }
    }

    public void OnReceivingInstructions(string instructions)
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            var santaIndex = i % santas.Count;
            TrackNewLocation(santas[santaIndex].Move(instructions[i]));
        }
    }

    public int HousesDeliveredTo()
    {
        return deliveryTracker.VisitedHousesWithDeliveries(1).Count();
    }

    private void TrackNewLocation(Location location)
    {
        deliveryTracker.DeliverPresent(location);
    }
}