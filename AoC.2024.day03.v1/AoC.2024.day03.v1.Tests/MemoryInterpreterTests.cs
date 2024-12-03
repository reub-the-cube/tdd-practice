using FluentAssertions;

namespace AoC._2024.day03.v1.Tests;

public class MemoryInterpreterTests
{
    [Fact]
    public void CanFindMultiplicationInstructionsFromCorruptedMemoryIfPresent()
    {
        var corruptedMemory = new List<string>{ "mul(1,2)" };

        var instructions = MemoryInterpreter.GetInstructionsFrom(corruptedMemory);

        instructions.Should().HaveCount(1);
    }
}