using System.Text;
using System.Text.RegularExpressions;

namespace AoC._2024.day03.v1;

public class MemoryInterpreter
{
    private static readonly Regex _multiplicationInstructionRegex = new(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)");

    public static List<MultiplicationInstruction> GetInstructionsFrom(IEnumerable<string> corruptedMemory)
    {
        return corruptedMemory
            .SelectMany(c => _multiplicationInstructionRegex
                .Matches(c)
                .Select(match => MapToMultiplicationInstruction(match.Value)))
                .ToList();
    }

    public static MultiplicationInstruction MapToMultiplicationInstruction(string fromCorruptedString)
    {
        var match = _multiplicationInstructionRegex.Match(fromCorruptedString);
        return MapToMultiplicationInstruction(match);
    }

    public static string ExcludeDisabledInstructionsFrom(IEnumerable<string> corruptedMemory)
    {
        var fullCorruptedMemory = string.Join(string.Empty, corruptedMemory);
        var memoryBetweenDontInstructions = fullCorruptedMemory.Split(@"don't()");

        var enabledMemoryInputs = new List<string> { memoryBetweenDontInstructions[0] };
        enabledMemoryInputs.AddRange(memoryBetweenDontInstructions
            .Skip(1)
            .Select(GetEnabledMemoryInputWhenStartingOnDisabled));
            
        return string.Join(string.Empty, enabledMemoryInputs);
    }

    private static string GetEnabledMemoryInputWhenStartingOnDisabled(string corruptedMemory)
    {
        var memoryBetweenDoInstructions = corruptedMemory.Split(@"do()");

        if (memoryBetweenDoInstructions.Length > 1)
        {
            return string.Join(string.Empty, memoryBetweenDoInstructions.Skip(1));
        }
        else
        {
            return string.Empty;
        }
    }

    private static MultiplicationInstruction MapToMultiplicationInstruction(Match corruptedStringMatch)
    {
        var multiplicationInstructionFactorOne = int.Parse(corruptedStringMatch.Groups[1].Value);
        var multiplicationInstructionFactorTwo = int.Parse(corruptedStringMatch.Groups[2].Value);
        
        return new MultiplicationInstruction(
            multiplicationInstructionFactorOne,
            multiplicationInstructionFactorTwo
        );
    }
}