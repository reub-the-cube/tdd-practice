namespace AoC._2024.day06.v1
{
    public class Guard(Position position, Direction directionFacing)
    {
        private readonly RoutePosition _startingPosition = new(position, directionFacing);
        private RoutePosition _currentPosition = new(position, directionFacing);
        private Route _route = new();

        public Route GetPatrolRoute(Lab lab, Route? escapeRoute = null)
        {
            _route = new();
            _currentPosition = _startingPosition;
            AddCurrentPositionToRoute();

            Move(lab, escapeRoute);

            return _route;
        }

        public bool HasBeenHereBefore()
        {
            return _route.Repeats();
        }

        public bool PassesThrough(Position position)
        {
            return _route.GoesThrough(position);
        }

        private bool Move(Lab lab, Route? escapeRoute)
        {
            if (CanEscape(lab, escapeRoute))
            {
                return false;
            }

            Turn(lab);
            if (StepForward(lab))
            {
                return Move(lab, escapeRoute);
            }

            return false;
        }

        private bool CanEscape(Lab lab, Route? escapeRoute)
        {
            if (escapeRoute == null)
                return false;

            var escapeRouteFromThisPosition = escapeRoute.GetRouteFrom(_currentPosition);

            if (!escapeRouteFromThisPosition.PositionsVisited().Any())
                return false;

            var isNotBlocked = lab.RouteIsNotBlocked(escapeRouteFromThisPosition);
            return isNotBlocked;
        }

        private void Turn(Lab lab)
        {
            if (lab.IsBlocked(_currentPosition.Next().Position))
            {
                _currentPosition = _currentPosition.Turn();
                AddCurrentPositionToRoute();
                Turn(lab);
            }
        }

        private bool StepForward(Lab lab)
        {
            var nextPosition = _currentPosition.Next();

            if (lab.CanMoveTo(nextPosition.Position))
            {
                _currentPosition = nextPosition;
                bool newPosition = AddCurrentPositionToRoute();
                return newPosition;
            }

            return false;
        }

        private bool AddCurrentPositionToRoute()
        {
            bool addedToRoute = _route.TryAdd(_currentPosition.Position, _currentPosition.Direction);

            return addedToRoute;
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
