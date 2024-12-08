using FluentAssertions;

namespace AoC._2024.day08.v1.Tests
{
    public class InputTests
    {
        private readonly string[] _input = File.ReadAllLines("input.txt");

        [Fact]
        public void DistinctPointsLoggedReturnsXForPartOne()
        {
            var map = AntennaMap.GenerateAntinodeMapFromStringInput(_input);

            map.NumberOfDistinctLoggedPoints().Should().Be(396);

            // 406 too high
        }
    }
}
