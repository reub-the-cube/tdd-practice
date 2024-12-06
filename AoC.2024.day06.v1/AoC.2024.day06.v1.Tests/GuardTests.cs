using System.Formats.Asn1;

namespace AoC._2024.day06.v1.Tests;

public class GuardTests
{
    [Fact]
    public void PatrolAnAreaReturnsVisitedPositions()
    {
        var guard = new Guard();
        var lab = new Lab();
        var startingPosition = new Position(3, 5, 0);

        var visitedPositions = guard.Patrol(area, startingPosition);

        visitedPositions.Should().HaveCount(1);
    }
}