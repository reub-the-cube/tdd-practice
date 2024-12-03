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

    [Fact]
    public void ExampleTextResultIs161ForPartOne()
    {
        var instructions = MemoryInterpreter.GetInstructionsFrom(exampleText);

        instructions.Sum(i => i.Result).Should().Be(161);
    }
}