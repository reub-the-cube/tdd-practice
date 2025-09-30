namespace AoC._2024.day07.v1;

public class RootEquation(long testValue, List<int> numbers, bool includeConcatenation = false)
{
    private readonly long testValue = testValue;
    private readonly List<long> numbers = [.. numbers.Select(n => (long)n)];
    private readonly bool includeConcatenation = includeConcatenation;

    public bool TrySolve(out long result)
    {
        var newEquations = new List<Equation>
        {
            new AdditionEquation(numbers, includeConcatenation),
            new MultiplicationEquation(numbers, includeConcatenation)
        };

        if (includeConcatenation) newEquations.Add(new ConcatenationEquation(numbers));

        if (newEquations.Any(e => e.CanSolveFor(testValue)))
        {
            result = testValue;
            return true;
        }

        result = 0;
        return false;
    }

    public static RootEquation Create(string input, bool includeConcatenation = false)
    {
        var splitInput = input.Split(':');
        var simplifiedTestValue = long.Parse(splitInput[0]);
        var numbers = splitInput[1].Trim().Split(' ').Select(int.Parse).ToList();
        return new RootEquation(simplifiedTestValue, numbers, includeConcatenation);
    }
}

public abstract class Equation(List<long> numbers, bool includeConcatenation = false)
{
    protected abstract long CombineTwoNumbers();
    protected readonly long testValue;
    protected readonly List<long> numbers = numbers;
    private readonly bool includeConcatenation = includeConcatenation;

    public bool CanSolveFor(long targetValue)
    {
        return TestValueCanBeMadeFromNumbers(targetValue);
    }

    private bool TestValueCanBeMadeFromNumbers(long targetValue)
    {
        if (numbers.Count == 2)
        {
            return targetValue == CombineTwoNumbers();
        }

        if (numbers.Count > 2)
        {
            var newEquations = Simplify();
            return newEquations.Any(e => e.TestValueCanBeMadeFromNumbers(targetValue));
        }

        return false;
    }

    private List<Equation> Simplify()
    {
        List<long> simplifiedNumbers = SimplifyNumbers();

        var newEquations = new List<Equation>
        {
            new AdditionEquation(simplifiedNumbers, includeConcatenation),
            new MultiplicationEquation(simplifiedNumbers, includeConcatenation)
        };

        if (includeConcatenation)
        {
            newEquations.Add(new ConcatenationEquation(simplifiedNumbers));
        }

        return newEquations;
    }

    private List<long> SimplifyNumbers()
    {
        List<long> simplifiedNumbers = [.. numbers.Skip(1)];
        simplifiedNumbers[0] = CombineTwoNumbers();
        return simplifiedNumbers;
    }
}

public class AdditionEquation(List<long> numbers, bool includeConcatenation = false) : Equation(numbers, includeConcatenation)
{
    protected override long CombineTwoNumbers()
    {
        return numbers[0] + numbers[1];
    }
}

public class MultiplicationEquation(List<long> numbers, bool includeConcatenation = false) : Equation(numbers, includeConcatenation)
{
    protected override long CombineTwoNumbers()
    {
        return numbers[0] * numbers[1];
    }
}

public class ConcatenationEquation(List<long> numbers) : Equation(numbers, true)
{
    protected override long CombineTwoNumbers()
    {
        var concatenated = numbers[0].ToString() + numbers[1].ToString();
        return long.Parse(concatenated);
    }
}