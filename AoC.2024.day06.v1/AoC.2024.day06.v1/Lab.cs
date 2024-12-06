namespace AoC._2024.day06.v1
{
    public class Lab(Position oppositeCorner, List<Position> obstacles)
    {
        public static Lab InitialiseFrom(string[] inputData)
        {
            var oppositeCorner = new Position(inputData[0].Length, inputData.Length);
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

        private bool IsInBounds(Position target)
        {
            var isInXBounds = target.X > -1 && target.X <= oppositeCorner.X;
            var isInYBounds = target.Y > -1 && target.Y <= oppositeCorner.Y;

            return isInXBounds && isInYBounds;
        }
    }
}
