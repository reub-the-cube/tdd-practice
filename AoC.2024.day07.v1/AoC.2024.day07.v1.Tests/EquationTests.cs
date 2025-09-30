using AwesomeAssertions;

namespace AoC._2024.day07.v1.Tests;

public class EquationTests
{
    [Fact]
    public void GivenAnEquationIsSolveableWithSingleAdditionThenTheCalibrationResultIsReturned()
    {
        var equation = new AdditionEquation(29, [10, 19]);

        var solved = equation.TrySolve();

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithAdditionThenTheCalibrationResultIsNotReturned()
    {
        var equation = new AdditionEquation(30, [10, 19]);

        var solved = equation.TrySolve();

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithManyAdditionsThenTheCalibrationResultIsReturned()
    {
        var equation = new AdditionEquation(35, [10, 19, 1, 5]);

        var solved = equation.TrySolve();

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithManyAdditionsThenTheCalibrationResultIsNotReturned()
    {
        var equation = new AdditionEquation(30, [10, 19, 1, 5]);

        var solved = equation.TrySolve();

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithSingleMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation(190, [10, 19]);

        var solved = equation.TrySolve();

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsNotSolveableWithSingleMultiplicationThenTheCalibrationResultIsNotReturned()
    {
        var equation = new MultiplicationEquation(180, [10, 19]);

        var solved = equation.TrySolve();

        solved.Should().BeFalse();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithManyMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation(5700, [10, 19, 5, 6]);

        var solved = equation.TrySolve();

        solved.Should().BeTrue();
    }

    [Fact]
    public void GivenAnEquationIsSolveableWithAdditionAndMultiplicationThenTheCalibrationResultIsReturned()
    {
        var equation = new MultiplicationEquation(3267, [81, 40, 27]);

        var solved = equation.TrySolve();

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
}