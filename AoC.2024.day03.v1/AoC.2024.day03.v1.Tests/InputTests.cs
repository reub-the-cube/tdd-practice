using FluentAssertions;

namespace AoC._2024.day03.v1.Tests;

public class InputTests
{
    private readonly IEnumerable<string> inputText = File.ReadAllLines("input.txt");

    [Fact]
    public void InputTextHasBeenRead()
    {
        inputText.Should().HaveCount(6);
    }

    [Fact]
    public void InputTextResultIs161289189ForPartOne()
    {
        var instructions = MemoryInterpreter.GetInstructionsFrom(inputText);

        instructions.Sum(i => i.Result).Should().Be(161289189);
    }

    [Fact]
    public void InputTextResultIsXForPartTwo()
    {
        var enabledInput = MemoryInterpreter.ExcludeDisabledInstructionsFrom(inputText);
        var instructions = MemoryInterpreter.GetInstructionsFrom([enabledInput]);
        
        instructions.Sum(i => i.Result).Should().Be(83595109);

        // 40999856
        // 83595109
    }
}