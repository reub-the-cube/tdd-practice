using System.Drawing;

namespace AoC._2024.day08.v1
{
    public class AntinodeMap
    {
        private readonly List<Antenna> _antennas = [];
        private readonly HashSet<Point> _antinodePoints = [];
        private readonly bool _addResonantHarmonics = false;
        private readonly Point _oppositeCorner;

        public AntinodeMap(Point oppositeCorner)
        {
            _oppositeCorner = oppositeCorner;
        }

        public AntinodeMap(Point oppositeCorner, bool addResonantHarmonics)
        {
            _oppositeCorner = oppositeCorner;
            _addResonantHarmonics = addResonantHarmonics;
        }

        public void AddAntenna(Antenna antenna)
        {
            AddAnyValidAntinodesForAntenna(antenna);
            _antennas.Add(antenna);
        }

        public bool IsInBounds(Point point)
        {
            if (point.X < 0 || point.X > _oppositeCorner.X || point.Y < 0 || point.Y > _oppositeCorner.Y)
            {
                return false;
            }

            return true;
        }

        public int NumberOfDistinctLoggedPoints()
        {
            return _antinodePoints.Count;
        }

        private void AddAnyValidAntinodesForAntenna(Antenna antenna)
        {
            var possibleAntinodes = _addResonantHarmonics ? antenna.CreateAntinodes(_antennas, _oppositeCorner) : antenna.CreateAntinodes(_antennas);
            var validAntinodes = possibleAntinodes.Where(a => IsInBounds(a.Point));

            foreach (var antinode in validAntinodes)
            {
                _antinodePoints.Add(antinode.Point);
            }
        }
    }
}
