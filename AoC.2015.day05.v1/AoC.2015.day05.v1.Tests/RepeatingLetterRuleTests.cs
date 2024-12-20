using FluentAssertions;

namespace AoC._2015.day05.v1.Tests;

public class RepeatingLetterRuleTests
{
    private RepeatingLetterRule _rule;
    public RepeatingLetterRuleTests()
    {
        _rule = new RepeatingLetterRule();
    }

    [Fact]
    public void EmptyStringReturnsFalseForIsNice()
    {
        var initialInput = string.Empty;

        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("aa")]
    [InlineData("bb")]
    [InlineData("cc")]
    [InlineData("dd")]
    [InlineData("ee")]
    [InlineData("ff")]
    [InlineData("gg")]
    [InlineData("hh")]
    [InlineData("ii")]
    [InlineData("jj")]
    [InlineData("kk")]
    [InlineData("ll")]
    [InlineData("mm")]
    [InlineData("nn")]
    [InlineData("oo")]
    [InlineData("pp")]
    [InlineData("qq")]
    [InlineData("rr")]
    [InlineData("ss")]
    [InlineData("tt")]
    [InlineData("uu")]
    [InlineData("vv")]
    [InlineData("ww")]
    [InlineData("xx")]
    [InlineData("yy")]
    [InlineData("zz")]
    public void RepeatingLetterReturnsTrueForIsNice(string initialInput)
    {
        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(true);
    }

    [Theory]
    [InlineData("ab")]
    [InlineData("zy")]
    public void RepeatingLetterReturnsFalseForIsNice(string initialInput)
    {
        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(false);
    }

    [Theory]
    [InlineData("aaa")]
    [InlineData("aba")]
    [InlineData("bab")]
    [InlineData("xyx")]
    [InlineData("abcdefeghi")]
    public void RepeatingLetterWithAGapReturnsTrueForIsNice(string initialInput)
    {
        _rule = new RepeatingLetterRule(1);

        var isNice = _rule.IsNice(initialInput);

        isNice.Should().Be(true);
    }
}


/*

[x] empty string is naughty
[ ] string less than three is naughty

ab is naughty
abei is naughty (because of ab) 

[x] aa to zz can be nice (as a rule)


[ ] aeibb is nice
[ ] bbaei is nice
[ ] aaei is nice

aei is naughty

empty list returns 0
one item list return 0 or 1
full list returns between 0 and item count

case insensitivity


vowelValidator.IsNice - check 3 vowels
doubleLetterValidator.IsNice - check repeated letters
naughtyStringValidator.IsNice - not in the restricted list

IsNice for no rules is not nice
IsNice for one rule is not nice x3 (1 or 2 or 3)
IsNice for two rules is not nice x3 (1/2 or 1/3 or 2/3)
IsNice for three rules is nice

*/