using FluentAssertions;

namespace AoC._2024.day08.v1.Tests
{
    public class ExampleTests
    {
        private readonly string[] _input = File.ReadAllLines("example.txt");

        [Fact]
        public void DistincePointsLoggedReturnsXForPartOne()
        {
            var addResonantHarmonics = false;
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input, addResonantHarmonics);

            map.NumberOfDistinctLoggedPoints().Should().Be(14);
        }

        [Fact]
        public void DistincePointsLoggedReturnsYForPartTwo()
        {
            var addResonantHarmonics = true;
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input, addResonantHarmonics);

            map.NumberOfDistinctLoggedPoints().Should().Be(34);
        }
    }
}
