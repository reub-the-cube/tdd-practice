using Aoc._2015.day04.v1;
using FluentAssertions;

namespace AoC._2015.day04.v1.Tests;

public class ExampleTests
{
    private readonly FirstValidInput FirstValidInput;

    public ExampleTests()
    {
        FirstValidInput = new("^00000");
    }

    public class PartOne : ExampleTests
    {
        [Fact]
        public void Example_One_Returns_609043_For_Secret_abcdef()
        {
            var validInput = FirstValidInput.ForSecret("abcdef");

            validInput.Should().Be("abcdef609043");
        }

        [Fact]
        public void Example_Two_Returns_1048970_For_Secret_pqrstuv()
        {
            var validInput = FirstValidInput.ForSecret("pqrstuv");

            validInput.Should().Be("pqrstuv1048970");
        }

        [Fact]
        public void Example_Input_Returns_X_For_Secret_yzbqklnj()
        {
            var validInput = FirstValidInput.ForSecret("yzbqklnj");

            validInput.Should().Be("yzbqklnj282749");
        }
    }

    public class PartTwo
    {
        [Fact]
        public void Example_Two_Returns_X_For_Secret_yzbqklnj()
        {
            var firstValidInput = new FirstValidInput("^000000");

            var validInput = firstValidInput.ForSecret("yzbqklnj");

            validInput.Should().Be("yzbqklnj9962624");
        }
    }
}