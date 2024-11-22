namespace GossipingBusDriver;

public class Driver
{
    private string _currentStop;
    private Queue<string> _stopOrder = new();
    private HashSet<Gossip> _knownGossip = new();

    public Driver(string route)
    {
        SetupRoute(route);
        MoveToNextStop();
    }

    public Driver(string route, Gossip gossip)
    {
        SetupRoute(route);
        _knownGossip.Add(gossip);
        MoveToNextStop();
    }

    private void SetupRoute(string route)
    {
        var stops = route.Split(' ');
        foreach (var stop in stops)
        {
            _stopOrder.Enqueue(stop);
        }
    }

    public string CurrentlyStoppedAt()
    {
        return _currentStop;
    }

    public void MoveToNextStop()
    {
        _currentStop = _stopOrder.Dequeue();
        _stopOrder.Enqueue(_currentStop);
    }

    public void GossipWith(Driver otherDriver)
    {
        if (_currentStop == otherDriver._currentStop)
        {
            _knownGossip.UnionWith(otherDriver._knownGossip);
            otherDriver._knownGossip.UnionWith(_knownGossip);
        }
    }

    public bool KnowsGossips(params Gossip[] gossips)
    {
        return gossips.All(_knownGossip.Contains);
    }
}