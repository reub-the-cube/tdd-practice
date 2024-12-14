using FluentAssertions;

namespace AoC._2024.day11.v1.Tests
{
    public class SolutionTests
    {
        [Fact]
        public void InputDataReturnsXForPartOne()
        {
            var pebbles = new PlutonianPebbles("77 515 6779622 6 91370 959685 0 9861");

            pebbles.Observe(25);

            pebbles.NumberOfStones.Should().Be(187738);
        }
    }
}
