using FluentAssertions;
using System.Drawing;

namespace AoC._2024.day08.v1.Tests
{
    public class AntennaMapTests
    {
        public class AddAntenna
        {
            [Fact]
            public void MeansNumberOfLoggedPointsIsOneOnANewMap()
            {
                var map = new AntennaMap(new Point(0, 0));

                map.AddAntenna(new Antenna('a', new Point(0, 0)));

                map.NumberOfDistinctLoggedPoints().Should().Be(1);
            }
        }

        public class GenerateAntinodeMap
        {
            [Fact]
            public void ReturnsExpectedType()
            {
                var map = new AntennaMap(new Point(0,0));

                var antinodeMap = map.GenerateAntinodeMap();

                antinodeMap.Should().BeOfType<AntinodeMap>();
            }

            [Fact]
            public void ReturnsAMapWithExpectedNumberOfLoggedPointsForASimpleExample()
            {
                var map = new AntennaMap(new Point(4, 4));
                // ....             ##..
                // .A..     --\     .A..
                // .AA.     --/     #AA#
                // ....             .#.#
                map.AddAntenna(new Antenna('a', new Point(1, 1)));
                map.AddAntenna(new Antenna('a', new Point(1, 2)));
                map.AddAntenna(new Antenna('a', new Point(2, 1)));

                var antinodeMap = map.GenerateAntinodeMap();

                antinodeMap.NumberOfDistinctLoggedPoints().Should().Be(6);
            }
        }

        public class GenerateAntennaMap
        {
            [Fact]
            public void ReturnsExpectedType()
            {
                var map = AntennaMap.GenerateFromStringInput([]);

                map.Should().BeOfType<AntennaMap>();
            }

            [Fact]
            public void ReturnsAMapWithExpectedNumberOfLoggedPoints()
            {
                string[] stringInput = [
                    "..A.a",
                    "...A.",
                    "2.i.."
                    ];
                var map = AntennaMap.GenerateFromStringInput(stringInput);

                map.NumberOfDistinctLoggedPoints().Should().Be(5);
            }
        }
    }
}

// Possible an antenna map and an antinode mmp
// Both need new with bounds
// Both need add antenna