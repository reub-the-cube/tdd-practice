using Aoc._2015.day04.v1;
using FluentAssertions;

namespace AoC._2015.day04.v1.Tests;

public class ExampleTests
{
    public class PartOne
    {
        [Fact]
        public void Example_One_Returns_609043_For_Secret_abcdef()
        {
            var firstValidInput = new FirstValidInput("^00000");

            var validInput = firstValidInput.ForSecret("abcdef");

            validInput.Should().Be("abcdef609043");
        }

        [Fact]
        public void Example_One_Returns_1048970_For_Secret_pqrstuv()
        {
            var firstValidInput = new FirstValidInput("^00000");

            var validInput = firstValidInput.ForSecret("pqrstuv");

            validInput.Should().Be("pqrstuv1048970");
        }

        [Fact]
        public void Example_One_Returns_X_For_Secret_yzbqklnj()
        {
            var firstValidInput = new FirstValidInput("^00000");

            var validInput = firstValidInput.ForSecret("yzbqklnj");

            validInput.Should().Be("yzbqklnj282749");
        }

        [Fact]
        public void Example_Two_Returns_X_For_Secret_yzbqklnj()
        {
            var firstValidInput = new FirstValidInput("^000000");

            var validInput = firstValidInput.ForSecret("yzbqklnj");

            validInput.Should().Be("yzbqklnj9962624");
        }
    }
}