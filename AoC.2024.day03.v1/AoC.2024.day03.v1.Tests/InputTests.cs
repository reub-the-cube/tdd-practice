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
}