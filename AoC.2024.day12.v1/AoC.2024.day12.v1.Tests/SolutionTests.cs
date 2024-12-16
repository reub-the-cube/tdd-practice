using FluentAssertions;

namespace AoC._2024.day12.v1.Tests
{
    public class SolutionTests
    {
        private readonly string[] inputData = File.ReadAllLines("input.txt");

        [Fact]
        public void InputDataCalculatesTheTotalFencePriceForPartOne()
        {
            var plotMap = new PlotMap(inputData);

            var totalFencePrice = plotMap.TotalFencePrice();

            totalFencePrice.Should().Be(1361494);
        }
    }
}
