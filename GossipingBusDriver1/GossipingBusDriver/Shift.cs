using System.Runtime.CompilerServices;

namespace GossipingBusDriver;

public class Shift
{
    private const int MAX_NUMBER_OF_STOPS_IN_A_DAY = 480; // for 480 minutes

    private bool _allGossipIsNotYetKnown = true;
    private GossipHub _gossipHub = new();
    private List<Driver> _drivers = new();
    private HashSet<Gossip> _gossips = new();
    private int _numberOfStopsForAllGossipToBeExchanged = 0;

    public void AddRoute(string route)
    {
        var gossip = new Gossip();
        _drivers.Add(new Driver(route, gossip));
        _gossips.Add(gossip);
    }

    public string NumberOfStopsToKnowAllGossip()
    {
        Simulate();

        return GetNumberOfStopsBeforeAllGossipWasKnown();
    }

    private void CheckIfAllGossipIsKnown()
    {
        _allGossipIsNotYetKnown = false;

        foreach (var driver in _drivers)
        {
            if (!driver.KnowsGossips(_gossips.ToArray()))
            {
                _allGossipIsNotYetKnown = true;
                break;
            }
        }
    }

    private void ExchangeGossip()
    {
        foreach (var driver in _drivers)
        {
            foreach (var otherDriver in _drivers)
            {
                driver.GossipWith(otherDriver);
            }
        }
    }

    private string GetNumberOfStopsBeforeAllGossipWasKnown()
    {
        if (_allGossipIsNotYetKnown)
        {
            return "never";
        }

        return (_numberOfStopsForAllGossipToBeExchanged + 1).ToString();
    }

    private void MoveToNextStop()
    {
        _drivers.ForEach(d => d.MoveToNextStop());
        _numberOfStopsForAllGossipToBeExchanged += 1;
    }

    private void Simulate()
    {
        while (_allGossipIsNotYetKnown && _numberOfStopsForAllGossipToBeExchanged < MAX_NUMBER_OF_STOPS_IN_A_DAY)
        {
            ExchangeGossip();
            CheckIfAllGossipIsKnown();

            if (_allGossipIsNotYetKnown)
            {
                MoveToNextStop();
            }
        }
    }
}