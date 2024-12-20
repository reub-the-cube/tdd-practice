using FluentAssertions;

namespace AoC._2024.day02.v1.Tests;

public class ExampleTests
{
    private readonly IEnumerable<string> exampleText = File.ReadAllLines("example.txt");

    [Fact]
    public void ExampleTextHasBeenRead()
    {
        exampleText.Should().HaveCount(6);
    }

    [Fact]
    public void ExampleTextReturnsTwoSafeReports()
    {
        var numberOfSafeReports = ReactorReportFeed.CountNumberOfSafeReports(exampleText);

        numberOfSafeReports.Should().Be(2);
    }

    [Fact]
    public void ExampleTextReturnsFourSafeReportsForPartTwo()
    {
        var numberOfSafeReports = ReactorReportFeed.CountNumberOfSafeReports(exampleText, 1);

        numberOfSafeReports.Should().Be(4);
    }
}
