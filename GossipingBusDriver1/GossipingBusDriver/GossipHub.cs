using System.ComponentModel.DataAnnotations;

namespace GossipingBusDriver;

public class GossipHub
{
    private List<Driver> _drivers = new();
    private HashSet<Gossip> _gossips = new();

    public void Add()
    {
    }
}