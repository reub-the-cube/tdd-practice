using FluentAssertions;
using System.Drawing;

namespace AoC._2024.day08.v1.Tests
{
    public class AntinodeMapTests
    {
        public class IsInBounds
        {
            private readonly AntinodeMap _map;

            public IsInBounds()
            {
                _map = new AntinodeMap(new Point(5,3));
            }

            [Fact]
            public void ReturnsTrueForKernalPoint()
            {
                var isInBounds = _map.IsInBounds(new Point(0, 0));

                isInBounds.Should().BeTrue();
            }

            [Theory]
            [InlineData(-1, 3)]
            [InlineData(6, 2)]
            [InlineData(5, -1)]
            [InlineData(5, 4)]
            public void ReturnsFalseForPastEdges(int x, int y)
            {
                var point = new Point(x, y);
                var isInBounds = _map.IsInBounds(point);

                isInBounds.Should().BeFalse();
            }
        }

        public class AddAntenna
        {
            [Fact]
            public void ReturnOneKnownPointWhenNoOtherAttennaOnTheFrequency()
            {
                var map = new AntinodeMap(new Point(5, 3));

                map.AddAntenna(new Antenna('A', new Point(1, 3)));

                map.NumberOfDistinctLoggedPoints().Should().Be(0);
            }

            [Fact]
            public void ReturnFourKnownPointsWhenOneOtherAttennaOnTheFrequency()
            {
                var map = new AntinodeMap(new Point(5, 3));

                map.AddAntenna(new Antenna('A', new Point(1, 3)));
                map.AddAntenna(new Antenna('A', new Point(2, 3)));

                map.NumberOfDistinctLoggedPoints().Should().Be(2);
            }

            [Fact]
            public void ReturnThreeKnownPointsWhenOneOtherAttennaOnTheFrequencyButAAntinodeIsOutOfBounds()
            {
                var map = new AntinodeMap(new Point(5, 3));

                map.AddAntenna(new Antenna('A', new Point(1, 3)));
                map.AddAntenna(new Antenna('A', new Point(3, 3)));

                map.NumberOfDistinctLoggedPoints().Should().Be(1);
            }

            [Fact]
            public void ReturnsDistinctPointsIfAnAntennaOverlapsWithAnAntinode()
            {
                var map = new AntinodeMap(new Point(3, 3));

                map.AddAntenna(new Antenna('A', new Point(1, 1)));
                map.AddAntenna(new Antenna('A', new Point(2, 2)));
                map.AddAntenna(new Antenna('B', new Point(3, 3)));

                map.NumberOfDistinctLoggedPoints().Should().Be(2);
            }
        }
    }
}
