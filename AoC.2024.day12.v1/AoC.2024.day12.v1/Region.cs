namespace AoC._2024.day12.v1
{
    public class Region(char plantType, List<(int i, int j)> plots)
    {
        private readonly char PlantType = plantType;

        public int AreaFor => plots.Count;

        public int FencePriceFor()
        {
            return AreaFor * PerimeterFor();
        }

        public bool ContainsPlantType(char plantType)
        {
            return PlantType == plantType;
        }

        public int PerimeterFor()
        {
            var perimeter = 0;

            foreach (var (i, j) in plots)
            {
                var neighbours = GetNeighbours(i, j);
                perimeter += neighbours.Count(n => !plots.Contains(n));
            }

            return perimeter;
        }

        public static int CountByPlantType(char plantType, List<Region> regions)
        {
            return regions.Count(r => r.PlantType == plantType);
        } 

        public static IEnumerable<List<(int i, int j)>> GetRegionsFromPlotLocations(List<(int i, int j)> plotLocations)
        {
            // All these plot locations are of the same plant type
            var remainingPlots = plotLocations.ToList();

            while (remainingPlots.Count != 0)
            {
                var connectedPlots = ConnectedPlotLocations(remainingPlots.First(), [remainingPlots.First()], plotLocations);
                yield return connectedPlots;

                remainingPlots = remainingPlots.Except(connectedPlots).ToList();
            }
        }

        private static List<(int i, int j)> ConnectedPlotLocations((int i, int j) startingLocation, List<(int i, int j)> visitedLocations, List<(int i, int j)> plotLocations)
        {
            while (true)
            {
                var neighbours = GetNeighbours(startingLocation.i, startingLocation.j);
                var viableNeighbours = neighbours.Where(n => plotLocations.Contains(n) && !visitedLocations.Contains(n)).ToList();
                visitedLocations.AddRange(viableNeighbours);

                if (viableNeighbours.Count == 0) break;
                //visitedLocations.AddRange(viableNeighbours.SelectMany(n => ConnectedPlots(n, visitedLocations, plotLocations)).ToList());
                viableNeighbours.ForEach(n => ConnectedPlotLocations(n, visitedLocations, plotLocations));

            }

            return visitedLocations;
        }

        private static List<(int i, int j)> GetNeighbours(int i, int j)
        {
            return [
                (i, j + 1),
                (i, j - 1),
                (i + 1, j),
                (i - 1, j)
            ];
        }
    }

}
