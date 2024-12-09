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

        public List<Antinode> CreateAntinodes(IEnumerable<Antenna> antennas, Point maximumBounds)
        {
            var antennasWithSameFrequency = antennas.Where(a => a.Frequency == Frequency);
            var allAntinodesForThisAntenna = antennasWithSameFrequency.SelectMany(a => CreateAntinodeLine(a, maximumBounds));
            return [.. allAntinodesForThisAntenna];
        }

        public List<Antinode> CreateAntinodePair(Antenna other)
        {
            var (dx, dy) = GetOffsetTo(other.Point);
            var pointCloserToThis = new Point(Point.X - dx, Point.Y - dy);
            var pointCloserToOther = new Point(other.Point.X + dx, other.Point.Y + dy);

            return [new Antinode(pointCloserToThis), new Antinode(pointCloserToOther)];
        }

        public List<Antinode> CreateAntinodeLine(Antenna other, Point maximumBounds)
        {
            var antinodePoints = new List<Point>();
            var (dx, dy) = GetOffsetTo(other.Point);

            antinodePoints.AddRange(PointsCloserToThis(dx, dy, [Point], maximumBounds));
            antinodePoints.AddRange(PointsCloserToOther(dx, dy, [other.Point], maximumBounds));

            return antinodePoints.Select(p => new Antinode(p)).ToList();
        }

        private (int dx, int dy) GetOffsetTo(Point other)
        {
            return (other.X - Point.X, other.Y - Point.Y);
        }

        private static List<Point> PointsCloserToThis(int dx, int dy, List<Point> pointList, Point maximumBounds)
        {
            var nextPoint = new Point(pointList.Last().X - dx, pointList.Last().Y - dy);

            if (IsInBounds(nextPoint, maximumBounds))
            {
                pointList.Add(nextPoint);
                return PointsCloserToThis(dx, dy, pointList, maximumBounds);
            }

            return pointList;
        }

        private static List<Point> PointsCloserToOther(int dx, int dy, List<Point> pointList, Point maximumBounds)
        {
            var nextPoint = new Point(pointList.Last().X + dx, pointList.Last().Y + dy);

            if (IsInBounds(nextPoint, maximumBounds))
            {
                pointList.Add(nextPoint);
                return PointsCloserToOther(dx, dy, pointList, maximumBounds);
            }

            return pointList;
        }

        private static bool IsInBounds(Point point, Point maximumBounds)
        {
            if (point.X < 0 || point.X > maximumBounds.X || point.Y < 0 || point.Y > maximumBounds.Y)
            {
                return false;
            }

            return true;
        }
    }
}