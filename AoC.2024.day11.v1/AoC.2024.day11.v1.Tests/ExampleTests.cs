using FluentAssertions;

namespace AoC._2024.day11.v1.Tests
{
    public class ExampleTests
    {
        [Theory]
        [InlineData(1, 2024)]
        [InlineData(10, 1)]
        [InlineData(10, 0)]
        [InlineData(99, 9)]
        [InlineData(999, 2021976)]
        public void InitialArrangementOfFiveStonesReturnsCorrectNewStones(int beforeBlinkStoneValue, int afterBlinkStoneValue)
        {
            var stoneBeforeBlink = new Stone(beforeBlinkStoneValue);
            var stoneAfterBlink = new Stone(afterBlinkStoneValue);

            var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

            stonesAfterBlink.Should().Contain(stoneAfterBlink);
        }

        [Theory]
        [InlineData(6, 22)]
        [InlineData(25, 55312)]
        public void InitialArrangementOfTwoStonesReturnsTotalNewStonesAfterBlinks(int numberOfBlinks, int expectedNumberOfStones)
        {
            var pebbles = new PlutonianPebbles("125 17");

            pebbles.Observe(numberOfBlinks);

            pebbles.NumberOfStones.Should().Be(expectedNumberOfStones);
        }
    }
}