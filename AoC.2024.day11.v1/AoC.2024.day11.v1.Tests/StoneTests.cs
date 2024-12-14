using FluentAssertions;

namespace AoC._2024.day11.v1.Tests;

public class StoneTests
{
    [Fact]
    public void StoneWithValueZeroReturnsAStoneOfValueOne()
    {
        var stoneBeforeBlink = new Stone(0);
        var stoneAfterBlink = new Stone(1);

        var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

        stonesAfterBlink.Should().Contain(stoneAfterBlink);
    }

    [Fact]
    public void StoneWithEvenNumberOfDigitsReturnsAStoneOfValueOfTheFirstHalf()
    {
        var stoneBeforeBlink = new Stone(20);
        var stoneAfterBlink = new Stone(2);

        var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

        stonesAfterBlink.Should().Contain(stoneAfterBlink);
    }

    [Fact]
    public void StoneWithEvenNumberOfDigitsReturnsAStoneOfValueOfTheSecondHalf()
    {
        var stoneBeforeBlink = new Stone(20);
        var stoneAfterBlink = new Stone(0);

        var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

        stonesAfterBlink.Should().Contain(stoneAfterBlink);
    }

    [Fact]
    public void StoneWithEvenNumberOfDigitsReturnsAStoneOfSameValueOnBothHalves()
    {
        var stoneBeforeBlink = new Stone(33);
        var stoneAfterBlink = new Stone(3);

        var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

        stonesAfterBlink.Should().ContainInOrder(stoneAfterBlink, stoneAfterBlink);
    }

    [Fact]
    public void StoneWithOddNumberOfDigitsThatIsNotZeroReturnsAStoneOfValueOf2024Bigger()
    {
        var stoneBeforeBlink = new Stone(2);
        var stoneAfterBlink = new Stone(4048);

        var stonesAfterBlink = stoneBeforeBlink.OnBlink(1);

        stonesAfterBlink.Should().Contain(stoneAfterBlink);
    }
}
