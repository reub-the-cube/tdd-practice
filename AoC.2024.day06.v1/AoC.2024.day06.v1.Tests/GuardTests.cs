using FluentAssertions;

namespace AoC._2024.day06.v1.Tests;

public class GuardTests
{
    public class GetPatrolRoute
    {
        private readonly Lab Lab;

        public GetPatrolRoute()
        {
            Lab = LabTests.MakeTestLab();
        }

        [Fact]
        public void ReturnsOneVisitedPositionWhenStartingOnEdgeOfAreaAndFacingOut()
        {
            var startingPosition = new Position(2, 9);
            var guard = new Guard(startingPosition, Direction.Up);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(1);
        }

        [Fact]
        public void ReturnsTwoVisitedPositionsWhenStartingNearEdgeOfAreaWithClearPathOut()
        {
            var startingPosition = new Position(3, 8);
            var guard = new Guard(startingPosition, Direction.Up);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(2);
        }

        [Fact]
        public void ReturnsThreeVisitedPositionsWhenStartingNearEdgeOfAreaWithClearPathOut()
        {
            var startingPosition = new Position(6, 7);
            var guard = new Guard(startingPosition, Direction.Up);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(3);
        }

        [Fact]
        public void ReturnsOneVisitedPositionWhenObstacleForcesImmediateExit()
        {
            var startingPosition = new Position(9, 7);
            var guard = new Guard(startingPosition, Direction.Up);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(1);
        }

        [Fact]
        public void ReturnsTwoVisitedPositionWhenObstacleForcesQuickExit()
        {
            var startingPosition = new Position(2, 8);
            var guard = new Guard(startingPosition, Direction.Down);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(4);
        }

        [Fact]
        public void ReturnsVisitedPositionsWhenGuardMakesAFewTurns()
        {
            var startingPosition = new Position(3, 1);
            var guard = new Guard(startingPosition, Direction.Left);

            var route = guard.GetPatrolRoute(Lab);

            route.Should().HaveCount(12);
        }
    }
}