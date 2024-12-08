using FluentAssertions;

namespace AoC._2024.day08.v1.Tests
{
    public class ExampleTests
    {
        private readonly string[] _input = File.ReadAllLines("example.txt");

        [Fact]
        public void DistincePointsLoggedReturnsXForPartOne()
        {
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input);

            map.NumberOfDistinctLoggedPoints().Should().Be(14);
        }
    }
}
