using FluentAssertions;

namespace AoC._2024.day06.v1.Tests
{
    public class InputTests
    {
        [Fact]
        public void InputDataReturnsXDistinctPointsBeforeLeavingForPartOne()
        {
            var inputData = File.ReadAllLines("input.txt");

            var lab = Lab.InitialiseFrom(inputData);
            var guard = InputParser.FindGuard(inputData);

            var visitedPositions = guard.GetPatrolRoute(lab);

            visitedPositions.Distinct().Should().HaveCount(4883);

            // 74 too low
            // 4884 too high
        }
    }
}
