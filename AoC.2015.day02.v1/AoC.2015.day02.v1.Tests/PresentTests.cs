using FluentAssertions;

namespace AoC._2015.day02.v1.Tests;

public class PresentTests
{
    [Fact]
    public void PresentCanBeCreatedFromDimensionInput()
    {
        var present = Present.FromDimension("1x1x1");

        present.Should().NotBe(null);
    }

    [Fact]
    public void PresentSmallestSideAreaIsTheLengthAndWidth()
    {
        var present = Present.FromDimension("1x2x3");
        present.AreaOfSmallestSide().Should().Be(2);
    }

    [Fact]
    public void PresentSmallestSideAreaIsTheLengthAndHeight()
    {
        var present = Present.FromDimension("1x3x2");
        present.AreaOfSmallestSide().Should().Be(2);
    }

    [Fact]
    public void PresentSmallestSideAreaIsTheWidthndHeight()
    {
        var present = Present.FromDimension("3x1x2");
        present.AreaOfSmallestSide().Should().Be(2);
    }

    [InlineData("1x1x1", 7)]
    [InlineData("2x3x4", 58)]
    [InlineData("1x1x10", 43)]
    [Theory]
    public void PresentRequiredPaperSizeWithSmallestSideIncluded(string input, int expectedArea)
    {
        var present = Present.FromDimension(input);
        present.RequiredWrappingPaperSize().Should().Be(expectedArea);
    }

    [InlineData("1x1x1", 5)]
    [InlineData("2x3x4", 34)]
    [InlineData("1x1x10", 14)]
    [Theory]
    public void PresentRequiredRibbonLength(string input, int expectedLength)
    {
        var present = Present.FromDimension(input);
        present.RequiredAmountOfRibbon().Should().Be(expectedLength);
    }
}

/*

1.  Present can be created from dimensions e.g. 1x2x3, 1x2x1
Present cannot be created from invalid dimensions
9.  Present can give recommended wrapping paper area
2.  Present has correct length from dimension
3.  Present has correct width from dimension
4.  Present has correct height from dimension
8.  Get rid of length, width, height
5.  Present can get smallest side (length and width)
6.  Present can get smallest side (length and height)
7.  Present can get smallest side (width and height)
(I think I like having this) Get rid of smallest side
*/