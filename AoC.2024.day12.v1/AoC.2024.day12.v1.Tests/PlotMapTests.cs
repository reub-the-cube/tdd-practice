using FluentAssertions;

namespace AoC._2024.day12.v1.Tests
{
    public class PlotMapTests
    {
        [Theory]
        [InlineData('A', 4)]
        [InlineData('B', 4)]
        [InlineData('C', 4)]
        [InlineData('D', 1)]
        [InlineData('E', 3)]
        public void RegionAreaReturnsTheNumberOfPlotsForThatPlantInExampleOne(char plantType, int expectedArea)
        {
            var plotMap = new PlotMap(MapInputs.ExampleOne);

            var regionArea = plotMap.RegionAreaFor(plantType);

            regionArea.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData('X', 4)]
        [InlineData('O', 21)]
        public void RegionAreaReturnsTheNumberOfPlotsForThatPlantInExampleTwo(char plantType, int expectedArea)
        {
            var plotMap = new PlotMap(MapInputs.ExampleTwo);

            var regionArea = plotMap.RegionAreaFor(plantType);

            regionArea.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData('I', 18)]
        public void RegionAreaReturnsTheNumberOfPlotsForThatPlantInExampleThree(char plantType, int expectedArea)
        {
            var plotMap = new PlotMap(MapInputs.ExampleThree);

            var regionArea = plotMap.RegionAreaFor(plantType);

            regionArea.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData('A', 10)]
        [InlineData('B', 8)]
        [InlineData('C', 10)]
        [InlineData('D', 4)]
        [InlineData('E', 8)]
        public void RegionPerimeterReturnsTheNumberOfFencesRequiredForThatPlantInExampleOne(char plantType, int expectedPerimeter)
        {
            var plotMap = new PlotMap(MapInputs.ExampleOne);

            var regionPerimeter = plotMap.RegionPerimeterFor(plantType);

            regionPerimeter.Should().Be(expectedPerimeter);
        }

        [Theory]
        [InlineData('X', 16)]
        [InlineData('O', 36)]
        public void RegionPerimeterReturnsTheNumberOfFencesRequiredForThatPlantInExampleTwo(char plantType, int expectedPerimeter)
        {
            var plotMap = new PlotMap(MapInputs.ExampleTwo);

            var regionPerimeter = plotMap.RegionPerimeterFor(plantType);

            regionPerimeter.Should().Be(expectedPerimeter);
        }

        [Theory]
        [InlineData('I', 30)]
        public void RegionPerimeterReturnsTheNumberOfFencesRequiredForThatPlantInExampleThree(char plantType, int expectedPerimeter)
        {
            var plotMap = new PlotMap(MapInputs.ExampleThree);

            var regionPerimeter = plotMap.RegionPerimeterFor(plantType);

            regionPerimeter.Should().Be(expectedPerimeter);
        }

        [Theory]
        [InlineData('A', 40)]
        [InlineData('B', 32)]
        [InlineData('C', 40)]
        [InlineData('D', 4)]
        [InlineData('E', 24)]
        public void RegionFencePriceReturnsTheExpectedResultForExampleOne(char plantType, int expectedPrice)
        {
            var plotMap = new PlotMap(MapInputs.ExampleOne);

            var regionFencePrice = plotMap.FencePriceFor(plantType);

            regionFencePrice.Should().Be(expectedPrice);
        }

        [Theory]
        [InlineData('X', 16)]
        [InlineData('O', 756)]
        public void RegionFencePriceReturnsTheExpectedResultForExampleTwo(char plantType, int expectedPrice)
        {
            var plotMap = new PlotMap(MapInputs.ExampleTwo);

            var regionFencePrice = plotMap.FencePriceFor(plantType);

            regionFencePrice.Should().Be(expectedPrice);
        }

        [Theory]
        [InlineData('R', 216)]
        [InlineData('I', 340)]
        [InlineData('C', 396)]
        public void RegionFencePriceReturnsTheExpectedResultForExampleThree(char plantType, int expectedPrice)
        {
            var plotMap = new PlotMap(MapInputs.ExampleThree);

            var regionFencePrice = plotMap.FencePriceFor(plantType);

            regionFencePrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void TotalFencePriceReturnsTheExpectedResultForExampleOne()
        {
            var plotMap = new PlotMap(MapInputs.ExampleOne);

            var totalFencePrice = plotMap.TotalFencePrice();

            totalFencePrice.Should().Be(140);
        }

        [Fact]
        public void NumberOfRegionsCanBeTwoForAGivenPlant()
        {
            var plotMap = new PlotMap(MapInputs.TwoARegions);

            var numberOfRegions = plotMap.NumberOfRegions('A');

            numberOfRegions.Should().Be(2);
        }

        [Fact]
        public void NumberOfRegionsCanBeTwoForAnotherGivenPlant()
        {
            var plotMap = new PlotMap(MapInputs.ExampleThree);

            var numberOfRegions = plotMap.NumberOfRegions('I');

            numberOfRegions.Should().Be(2);
        }

        [Fact]
        public void NumberOfRegionsCanBeFiveForAGivenPlant()
        {
            var plotMap = new PlotMap(MapInputs.FiveARegions);

            var numberOfRegions = plotMap.NumberOfRegions('A');

            numberOfRegions.Should().Be(5);
        }

        [Fact]
        public void TotalFencePriceReturnsTheExpectedResultForExampleTwo()
        {
            var plotMap = new PlotMap(MapInputs.ExampleTwo);

            var totalFencePrice = plotMap.TotalFencePrice();

            totalFencePrice.Should().Be(772);
        }

        [Fact]
        public void TotalFencePriceReturnsTheExpectedResultForExampleThree()
        {
            var plotMap = new PlotMap(MapInputs.ExampleThree);

            var totalFencePrice = plotMap.TotalFencePrice();

            totalFencePrice.Should().Be(1930);
        }
    }

    internal static class MapInputs
    {
        internal static string[] ExampleOne = [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ];

        internal static string[] ExampleTwo = [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO"
        ];

        internal static string[] TwoARegions = [
            "ABA",
            "ABA"
        ];

        internal static string[] FiveARegions = [
            "ABABA",
            "BBABB",
            "AAAAA",
            "BBABB",
            "ABABA"
        ];

        internal static string[] ExampleThree = [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        ];
    }
}
