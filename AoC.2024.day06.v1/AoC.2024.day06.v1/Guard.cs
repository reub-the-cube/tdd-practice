namespace AoC._2024.day06.v1
{
    public class Guard
    {
        private Position _currentPosition;
        private Direction _directionFacing;
        private readonly Dictionary<Position, List<Direction>> _visitedDirectionalPositions = [];

        private static readonly Dictionary<Direction, Direction> _nextDirection = new() { 
            { Direction.Up, Direction.Right }, 
            { Direction.Right, Direction.Down }, 
            { Direction.Down, Direction.Left }, 
            { Direction.Left, Direction.Up }
        };

        public Guard(Position position, Direction directionFacing)
        {
            _currentPosition = position;
            _directionFacing = directionFacing;
            AddDirectionalPosition();
        }

        public List<Position> GetPatrolRoute(Lab lab)
        {
            Move(lab);

            return [.. _visitedDirectionalPositions.Keys];
        }

        public bool HasBeenHereBefore()
        {
            return _visitedDirectionalPositions[_currentPosition].GroupBy(x => x).Any(p => p.Count() > 1);
        }

        private void AddDirectionalPosition()
        {
            _visitedDirectionalPositions.TryAdd(_currentPosition, []);
            _visitedDirectionalPositions[_currentPosition].Add(_directionFacing);
        }

        private bool Move(Lab lab)
        {
            var nextPosition = _currentPosition.Next(_directionFacing);
            if (lab.IsBlocked(nextPosition))
            {
                Turn();
                nextPosition = _currentPosition.Next(_directionFacing);
            }

            if (lab.CanMoveTo(nextPosition))
            {
                _currentPosition = nextPosition;
                AddDirectionalPosition();

                if (!HasBeenHereBefore())
                {
                    return Move(lab);
                }
            }

            return false;
        }

        private void Turn()
        {
            _directionFacing = _nextDirection[_directionFacing];
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
