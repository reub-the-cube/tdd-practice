namespace AoC._2024.day06.v1
{
    public class Route
    {
        private readonly HashSet<RoutePosition> _positions = [];
        private bool _hasARepeatingPosition = false;

        public Route()
        {
        }

        public Route(IEnumerable<RoutePosition> positions)
        {
            _positions = positions.ToHashSet();
        }

        public RoutePosition TheStart()
        {
            return _positions.First();
        }

        public bool TryAdd(Position position, Direction direction)
        {
            var success = _positions.Add(new(position, direction));
            if (!success)
            {
                _hasARepeatingPosition = true;
            }

            return success;
        }

        public bool GoesThrough(Position position)
        {
            return _positions.Select(p => p.Position).Contains(position);
        }

        public Route GetRouteFrom(RoutePosition position)
        {
            if (!_positions.Contains(position) || _positions.Last() == position)
            {
                return new Route();
            }

            var positions = _positions.ToList();
            var index = positions.IndexOf(position);

            var traillingPositions = positions.Skip(index + 1);
            return new Route(traillingPositions);
        }

        public bool Repeats()
        {
            return _hasARepeatingPosition;
        }

        public List<Position> PositionsVisited()
        {
            return _positions.Select(p => p.Position).ToList();
        }
    }

    public record RoutePosition(Position Position, Direction Direction) : Position(Position.X, Position.Y)
    {
        private static readonly Dictionary<Direction, Direction> _nextDirection = new() {
            { Direction.Up, Direction.Right },
            { Direction.Right, Direction.Down },
            { Direction.Down, Direction.Left },
            { Direction.Left, Direction.Up }
        };

        public RoutePosition Next()
        {
            return new(Position.Next(Direction), Direction);
        }

        public RoutePosition Turn()
        {
            return new(Position, _nextDirection[Direction]);
        }
    }
}