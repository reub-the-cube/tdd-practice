namespace AoC._2024.day06.v1
{
    public class Lab(Position oppositeCorner, List<Position> obstacles)
    {
        public static Lab InitialiseFrom(string[] inputData)
        {
            var oppositeCorner = new Position(inputData[0].Length - 1, inputData.Length - 1);
            return new Lab(oppositeCorner, InputParser.GetObstaclesFromInput(inputData));
        }

        public bool CanMoveTo(Position target)
        {
            return IsInBounds(target) && !IsBlocked(target);
        }

        public bool IsBlocked(Position target)
        {
            return obstacles.Contains(target);
        }

        public int PossibleLoopsWithAdditionalObstacle(Position from, Direction facing)
        {
            var guard = new Guard(from, facing);
            _ = guard.GetPatrolRoute(this);

            var possibleObstacleLocationsForCausingALoop = GetPossibleObstacleLocationsForCausingALoop(guard);
            possibleObstacleLocationsForCausingALoop.Remove(from);

            int numberOfLoopsPossible = possibleObstacleLocationsForCausingALoop.Count(o => IsALoopWithATempObstacle(o, guard));

            return numberOfLoopsPossible;
        }

        private List<Position> GetPossibleObstacleLocationsForCausingALoop(Guard guard)
        {
            var xIndexes = Enumerable.Range(0, oppositeCorner.X + 1);
            var yIndexes = Enumerable.Range(0, oppositeCorner.Y + 1);

            var locationsNotOnGuardsRoute = xIndexes.SelectMany(x => yIndexes
                .Select(y => new Position(x, y))
                .Where(pos => guard.PassesThrough(pos))
            );

            locationsNotOnGuardsRoute = locationsNotOnGuardsRoute
                .Except(obstacles);

            return locationsNotOnGuardsRoute.ToList();
        }

        private bool IsALoopWithATempObstacle(Position obstacleToPlace, Guard originalGuard)
        {
            obstacles.Add(obstacleToPlace);
            _ = originalGuard.GetPatrolRoute(this);
            obstacles.Remove(obstacleToPlace);

            if (obstacleToPlace.Y % 45 == 0)
            {
                Console.WriteLine($"{obstacleToPlace.X} of {oppositeCorner.X} - {obstacleToPlace.Y} of {oppositeCorner.Y}");
            }

            return originalGuard.HasBeenHereBefore();
        }

        private bool IsInBounds(Position target)
        {
            var isInXBounds = target.X > -1 && target.X <= oppositeCorner.X;
            var isInYBounds = target.Y > -1 && target.Y <= oppositeCorner.Y;

            return isInXBounds && isInYBounds;
        }
    }
}
