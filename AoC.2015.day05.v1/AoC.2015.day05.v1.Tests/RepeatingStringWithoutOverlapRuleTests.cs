using FluentAssertions;

namespace AoC._2015.day05.v1.Tests
{
    public class RepeatingStringWithoutOverlapRuleTests
    {
        [Fact]
        public void EmptyStringReturnsFalseForIsNice()
        {
            var rule = new RepeatingStringWithoutOverlapRule();

            var isNice = rule.IsNice(string.Empty);

            isNice.Should().Be(false);
        }

        [Theory]
        [InlineData("abab")]
        [InlineData("abaab")]
        [InlineData("acac")]
        [InlineData("xyxy")]
        [InlineData("aabcdefgaa")]
        public void RepeatingSubstringReturnsTrueForIsNice(string initialInput)
        {
            var rule = new RepeatingStringWithoutOverlapRule();

            var isNice = rule.IsNice(initialInput);

            isNice.Should().Be(true);
        }

        [Theory]
        [InlineData("aba")]
        [InlineData("abba")]
        public void NonRepeatingSubstringReturnsFalseForIsNice(string initialInput)
        {
            var rule = new RepeatingStringWithoutOverlapRule();

            var isNice = rule.IsNice(initialInput);

            isNice.Should().Be(false);
        }
    }
}
