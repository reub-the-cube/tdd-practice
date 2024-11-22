using FluentAssertions;

namespace AoC._2015.day03.v1.Tests;

public class DeliveryTrackerTests
{
    private DeliveryTracker DeliveryTracker { get; set; }

    public DeliveryTrackerTests()
    {
        DeliveryTracker = new DeliveryTracker();
    }

    public class VisitedHousesWithDeliveries : DeliveryTrackerTests
    {
        [Fact]
        public void Return_1_ForFirstVisitAndAMinimumOfOnePresent()
        {
            var visitedHouses = DeliveryTracker.VisitedHousesWithDeliveries(1);

            visitedHouses.Count().Should().Be(1);
        }

        [Fact]
        public void Return_2_ForOneDeliveryAndAMinimumOfOnePresent()
        {
            DeliveryTracker.DeliverPresent(new Location(0, 1));

            var visitedHouses = DeliveryTracker.VisitedHousesWithDeliveries(1);

            visitedHouses.Count().Should().Be(2);
        }

        [Fact]
        public void Return_2_ForRepeatingADeliveryAndAMinimumOfOnePresent()
        {
            DeliveryTracker.DeliverPresent(new Location(1, 0));
            DeliveryTracker.DeliverPresent(new Location(1, 0));
            var visitedHouses = DeliveryTracker.VisitedHousesWithDeliveries(1);

            visitedHouses.Count().Should().Be(2);
        }

        [Fact]
        public void Return_0_ForFirstVisitAndAMinimumOfTwoPresents()
        {
            var visitedHouses = DeliveryTracker.VisitedHousesWithDeliveries(2);

            visitedHouses.Count().Should().Be(0);
        }

        [Fact]
        public void Return_1_ForRepeatingADeliveryAndAMinimumOfTwoPresents()
        {
            DeliveryTracker.DeliverPresent(new Location(1, 0));
            DeliveryTracker.DeliverPresent(new Location(1, 0));

            var visitedHouses = DeliveryTracker.VisitedHousesWithDeliveries(2);

            visitedHouses.Count().Should().Be(1);
        }
    }
}