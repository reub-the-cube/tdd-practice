using AoC._2024.day12.v1;
using System.Reflection.Metadata;

namespace AoC._2024.day12.v1
{
    public class PlotMap
    {
        private readonly Dictionary<char, List<(int row, int col)>> _plotLocationssByPlantType = [];
        private readonly List<Region> _regions = [];

        public PlotMap(string[] input)
        {
            input = input.Reverse().ToArray(); // Index 0 is actually row 0
            var rows = Enumerable.Range(0, input.Length).ToList();
            var columns = Enumerable.Range(0, input[0].Length).ToList();

            rows.ForEach(r => columns.ForEach(c => {
                _plotLocationssByPlantType.TryAdd(input[r][c], []);
                _plotLocationssByPlantType[input[r][c]].Add((r, c));
            }
            ));

            _regions = _plotLocationssByPlantType.SelectMany(CreateRegions).ToList();
        }

        public int TotalFencePrice()
        {
            return _regions.Sum(r => r.FencePriceFor());
        }

        public int FencePriceFor(char plantType)
        {
            return _regions.Where(r => r.ContainsPlantType(plantType)).Sum(r => r.FencePriceFor());
        }

        public int NumberOfRegions(char plantType)
        {
            return Region.CountByPlantType(plantType, _regions);
        }

        public int RegionAreaFor(char plantType)
        {
            return _regions.Where(r => r.ContainsPlantType(plantType)).Sum(r => r.AreaFor);
        }

        public int RegionPerimeterFor(char plantType)
        {
            return _regions.Where(r => r.ContainsPlantType(plantType)).Sum(r => r.PerimeterFor());
        }

        private IEnumerable<Region> CreateRegions(KeyValuePair<char, List<(int i, int j)>> plotLocationsByPlantType)
        {
            var plotLocationRegions = Region.GetRegionsFromPlotLocations(plotLocationsByPlantType.Value);
            return plotLocationRegions.Select(r => new Region(plotLocationsByPlantType.Key, r)).ToList();
        }
    }
}
