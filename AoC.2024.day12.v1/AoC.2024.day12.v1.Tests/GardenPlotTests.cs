using FluentAssertions;

namespace AoC._2024.day12.v1.Tests;

public class GardenPlotTests
{
    private readonly GardenPlot _plotUnderTest;

    public GardenPlotTests()
    {
        _plotUnderTest = new GardenPlot('A');    
    }

    public class NumberOfNeighbouringPlotsWithADifferentPlant : GardenPlotTests
    {
        [Fact]
        public void ReturnsZeroIfAllNeighboursHaveTheSamePlant()
        {
            var numberOfNeighbouringPlotsWithADifferentPlant = _plotUnderTest.NumberOfNeighbouringPlotsWithADifferentPlant([new GardenPlot('A'), new GardenPlot('A')]);

            numberOfNeighbouringPlotsWithADifferentPlant.Should().Be(0); 
        }

        [Fact]
        public void ReturnsOneIfASingleNeighbourHasADifferentPlant()
        {
            var numberOfNeighbouringPlotsWithADifferentPlant = _plotUnderTest.NumberOfNeighbouringPlotsWithADifferentPlant([new GardenPlot('A'), new GardenPlot('B')]);

            numberOfNeighbouringPlotsWithADifferentPlant.Should().Be(1);
        }

        [Fact]
        public void ReturnsTwoIfTwoNeighbourHaveTheSameDifferentPlant()
        {
            var numberOfNeighbouringPlotsWithADifferentPlant = _plotUnderTest.NumberOfNeighbouringPlotsWithADifferentPlant([new GardenPlot('B'), new GardenPlot('B')]);

            numberOfNeighbouringPlotsWithADifferentPlant.Should().Be(2);
        }
    }

    public class UniquePlants : GardenPlotTests
    {
        [Fact]
        public void ReturnsCorrectPlantsWhenOnlyOnePlantIsGiven()
        {
            var uniquePlants = GardenPlot.UniquePlants([_plotUnderTest]);

            uniquePlants.Should().BeEquivalentTo(['A']);
        }

        [Fact]
        public void ReturnsCorrentPlantsWhenTwoDifferentPlantsAreGiven()
        {
            var uniquePlants = GardenPlot.UniquePlants([_plotUnderTest, new GardenPlot('B'), new GardenPlot('B'), new GardenPlot('A')]);

            uniquePlants.Should().BeEquivalentTo(['A', 'B']);
        }
    }

    public class CountPlotsByPlantType : GardenPlotTests
    {
        [Fact]
        public void ReturnsZeroForAPlantThatDoesNotExist()
        {
            var numberOfPlots = GardenPlot.CountPlotsByPlantType([_plotUnderTest], 'B');

            numberOfPlots.Should().Be(0);
        }

        [Fact]
        public void ReturnsOneForAPlantThatHasOneEntry()
        {
            var numberOfPlots = GardenPlot.CountPlotsByPlantType([_plotUnderTest], 'A');

            numberOfPlots.Should().Be(1);
        }

        [Fact]
        public void ReturnsRwoForAPlantThatHasTwoEntries()
        {
            var numberOfPlots = GardenPlot.CountPlotsByPlantType([_plotUnderTest, new GardenPlot('A')], 'A');

            numberOfPlots.Should().Be(2);
        }
    }
}