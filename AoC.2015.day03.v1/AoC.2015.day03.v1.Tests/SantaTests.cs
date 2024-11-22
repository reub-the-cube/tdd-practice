using FluentAssertions;

namespace AoC._2015.day03.v1.Tests;

public class SantaTests
{
    private Santa ThisSanta { get; set; }
    
    public SantaTests()
    {
        ThisSanta = new Santa();
    }

    public class Move : SantaTests
    {
        [Fact]
        public void Return_0_1_ForMoveNorth()
        {
            var currentLocation = ThisSanta.Move('^');

            currentLocation.Should().Be(new Location(0, 1));
        }

        [Fact]
        public void Return_0_2_ForTwoMovesNorth()
        {
            _ = ThisSanta.Move('^');
            var currentLocation = ThisSanta.Move('^');

            currentLocation.Should().Be(new Location(0, 2));
        }

        [Fact]
        public void Return_0_Minus1_ForMoveSouth()
        {
            var currentLocation = ThisSanta.Move('v');

            currentLocation.Should().Be(new Location(0, -1));
        }

        [Fact]
        public void Return_1_0_ForMoveEast()
        {
            var currentLocation = ThisSanta.Move('>');

            currentLocation.Should().Be(new Location(1, 0));
        }

        [Fact]
        public void Return_Minus1_0_ForMoveWest()
        {
            var currentLocation = ThisSanta.Move('<');

            currentLocation.Should().Be(new Location(-1, 0));
        }

        [Fact]
        public void Return_0_0_ForMovingInASquare()
        {
            _ = ThisSanta.Move('^');
            _ = ThisSanta.Move('>');
            _ = ThisSanta.Move('v');
            var currentLocation = ThisSanta.Move('<');

            currentLocation.Should().Be(new Location(0, 0));
        }

        [Fact]
        public void Return_0_2_ForTwoMovesEast()
        {
            var currentLocation = ThisSanta.Move(['>', '>']);

            currentLocation.Should().Be(new Location(2, 0));
        }
    }
}