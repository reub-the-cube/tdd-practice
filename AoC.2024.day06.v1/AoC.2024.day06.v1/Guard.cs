namespace AoC._2024.day06.v1
{
    public class Guard(Position position, Direction directionFacing)
    {
        private readonly RoutePosition _startingPosition = new(position, directionFacing);
        private RoutePosition _currentPosition = new(position, directionFacing);
        private Route _route = new();
        private List<Route> _escapeRoutes = [];

        public List<Position> GetPatrolRoute(Lab lab)
        {
            _route = new();
            _route.TryAdd(_startingPosition.Position, _startingPosition.Direction);
            _currentPosition = _startingPosition;

            Move(lab);

            if (!_route.Repeats())
            {
                _escapeRoutes.Add(_route);
            }

            return _route.PositionsVisited();
        }

        public bool HasBeenHereBefore()
        {
            return _route.Repeats();
        }

        public bool PassesThrough(Position position)
        {
            return _route.GoesThrough(position);
        }

        private bool Move(Lab lab)
        {
            Turn(lab);
            if (StepForward(lab))
            {
                return Move(lab);
            }

            return false;
        }

        private void Turn(Lab lab)
        {
            if (lab.IsBlocked(_currentPosition.Next().Position))
            {
                _currentPosition = _currentPosition.Turn();
                _route.TryAdd(_currentPosition.Position, _currentPosition.Direction);
                Turn(lab);
            }
        }

        private bool StepForward(Lab lab)
        {
            var nextPosition = _currentPosition.Next();

            if (lab.CanMoveTo(nextPosition.Position))
            {
                _currentPosition = nextPosition;
                bool newPosition = _route.TryAdd(_currentPosition.Position, _currentPosition.Direction);
                return newPosition;
            }

            return false;
        }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    };

    public record Position(int X, int Y)
    {
        public Position Next(Direction directionFacing)
        {
            if (directionFacing == Direction.Up)
            {
                return new(X, Y + 1);
            }

            if (directionFacing == Direction.Down)
            {
                return new(X, Y - 1);
            }

            if (directionFacing == Direction.Right)
            {
                return new(X + 1, Y);
            }

            return new(X - 1, Y);
        }
    }
}
