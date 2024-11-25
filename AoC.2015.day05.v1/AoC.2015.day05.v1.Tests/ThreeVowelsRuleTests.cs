using FluentAssertions;

namespace AoC._2015.day05.v1.Tests;

public class ThreeVowelsRuleTests
{
    private readonly ThreeVowelsRule _rule;
    public ThreeVowelsRuleTests()
    {
        _rule = new ThreeVowelsRule();
    }

    [Fact]
    public void EmptyStringReturnsFalseForIsNice()
    {
        var initialInput = string.Empty;

        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("aei")]
    [InlineData("aou")]
    [InlineData("oui")]
    [InlineData("aaa")]
    [InlineData("slaaa")]
    [InlineData("azeyixowu")]
    public void ThreeOrMoreVowelsReturnsTrueForIsNice(string initialInput)
    {
        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(true);
    }

    [Theory]
    [InlineData("abbe")]
    [InlineData("dvszwmarrgswjxmb")]
    public void LessThanThreeVowelsReturnsFalseForIsNice(string initialInput)
    {
        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(false);
    }
}
