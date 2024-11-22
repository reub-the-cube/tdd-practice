namespace GossipingBusDriver.Tests;

using FluentAssertions;

public class ShiftTests
{
    [Fact]
    public void OneDriverOnShiftKnowsAllGossipAtFirstStop()
    {
        var shift = new Shift();

        shift.NumberOfStopsToKnowAllGossip().Should().Be(1.ToString());
    }

    [Fact]
    public void TwoDriversOnShiftKnowAllGossipAtSecondStop()
    {
        var shift = new Shift();
        shift.AddRoute("1 2");
        shift.AddRoute("3 2");

        shift.NumberOfStopsToKnowAllGossip().Should().Be(2.ToString());
    }

    [Fact]
    public void TwoDriversOnShiftKnowAllGossipAtThirdStop()
    {
        var shift = new Shift();
        shift.AddRoute("1 2 1");
        shift.AddRoute("3 4 1");

        shift.NumberOfStopsToKnowAllGossip().Should().Be(3.ToString());
    }

    [Fact]
    public void ThreeDriversOnShiftKnowAllGossipAtFifthStop()
    {
        var shift = new Shift();
        shift.AddRoute("3 1 2 3");
        shift.AddRoute("3 2 3 1");
        shift.AddRoute("4 2 3 4 5");

        shift.NumberOfStopsToKnowAllGossip().Should().Be(5.ToString());

        // Stop 1 - D1(3):1,2,_ D2(3):1,2,_ D3(4): _,_,3
        // Stop 2 - D1(1):1,2,_ D2(2):1,2,3 D3(2): 1,2,3
        // Stop 3 - D1(2):1,2,_ D2(3):1,2,3 D3(3): 1,2,3
        // Stop 4 - D1(3):1,2,_ D2(1):1,2,3 D3(4): 1,2,3
        // Stop 5 - D1(3):1,2,3 D2(3):1,2,3 D3(4): 1,2,3
    }

    [Fact]
    public void TwoDriversOnShiftThatAreNeverAtTheSameStopWorkAllDay() 
    {
        var shift = new Shift();
        shift.AddRoute("2 1 2");
        shift.AddRoute("5 2 8");

        shift.NumberOfStopsToKnowAllGossip().Should().Be("never");
    }
}
