namespace AoC._2024.day06.v1
{
    public class Guard
    {
        private Position _currentPosition;
        private Direction _directionFacing;
        private readonly List<Position> _visitedPositions = [];
        private static readonly Dictionary<Direction, Direction> _nextDirection = new() { 
            { Direction.Up, Direction.Right }, 
            { Direction.Right, Direction.Down }, 
            { Direction.Down, Direction.Left }, 
            { Direction.Left, Direction.Up }
        };

        public Guard(Position position, Direction directionFacing)
        {
            _currentPosition = position;
            _visitedPositions.Add(position);
            _directionFacing = directionFacing;
        }

        public List<Position> GetPatrolRoute(Lab lab)
        {
            Move(lab);

            return _visitedPositions;
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
                _visitedPositions.Add(nextPosition);
                return Move(lab);
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
