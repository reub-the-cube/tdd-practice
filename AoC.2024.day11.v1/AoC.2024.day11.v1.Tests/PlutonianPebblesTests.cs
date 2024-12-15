using FluentAssertions;

namespace AoC._2024.day11.v1.Tests
{
    public class PlutonianPebblesTests
    {
        [Fact]
        public void ReturnsNumberOfStonesAfterASingleBlink()
        {
            var plutonianPebbles = new PlutonianPebbles("0 1 10 99 999");

            plutonianPebbles.Observe(1);

            plutonianPebbles.NumberOfStones.Should().Be(7);
        }
    }
}
