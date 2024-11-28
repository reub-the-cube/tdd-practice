using FluentAssertions;

namespace AoC._2015.day05.v1.Tests;

public class SantaStringCheckerPartOneTests
{
    private readonly SantaStringChecker _santaStringChecker;
    public SantaStringCheckerPartOneTests()
    {
        _santaStringChecker = new SantaStringCheckerPartOne();
    }

    [Fact]
    public void InputThatMeetsNoRulesReturnsFalseForIsValid()
    {
        var isNice = _santaStringChecker.IsNice("ab");

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("abei")] // 3 vowels, no repeating letter, does contain forbidden
    [InlineData("aab")] // not 3 vowels, repeating letter, does contain forbidden
    [InlineData("a")] // not 3 vowels, no repeating letter, does not contain forbidden
    public void InputThatMeetsExactlyOneRuleReturnsFalseForIsValid(string initialValue)
    {
        var isNice = _santaStringChecker.IsNice(initialValue);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("abee")] // 3 vowels, repeating letter, does contain forbidden
    [InlineData("aei")] // 3 vowels, no repeating letter, does not contain forbidden
    [InlineData("aa")] // not 3 vowels, repeating letter, does not contain forbidden
    public void InputThatMeetsExactlyTwoRulesReturnsFalseForIsValid(string initialValue)
    {
        var isNice = _santaStringChecker.IsNice(initialValue);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("ugknbfddgicrmopn")]
    [InlineData("aaa")]
    public void InputThatMeetsAllRulesReturnsTrueForIsValid(string initialValue)
    {
        var isNice = _santaStringChecker.IsNice(initialValue);

        isNice.Should().Be(true);
    }

    [Theory]
    [InlineData("jchzalrnumimnmhp")]
    [InlineData("haegwjzuvuyypxyu")]
    [InlineData("dvszwmarrgswjxmb")]
    public void ExamplesReturnFalseForIsValid(string initialValue)
    {
        var isNice = _santaStringChecker.IsNice(initialValue);

        isNice.Should().Be(false);
    }
}

/*
IsNice for no rules is not nice
IsNice for one rule is not nice x3 (1 or 2 or 3)
IsNice for two rules is not nice x3 (1/2 or 1/3 or 2/3)
IsNice for three rules is nice
*/