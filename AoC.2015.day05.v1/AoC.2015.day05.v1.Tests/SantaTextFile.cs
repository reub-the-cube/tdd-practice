using FluentAssertions;

namespace AoC._2015.day05.v1.Tests;

public class SantaTextFileTests
{
    [Fact]
    public void EmptyListHasNoNiceStrings()
    {
        List<string> list = [];

        var numberOfNiceStrings = SantaTextFile.NumberOfNiceStrings(list);

        numberOfNiceStrings.Should().Be(0);
    }

    [Fact]
    public void ExampleListForPartOneHasTwoNiceStrings()
    {
        List<string> list = [
            "ugknbfddgicrmopn",
            "aaa",
            "jchzalrnumimnmhp",
            "jchzalrnumimnmhp",
            "dvszwmarrgswjxmb"
        ];

        var numberOfNiceStrings = SantaTextFile.NumberOfNiceStrings(list);

        numberOfNiceStrings.Should().Be(2);
    }
}