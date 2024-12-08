using System.Drawing;

namespace AoC._2024.day08.v1
{
    public class AntennaMap(Point oppositeCorner)
    {
        private readonly List<Antenna> antennas = [];

        public void AddAntenna(Antenna antenna)
        {
            antennas.Add(antenna);
        }

        private bool AddAntenna(char frequency, Point point)
        {
            if (frequency == '.')
            {
                return false;
            }

            AddAntenna(new Antenna(frequency, point));
            return true;
        }

        public int NumberOfDistinctLoggedPoints()
        {
            return antennas.Count;
        }

        public AntinodeMap GenerateAntinodeMap()
        {
            var antinodeMap = new AntinodeMap(oppositeCorner);
            antennas.ForEach(antinodeMap.AddAntenna);
            return antinodeMap;
        }

        public static AntennaMap GenerateFromStringInput(string[] input)
        {
            var antennaMap = new AntennaMap(new Point(0, 0));
            if (input.Length == 0 || input[0].Length == 0) return antennaMap;

            antennaMap = new AntennaMap(new Point(input[0].Length - 1, input.Length - 1));
            var xIndexes = Enumerable.Range(0, input[0].Length).ToList();
            var yIndexes = Enumerable.Range(0, input.Length).ToList();

            xIndexes.ForEach(x => yIndexes.ForEach(y => antennaMap.AddAntenna(input[y][x], new Point(x, y))));
            return antennaMap;
        }

        public static AntinodeMap GenerateAntinodeMapFromStringInput(string[] input)
        {
            return GenerateFromStringInput(input).GenerateAntinodeMap();
        }
    }
}
