using FluentAssertions;
using System.Drawing;

namespace AoC._2024.day08.v1.Tests;

public class AntennaTests
{
    public const char KnownFrequency = 'a';
    public readonly Antenna AntennaUnderTest = new(KnownFrequency, new Point(1, 3));

    public class Constructor
    {
        [Fact]
        public void TakesArguments()
        {
            var point = new Point(1, 3);
            var antenna = new Antenna(KnownFrequency, point);

            antenna.Should().NotBeNull();
        }
    }

    public class GetAntinodes
    {
        [Fact]
        public void ReturnsEmptyListOfAntinodesWhenNoOtherAntennasAreProvided()
        {
            var frequency = 'a';
            var point = new Point(1, 3);
            var antenna = new Antenna(frequency, point);

            List<Antinode> antinodes = antenna.CreateAntinodes([]);

            antinodes.Should().HaveCount(0);
        }

        [Fact]
        public void ReturnsTwoAntinodesWhenAnAntennaOfTheSameFrequencyExists()
        {
            var frequency = 'a';
            var point = new Point(1, 3);
            var antenna = new Antenna(frequency, point);

            var antinodes = antenna.CreateAntinodes([ new Antenna('a', new Point(2, 3))]);

            antinodes.Should().HaveCount(2);
        }

        [Fact]
        public void ReturnsEmptyListWhenNoAntennaOfTheSameFrequencyExists()
        {
            var frequency = 'a';
            var point = new Point(1, 3);
            var antenna = new Antenna(frequency, point);

            var antinodes = antenna.CreateAntinodes([new Antenna('b', new Point(3, 3))]);

            antinodes.Should().HaveCount(0);
        }

        [Fact]
        public void ReturnsFourAntinodesWhenTwoAntennasOfTheSameFrequencyExist()
        {
            var frequency = 'a';
            var point = new Point(1, 3);
            var antenna = new Antenna(frequency, point);

            var antinodes = antenna.CreateAntinodes([new Antenna('a', new Point(2, 3)), new Antenna('a', new Point(4,3))]);

            antinodes.Should().HaveCount(4);
        }
    }

    public class CreateAntinodePair : AntennaTests
    {
        [Fact]
        public void ReturnsTwoAntinodesForHorizontallyAdjacentAntennas()
        {
            var secondAntenna = new Antenna(KnownFrequency, new Point(2, 3));

            var antinodes = AntennaUnderTest.CreateAntinodePair(secondAntenna);

            antinodes.Should().HaveCount(2);
        }

        [Fact]
        public void ReturnsCorrectAntinodesForHorizontallyAdjacentAntennas()
        {
            var secondAntenna = new Antenna(KnownFrequency, new Point(2, 3));

            var antinodes = AntennaUnderTest.CreateAntinodePair(secondAntenna);

            antinodes.Should().Contain(new Antinode(new Point(0, 3)));
            antinodes.Should().Contain(new Antinode(new Point(3, 3)));
        }

        [Fact]
        public void ReturnsCorrectAntinodesForVerticallyAdjacentAntennas()
        {
            var secondAntenna = new Antenna(KnownFrequency, new Point(1, 4));

            var antinodes = AntennaUnderTest.CreateAntinodePair(secondAntenna);

            antinodes.Should().Contain(new Antinode(new Point(1, 2)));
            antinodes.Should().Contain(new Antinode(new Point(1, 5)));
        }

        [Fact]
        public void ReturnsCorrectAntinodesForDiagonallyGappedAntennas()
        {
            var secondAntenna = new Antenna(KnownFrequency, new Point(4, 8));

            var antinodes = AntennaUnderTest.CreateAntinodePair(secondAntenna);

            antinodes.Should().Contain(new Antinode(new Point(-2, -2)));
            antinodes.Should().Contain(new Antinode(new Point(7, 13)));
        }
    }
}

/*
 * 
 * Add antenna to map
 * - Create antenna
 * - Create antinodes (from list)
 *      - Find other antenna of that frequency
 *      - For each, create a pair of antinodes
 * - Exclude invalid positions
 * - Add to map
 * 
 * - Throw exception if an antenna of the same point already exists
*/