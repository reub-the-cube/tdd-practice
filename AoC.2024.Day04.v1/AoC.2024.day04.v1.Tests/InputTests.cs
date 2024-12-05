using FluentAssertions;

namespace AoC._2024.day04.v1.Tests
{
    public class InputTests
    {
        private readonly string[] inputText = File.ReadAllLines("input.txt");

        [Fact]
        public void InputTextForPartOneReturns2562InstancesOfXMAS()
        {
            var wordsearch = new WordSearch(inputText);

            var numberOfOccurrences = wordsearch.FindOccurrencesOf("XMAS");

            numberOfOccurrences.Should().Be(2562);
        }

        [Fact]
        public void InputTextForPartTwoReturns9InstancesOfMASInAnXShape()
        {
            var wordsearch = new WordSearch(inputText);

            var numberOfOccurrences = wordsearch.FindXShapeOccurrencesOf("MAS");

            numberOfOccurrences.Should().Be(1902);

            // Two attempts, 1879 too low.
        }
    }
}