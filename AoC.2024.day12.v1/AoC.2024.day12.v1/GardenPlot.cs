namespace AoC._2024.day12.v1;

public class GardenPlot(char plantType)
{
    private readonly char PlantType = plantType;

    public int NumberOfNeighbouringPlotsWithADifferentPlant(IEnumerable<GardenPlot> neighbouringPlots)
    {
        return neighbouringPlots.Count(p => p.PlantType != PlantType);
    }

    public static int CountPlotsByPlantType(IEnumerable<GardenPlot> plots, char plantType)
    {
        return plots.Count(p => p.PlantType == plantType);
    }

    public static IEnumerable<GardenPlot> GetPlotsByPlantType(IEnumerable<GardenPlot> plots, char plantType)
    {
        return plots.Where(p => p.PlantType == plantType);
    }

    public bool IsInRegion(char plantType)
    {
        return PlantType == plantType;
    }


    public static IEnumerable<char> UniquePlants(IEnumerable<GardenPlot> plots)
    {
        return plots.Select(p => p.PlantType).Distinct();
    }
}