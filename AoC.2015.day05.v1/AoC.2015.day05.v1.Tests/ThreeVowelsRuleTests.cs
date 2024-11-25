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
}
