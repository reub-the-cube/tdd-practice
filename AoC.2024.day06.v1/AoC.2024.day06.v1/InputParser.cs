namespace AoC._2024.day06.v1
{
    public static class InputParser
    {
        public static Guard FindGuard(string[] inputData)
        {
            var yIndex = inputData.ToList().FindIndex(s => s.Contains('^'));
            var xIndex = inputData[yIndex].IndexOf('^');

            return new Guard(new(xIndex, inputData.Length - yIndex - 1), Direction.Up);
        }

        public static List<Position> GetObstaclesFromInput(string[] inputData)
        {
            var yPositions = Enumerable.Range(0, inputData.Length);
            return yPositions.SelectMany(i => GetObstaclesFromInputRow(i, inputData[inputData.Length - i - 1])).ToList();
        }

        private static List<Position> GetObstaclesFromInputRow(int yIndex, string inputRow)
        {
            var obstacleIndex = inputRow.IndexOf('#');
            var xIndex = obstacleIndex;
            var obstaclePositions = new List<Position>();

            while (obstacleIndex > -1)
            {
                obstaclePositions.Add(new(xIndex, yIndex));
                inputRow = inputRow[(obstacleIndex + 1)..];

                obstacleIndex = inputRow.IndexOf('#');
                xIndex += obstacleIndex + 1;
            }

            return obstaclePositions;
        }
    }
}
