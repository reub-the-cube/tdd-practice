namespace GossipingBusDriver.Tests;

using FluentAssertions;

public class DriverTests
{
    private const string _route_with_four_stops = "1 2 3 4";
    private readonly Gossip _gossipOne = new();
    private readonly Gossip _gossipTwo = new();
    private readonly Gossip _gossipThree = new();

    [Fact]
    public void DriverStartsAtTheFirstStop()
    {
        var driver = new Driver(_route_with_four_stops);

        driver.CurrentlyStoppedAt().Should().Be("1");
    }

    [Fact]
    public void DriverCanMoveToTheNextStop()
    {
        var driver = new Driver(_route_with_four_stops);

        driver.MoveToNextStop();

        driver.CurrentlyStoppedAt().Should().Be("2");
    }

    [Fact]
    public void DriverCanMoveToTheNextStopAtTheEndOfTheRoute()
    {
        var driver = new Driver(_route_with_four_stops);

        driver.MoveToNextStop();
        driver.MoveToNextStop();
        driver.MoveToNextStop();
        driver.MoveToNextStop();

        driver.CurrentlyStoppedAt().Should().Be("1");
    }

    [Fact]
    public void DriverKnowsOwnGossip()
    {
        var driver = new Driver("", _gossipOne);

        driver.KnowsGossips(_gossipOne).Should().Be(true);
    }

    [Fact]
    public void DriverDoesNotKnowAnotherGossip()
    {
        var driver = new Driver("", _gossipOne);

        driver.KnowsGossips(_gossipTwo).Should().Be(false);
    }

    [Fact]
    public void DriverCanExchangeGossipWithAnotherDriver()
    {
        var driverOne = new Driver("1", _gossipOne);
        var driverTwo = new Driver("1", _gossipTwo);

        driverOne.GossipWith(driverTwo);

        driverOne.KnowsGossips(_gossipTwo).Should().Be(true);
        driverTwo.KnowsGossips(_gossipOne).Should().Be(true);
    }

    [Fact]
    public void DriversCannotExchangeGossipIfTheyAreAtDifferentStops()
    {
        var driverOne = new Driver("1", _gossipOne);
        var driverTwo = new Driver("2", _gossipTwo);

        driverOne.GossipWith(driverTwo);

        driverOne.KnowsGossips(_gossipTwo).Should().Be(false);
        driverTwo.KnowsGossips(_gossipOne).Should().Be(false);
    }

    [Fact]
    public void DriverCanExchangeMultiplePiecesOfGossip()
    {
        var driverOne = new Driver("1 3", _gossipOne);
        var driverTwo = new Driver("1", _gossipTwo);
        var driverThree = new Driver("3", _gossipThree);

        driverOne.GossipWith(driverTwo);
        driverOne.MoveToNextStop();
        driverOne.GossipWith(driverThree);

        driverThree.KnowsGossips(_gossipOne, _gossipTwo).Should().Be(true);
        driverOne.KnowsGossips(_gossipThree).Should().Be(true);

        var driverFour = new Driver("3");
        driverFour.GossipWith(driverThree);

        driverFour.KnowsGossips(_gossipOne, _gossipTwo, _gossipThree).Should().Be(true);
    }
}