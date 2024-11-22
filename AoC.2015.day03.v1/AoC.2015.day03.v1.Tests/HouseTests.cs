using FluentAssertions;

namespace AoC._2015.day03.v1.Tests;

public class HouseTests
{
    public class VisitCount
    {
        [Fact]
        public void Return_0_WhenHouseHasNotBeenVisited()
        {
            var house = new House(new Location(0, 0));

            house.VisitCount.Should().Be(0);
        }

        [Fact]
        public void Return_1_WhenHouseHasBeenVisited()
        {
            var house = new House(new Location(0, 0));

            house.Visit();

            house.VisitCount.Should().Be(1);
        }

        [Fact]
        public void Return_2_WhenHouseHasBeenVisitedTwice()
        {
            var house = new House(new Location(0, 0));

            house.Visit();
            house.Visit();

            house.VisitCount.Should().Be(2);
        }
    }

    public class EqualityBasedOnLocationTests
    {
        [Fact]
        public void AHashmapWithAHouseCanBeRetrievedWithALocation()
        {
            var hashset = new HashSet<House>
            {
                new(new Location(3, 4))
            };

            var houseFound = hashset.TryGetValue(new House(new Location(3, 4)), out _);

            houseFound.Should().Be(true);
        }

        [Fact]
        public void AHashmapWithTheSameHouseAddedTwiceReturnsOnce()
        {
            var hashset = new HashSet<House>
            {
                new(new Location(3, 4))
            };

            var houseFound = hashset.Add(new House(new Location(3, 4)));

            houseFound.Should().Be(false);
        }
    }
}