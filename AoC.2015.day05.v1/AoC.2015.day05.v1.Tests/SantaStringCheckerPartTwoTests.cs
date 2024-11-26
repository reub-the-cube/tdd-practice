using FluentAssertions;

namespace AoC._2015.day05.v1.Tests
{
    public class SantaStringCheckerPartTwoTests
    {
        private readonly SantaStringChecker _santaStringChecker;
        public SantaStringCheckerPartTwoTests()
        {
            _santaStringChecker = new SantaStringCheckerPartTwo();
        }

        [Fact]
        public void InputThatMeetsNoRulesReturnsFalseForIsValid()
        {
            var isNice = _santaStringChecker.IsNice("abca");

            isNice.Should().Be(false);
        }

        [Theory]
        [InlineData("abcab")] // Repeated ab, no pair of characters with a letter between them
        [InlineData("acab")] // No repeated pair, a pair of characters with a letter between them
        public void InputThatMeetsOneRuleReturnsFalseForIsValid(string initialInput)
        {
            var isNice = _santaStringChecker.IsNice(initialInput);

            isNice.Should().Be(false);
        }

        [Theory]
        [InlineData("abab")]
        public void InputThatMeetsTwoRulesReturnsTrueForIsValid(string initialInput)
        {
            var isNice = _santaStringChecker.IsNice(initialInput);

            isNice.Should().Be(true);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb")]
        [InlineData("xxyxx")]
        public void ExamplesReturnTrueForIsValid(string initialValue)
        {
            var isNice = _santaStringChecker.IsNice(initialValue);

            isNice.Should().Be(true);
        }

        [Theory]
        [InlineData("uurcxstgmygtbstg")]
        [InlineData("ieodomkazucvgmuy")]
        public void ExamplesReturnFalseForIsValid(string initialValue)
        {
            var isNice = _santaStringChecker.IsNice(initialValue);

            isNice.Should().Be(false);
        }
    }
}