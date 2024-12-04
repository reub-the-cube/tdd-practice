using FluentAssertions;

namespace AoC._2024.day04.v1.Tests;

public class ExampleTests
{
    private readonly string[] exampleText = File.ReadAllLines("example.txt");

    [Fact]
    public void ExampleFileCanBeRead()
    {
        exampleText.Should().HaveCount(10);
    }

    [Fact]
    public void ExampleTextForPartOneReturns18InstancesOfXMAS()
    {
        var wordsearch = new WordSearch(exampleText);

        var numberOfOccurrences = wordsearch.FindOccurrencesOf("XMAS");

        numberOfOccurrences.Should().Be(18);
    }
}
