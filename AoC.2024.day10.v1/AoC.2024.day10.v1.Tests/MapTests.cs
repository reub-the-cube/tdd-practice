using FluentAssertions;

namespace AoC._2024.day10.v1.Tests;

public class MapTests
{
    [Fact]
    public void AfterCreationTheTrailheadsCanBeFoundOnTheExampleOneInput()
    {
        var map = new Map(Doubles.ExampleOneInput);

        var trailheads = map.FindTrailheads();

        trailheads.Should().HaveCount(1);
    }

    [Fact]
    public void AfterCreationTheTrailheadsCanBeFound()
    {
        var map = new Map(Doubles.TestMapInput);

        var trailheads = map.FindTrailheads();

        trailheads.Should().HaveCount(27);
    }

    [Fact]
    public void StartingFromAPositionThatIsAlsoTheEndHasAScoreOfOne()
    {
        var position = new Position(0, 0, 9);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(1);
    }

    [Fact]
    public void StartingFromAPositionThatHasNowhereToGoHasAScoreOfZero()
    {
        var position = new Position(9, 4, 8);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(0);
    }

    [Fact]
    public void StartingFromAPositionThatIsOnePositionFromTheEndHasAScoreOfOne()
    {
        var position = new Position(2, 1, 8);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(1);
    }

    [Fact]
    public void StartingFromAPositionThatHasTwoEndPositionsForASingleStepHasAScoreOfTwo()
    {
        var position = new Position(1, 0, 8);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(2);
    }

    [Fact]
    public void StartingFromAPositionThatHasOneEndPositionForATwoStepsHasAScoreOfOne()
    {
        var position = new Position(2, 2, 7);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(1);
    }

    [Fact]
    public void StartingFromAPositionThatHasThreeEndPositionFromATrailheadHasAScoreOfThree()
    {
        var position = new Position(3, 4, 0);
        var map = new Map(Doubles.TestMapInput);

        var score = map.ScoreFrom(position);

        score.Should().Be(3);
    }

    [Fact]
    public void ScoreFromAllTrailheadsUsedForTheMapScore()
    {
        var map = new Map(Doubles.TestMapInput);
        var score = map.ScoreFromTrailheads();

        score.Should().Be(6);
    }
}
