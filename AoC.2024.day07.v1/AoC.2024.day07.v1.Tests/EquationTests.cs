using AwesomeAssertions;

namespace AoC._2024.day07.v1.Tests;

public class EquationTests
{
    [Fact]
    public void GivenAnEquationIsSolveableWithSingleAdditionThenTheCalibrationResultIsReturned()
    {
        var equation = new AdditionEquation([10, 19]);

        var solved = equation.CanSolveFor(29);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithAdditionThenTheCalibrationResultIsNotReturned()
    {
        var equation = new AdditionEquation([10, 19]);

        var solved = equation.CanSolveFor(30);

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithManyAdditionsThenTheCalibrationResultIsReturned()
    {
        var equation = new AdditionEquation([10, 19, 1, 5]);

        var solved = equation.CanSolveFor(35);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithManyAdditionsThenTheCalibrationResultIsNotReturned()
    {
        var equation = new AdditionEquation([10, 19, 1, 5]);

        var solved = equation.CanSolveFor(30);

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithSingleMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation([10, 19]);

        var solved = equation.CanSolveFor(190);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithSingleMultiplicationThenTheCalibrationResultIsNotReturned()
    {
        var equation = new MultiplicationEquation([10, 19]);

        var solved = equation.CanSolveFor(180);

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithManyMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation([10, 19, 5, 6]);

        var solved = equation.CanSolveFor(5700);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithAdditionAndMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation([81, 40, 27]);

        var solved = equation.CanSolveFor(3267);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenARootEquationIsSolveableWithAdditionAndMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new RootEquation(292, [11, 6, 16, 20]);

        var solved = equation.TrySolve(out long result);

        solved.Should().BeTrue();
        result.Should().Be(292);
    }

    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("161011: 16 10 13", false)]
    public void GivenAnInputLineARootEquationCanBeSolved(string equationInput, bool expectedToBeSolved)
    {
        var solved = RootEquation.Create(equationInput).TrySolve(out _);

        solved.Should().Be(expectedToBeSolved);
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithSingleConcatentationThenTheCalibrationResultIsReturned()
    {
        var equation = new ConcatenationEquation([15, 6]);

        var solved = equation.CanSolveFor(156);

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithSingleConcatentationThenTheCalibrationResultIsNotReturned()
    {
        var equation = new ConcatenationEquation([15, 6]);

        var solved = equation.CanSolveFor(157);

        solved.Should().BeFalse();
    }

    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("161011: 16 10 13", false)]
    [InlineData("156: 15 6", true)]
    [InlineData("192: 17 8 14", true)]
    [InlineData("7290: 6 8 6 15", true)]
    public void GivenAnInputLineARootEquationWithConcatenationCanBeSolved(string equationInput, bool expectedToBeSolved)
    {
        var solved = RootEquation.Create(equationInput, true).TrySolve(out _);

        solved.Should().Be(expectedToBeSolved);
    }
}