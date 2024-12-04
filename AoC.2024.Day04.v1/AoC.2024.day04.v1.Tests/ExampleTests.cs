using FluentAssertions;

namespace AoC._2024.day04.v1.Tests;

public class ExampleTests
{
    private readonly string[] exampleText = File.ReadAllLines("example.txt");

    [Fact]
    public void InputFileCanBeRead()
    {
        exampleText.Should().HaveCount(10);
    }
}
