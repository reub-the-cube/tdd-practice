using InequalityChecker;
using FluentAssertions;

namespace InequalityChecker.Tests;

public class InequalityChecks
{
    [Fact]
    public void ThreeIsLessThanFive()
    {
        var checker = new InequalityChecker();

        var result = checker.SubmitGuess(3, 5, '<');

        result.IsCorrect.Should().Be(true);
    }

    [Fact]
    public void ThreeIsNotMoreThanFive()
    {
        var checker = new InequalityChecker();

        var result = checker.SubmitGuess(3, 5, '>');

        result.IsCorrect.Should().Be(false);
        result.ShouldHaveBeen.Should().Be('<');
    }
}