using FluentAssertions;

namespace AoC._2024.day02.v1.Tests;

public class InputTests
{
    private readonly IEnumerable<string> inputText = File.ReadAllLines("input.txt");

    [Fact]
    public void InputTextHasBeenRead()
    {
        inputText.Should().HaveCount(1000);
    }

    [Fact]
    public void InputTextReturnsCorrectNumberOfSafeReportsForPartOne()
    {
        var numberOfSafeReports = ReactorReportFeed.CountNumberOfSafeReports(inputText);

        numberOfSafeReports.Should().Be(287);
    }

    [Fact]
    public void InputTextReturnsCorrectNumberOfSafeReportsForPartTwo()
    {
        var numberOfSafeReports = ReactorReportFeed.CountNumberOfSafeReports(inputText, 1);

        numberOfSafeReports.Should().Be(354);
    }
}