using FluentAssertions;

namespace AoC._2015.day05.v1.Tests;

public class ForbiddenSequenceRuleTests
{
    private ForbiddenSequenceRule _rule;
    public ForbiddenSequenceRuleTests()
    {
        _rule = new ForbiddenSequenceRule();
    }

    [Theory]
    [InlineData("ab")]
    [InlineData("cd")]
    [InlineData("pq")]
    [InlineData("xy")]
    public void ForbiddenSequenceReturnsFalseForIsNice(string initialValue)
    {
        var isNice = _rule.IsNice(initialValue);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("ba")]
    [InlineData("acbd")]
    public void NoForbiddenSequenceReturnsTrueForIsNice(string initialValue)
    {
        var isNice = _rule.IsNice(initialValue);

        isNice.Should().Be(true);
    }
}