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
            int patrolIsALoopCount = 0;
            for (int x = 0; x < oppositeCorner.X + 1; x++)
            {
                for (int y = 0; y < oppositeCorner.Y + 1; y++)
                {
                    var temporaryObstaclePosition = new Position(x, y);
                    if (!obstacles.Contains(temporaryObstaclePosition))
                    {
                        obstacles.Add(temporaryObstaclePosition);

                        var guard = new Guard(from, facing);
                        _ = guard.GetPatrolRoute(this);
                        if (guard.HasBeenHereBefore())
                        {
                            patrolIsALoopCount++;
                        }
                        obstacles.Remove(temporaryObstaclePosition);
                    }
                }
            }

            return patrolIsALoopCount;
        }

        private bool IsInBounds(Position target)
        {
            var isInXBounds = target.X > -1 && target.X <= oppositeCorner.X;
            var isInYBounds = target.Y > -1 && target.Y <= oppositeCorner.Y;

            return isInXBounds && isInYBounds;
        }
    }
}
