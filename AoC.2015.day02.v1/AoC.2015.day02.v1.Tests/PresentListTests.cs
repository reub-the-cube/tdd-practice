using FluentAssertions;

namespace AoC._2015.day02.v1.Tests;

public class PresentListTests
{
    [Fact]
    public void EmptyListRequiresNoWrappingPaper()
    {
        var requiredPaper = PresentList.RequiredWrappingPaperAmount(string.Empty);

        requiredPaper.Should().Be(0);
    }

    [Fact]
    public void SinglePresentRequiresCorrectAmountOfWrappingPaper()
    {
        string presentDimensions = @"1x1x1";
        var requiredPaper = PresentList.RequiredWrappingPaperAmount(presentDimensions);

        requiredPaper.Should().Be(7);
    }

    [Fact]
    public void TwoPresentsRequiresCorrectAmountOfWrappingPaper()
    {
        string presentDimensions = @"1x1x1
            2x2x2";
        var requiredPaper = PresentList.RequiredWrappingPaperAmount(presentDimensions);

        requiredPaper.Should().Be(35);
    }

    [Theory]
    [InputData]
    public void ExampleOneInputDataVerificationTest(int expectedWrappingPaper, int expectedRibbon, string presentDimensions) 
    {
        var requiredPaper = PresentList.RequiredWrappingPaperAmount(presentDimensions);
        requiredPaper.Should().Be(expectedWrappingPaper);

        var requiredRibbon = PresentList.RequiredRibbonAmount(presentDimensions);
        requiredRibbon.Should().Be(expectedRibbon);
    }
}
