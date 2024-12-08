using System.Drawing;

namespace AoC._2024.day08.v1
{
    public class AntinodeMap(Point oppositeCorner)
    {
        private readonly List<Antenna> _antennas = [];
        private readonly HashSet<Point> _antinodePoints = [];

        public void AddAntenna(Antenna antenna)
        {
            AddAnyValidAntinodesForAntenna(antenna);
            _antennas.Add(antenna);
        }

        public bool IsInBounds(Point point)
        {
            if (point.X < 0 || point.X > oppositeCorner.X || point.Y < 0 || point.Y > oppositeCorner.Y)
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
            var possibleAntinodes = antenna.CreateAntinodes(_antennas);
            var validAntinodes = possibleAntinodes.Where(a => IsInBounds(a.Point));

            foreach (var antinode in validAntinodes)
            {
                _antinodePoints.Add(antinode.Point);
            }
        }
    }
}
