using System.Drawing;

namespace AoC._2024.day08.v1
{
    public class AntinodeMap(Point oppositeCorner)
    {
        private readonly List<Antenna> _antennas = [];
        private readonly List<Antinode> _antinodes = [];

        public void AddAntenna(Antenna antenna)
        {
            _antinodes.AddRange(GetValidAntinodesForAntenna(antenna));
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
            var distinctPoints = _antinodes.Select(a => a.Point).Union(_antennas.Select(a => a.Point)).Distinct();
            return distinctPoints.Count();
        }

        private IEnumerable<Antinode> GetValidAntinodesForAntenna(Antenna antenna)
        {
            var possibleAntinodes = antenna.CreateAntinodes(_antennas);
            var validAntinodes = possibleAntinodes.Where(a => IsInBounds(a.Point));

            return validAntinodes;
        }
    }
}
