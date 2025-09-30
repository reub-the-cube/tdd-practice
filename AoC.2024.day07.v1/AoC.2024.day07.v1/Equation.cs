namespace AoC._2024.day07.v1;

public class RootEquation(long testValue, List<int> numbers)
{
    private readonly long testValue = testValue;
    private readonly List<int> numbers = numbers;

    public bool TrySolve(out long result)
    {
        var newEquations = new List<Equation>
        {
            new AdditionEquation(testValue, numbers),
            new MultiplicationEquation(testValue, numbers)
        };

        if (newEquations.Any(e => e.TrySolve()))
        {
            result = testValue;
            return true;
        }

        result = 0;
        return false;
    }

    public static RootEquation Create(string input)
    {
        var splitInput = input.Split(':');
        var simplifiedTestValue = long.Parse(splitInput[0]);
        var numbers = splitInput[1].Trim().Split(' ').Select(int.Parse).ToList();
        return new RootEquation(simplifiedTestValue, numbers);
    }
}

public abstract class Equation(long testValue, List<int> numbers)
{
    protected readonly long testValue = testValue;
    protected readonly List<int> numbers = numbers;

    public bool TrySolve()
    {
        return TestValueCanBeMadeFromNumbers();
    }

    private bool TestValueCanBeMadeFromNumbers()
    {
        if (numbers.Count == 2)
        {
            return testValue == CombineTwoNumbers();
        }

        if (numbers.Count > 2)
        {
            var newEquations = Simplify();
            return newEquations.Any(e => e.TestValueCanBeMadeFromNumbers());
        }

        return false;
    }

    private List<Equation> Simplify()
    {
        long simplifiedTestValue = SimplifyTestValue();

        return [
            new AdditionEquation(simplifiedTestValue, [.. numbers.Take(numbers.Count - 1)]),
            new MultiplicationEquation(simplifiedTestValue, [.. numbers.Take(numbers.Count - 1)])
        ];
    }

    protected abstract long CombineTwoNumbers();

    protected abstract long SimplifyTestValue();
}

public class AdditionEquation(long testValue, List<int> numbers) : Equation(testValue, numbers)
{
    protected override long CombineTwoNumbers()
    {
        return numbers[0] + numbers[1];
    }

    protected override long SimplifyTestValue()
    {
        return testValue - numbers.Last();
    }
}

public class MultiplicationEquation(long testValue, List<int> numbers) : Equation(testValue, numbers)
{
    protected override long CombineTwoNumbers()
    {
        return numbers[0] * numbers[1];
    }

    protected override long SimplifyTestValue()
    {
        if (testValue % numbers.Last() == 0)
        {
            return testValue / numbers.Last();
        }
        return 0;
    }
}