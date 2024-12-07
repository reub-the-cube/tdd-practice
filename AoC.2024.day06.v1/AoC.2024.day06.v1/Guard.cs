namespace AoC._2024.day06.v1
{
    public class Guard
    {
        private RoutePosition _startingPosition;
        private RoutePosition _currentPosition;
        private Route _route = new();
        private List<Route> _escapeRoutes = [];


        public Guard(Position position, Direction directionFacing)
        {
            _startingPosition = new(position, directionFacing);
            _currentPosition = new(position, directionFacing);
            _route.TryAdd(_currentPosition.Position, _currentPosition.Direction);
        }

        public Guard Clone()
        {
            var startingPosition = _route.TheStart();
            return new Guard(startingPosition.Position, startingPosition.Direction);
        }

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

        public List<Position> GetPatrolRoute(Lab lab, Guard something)
        {
            Move(lab);

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
            TurnAsRequired(lab);
            if (StepForward(lab))
            {
                return Move(lab);
            }

            return false;
        }

        private void TurnAsRequired(Lab lab)
        {
            _currentPosition = PositionAfterTurning(_currentPosition, lab);
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

        private RoutePosition PositionAfterTurning(RoutePosition position, Lab lab)
        {
            if (lab.IsBlocked(position.Next().Position))
            {
                position = position.Turn();
                _route.TryAdd(position.Position, position.Direction);
                return PositionAfterTurning(position, lab);
            }

            return position;
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
