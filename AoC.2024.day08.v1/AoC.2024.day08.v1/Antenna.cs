using System.Drawing;

namespace AoC._2024.day08.v1
{
    public class Antenna(char frequency, Point point)
    {
        private char Frequency { get; init; } = frequency;
        private Point Point { get; init; } = point;

        public List<Antinode> CreateAntinodes(IEnumerable<Antenna> antennas)
        {
            var antennasWithSameFrequency = antennas.Where(a => a.Frequency == Frequency);
            var allAntinodesForThisAntenna = antennasWithSameFrequency.SelectMany(CreateAntinodePair);
            return [.. allAntinodesForThisAntenna];
        }

        public List<Antinode> CreateAntinodePair(Antenna other)
        {
            var (dx, dy) = GetOffsetTo(other.Point);
            var pointCloserToThis = new Point(Point.X - dx, Point.Y - dy);
            var pointCloserToOther = new Point(other.Point.X + dx, other.Point.Y + dy);

            return [new Antinode(pointCloserToThis), new Antinode(pointCloserToOther)];
        }

        private (int dx, int dy) GetOffsetTo(Point other)
        {
            return (other.X - Point.X, other.Y - Point.Y);
        }
    }
}
