using FluentAssertions;

namespace AoC._2024.day03.v1.Tests;

public class ExampleTests
{
    private readonly IEnumerable<string> exampleText = File.ReadAllLines("example.txt");

    [Fact]
    public void ExampleTextHasBeenRead()
    {
        exampleText.Should().HaveCount(1);
    }
}