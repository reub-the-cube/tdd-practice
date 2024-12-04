using FluentAssertions;

namespace AoC._2024.day04.v1.Tests
{
    public class InputTests
    {
        private readonly string[] inputText = File.ReadAllLines("input.txt");

        [Fact]
        public void ExampleTextForPartOneReturns2562InstancesOfXMAS()
        {
            var wordsearch = new WordSearch(inputText);

            var numberOfOccurrences = wordsearch.FindOccurrencesOf("XMAS");

            numberOfOccurrences.Should().Be(2562);
        }
    }
}