using FluentAssertions;

namespace AoC._2024.day08.v1.Tests
{
    public class InputTests
    {
        private readonly string[] _input = File.ReadAllLines("input.txt");

        [Fact]
        public void DistinctPointsLoggedReturnsXForPartOne()
        {
            var addResonantHarmonics = false;
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input, addResonantHarmonics);

            map.NumberOfDistinctLoggedPoints().Should().Be(396);

            // 406 too high
        }

        [Fact]
        public void DistincePointsLoggedReturnsYForPartTwo()
        {
            var addResonantHarmonics = true;
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input, addResonantHarmonics);

            map.NumberOfDistinctLoggedPoints().Should().Be(1200);
        }
    }
}
