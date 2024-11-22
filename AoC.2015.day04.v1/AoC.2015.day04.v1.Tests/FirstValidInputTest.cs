using Aoc._2015.day04.v1;
using FluentAssertions;

namespace AoC._2015.day04.v1.Tests;

public class FirstValidInputTest
{
    [Fact]
    public void FirstValidInputIsFirstInput()
    {
        var firstValidInput = new FirstValidInput("");

        var validInput = firstValidInput.ForSecret("abcdef");

        validInput.Should().Be("abcdef1");
    }


    [Fact]
    public void FirstValidInputIsFourthInput()
    {
        var firstValidInput = new FirstValidInput("^bfe");

        var validInput = firstValidInput.ForSecret("secret");

        validInput.Should().Be("secret4");
    }
}
