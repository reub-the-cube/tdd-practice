using FluentAssertions;

namespace AoC._2024.day03.v1.Tests;

public class ExampleTests
{
    private readonly IEnumerable<string> exampleText = File.ReadAllLines("example.txt");
    private readonly IEnumerable<string> example2Text = File.ReadAllLines("examplePartTwo.txt");

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

    [Fact]
    public void ExampleTextResultIs48ForPartTwo()
    {
        var enabledInput = MemoryInterpreter.ExcludeDisabledInstructionsFrom(example2Text);
        var instructions = MemoryInterpreter.GetInstructionsFrom([enabledInput]);

        instructions.Sum(i => i.Result).Should().Be(48);
    }
}