using AwesomeAssertions;

namespace AoC._2024.day07.v1.Tests;

public class SolutionTests
{
    private readonly string[] exampleInputData = File.ReadAllLines("test_input.txt");
    private readonly string[] inputData = File.ReadAllLines("input.txt");

    [Fact]
    public void ExampleInputDataCalculatesTheExampleResultForPartOne()
    {
        var equations = exampleInputData.Select(RootEquation.Create);

        long calibrationTotal = 0;
        foreach (var equation in equations)
        {
            equation.TrySolve(out long equationCalibration);
            calibrationTotal += equationCalibration;
        }

        calibrationTotal.Should().Be(3749);
    }

    [Fact]
    public void InputDataCalculatesTheResultForPartOne()
    {
        var equations = inputData.Select(RootEquation.Create);

        long calibrationTotal = 0;
        foreach (var equation in equations)
        {
            equation.TrySolve(out long equationCalibration);
            calibrationTotal += equationCalibration;
        }

        calibrationTotal.Should().Be(303766880536L);
    }
}