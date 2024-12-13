using FluentAssertions;

namespace AoC._2024.day10.v1.Tests;

public class MapTests
{
    [Fact]
    public void StartingFromAPositionThatIsAlsoTheEndHasAScoreOfOne()
    {
        var position = new Position(0, 0, 9);
        var map = Doubles.TestMap;

        var score = map.ScoreFrom(position);

        score.Should().Be(1);
    }

    [Fact]
    public void StartingFromAPositionThatHasNowhereToGoHasAScoreOfZero()
    {
        var position = new Position(9, 4, 8);
        var map = Doubles.TestMap;

        var score = map.ScoreFrom(position);

        score.Should().Be(0);
    }
}