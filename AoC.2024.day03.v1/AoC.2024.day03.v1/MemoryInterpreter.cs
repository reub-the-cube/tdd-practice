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