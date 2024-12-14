using FluentAssertions;

namespace AoC._2024.day11.v1.Tests
{
    public class PlutonianPebblesTests
    {
        [Fact]
        public void ReturnsArrangementAfterInitialisation()
        {
            var initialArrangement = "0 1 2 3";
            var plutonianPebbles = new PlutonianPebbles(initialArrangement);

            plutonianPebbles.ToString().Should().Be(initialArrangement);
        }

        [Fact]
        public void ReturnsANewArrangementAfterASingleBlink()
        {
            var plutonianPebbles = new PlutonianPebbles("0 1 10 99 999");

            plutonianPebbles.Observe(1);

            plutonianPebbles.ToString().Should().Be("1 2024 1 0 9 9 2021976");
        }

        [Fact]
        public void ReturnsNumberOfStonesAfterASingleBlink()
        {
            var plutonianPebbles = new PlutonianPebbles("0 1 10 99 999");

            plutonianPebbles.Observe(1);

            plutonianPebbles.NumberOfStones.Should().Be(7);
        }

        [Fact]
        public void ReturnsANewArrangementAfterASixBlinks()
        {
            var plutonianPebbles = new PlutonianPebbles("125 17");

            plutonianPebbles.Observe(6);

            plutonianPebbles.ToString().Should().Be("2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2");
        }
    }
}
