using System.Runtime.InteropServices;

namespace AoC._2015.day01.v1;

public class FloorCalculator
{
    public static int GetFinalFloorFromInstructions(string instructions)
    {
        var finalFloor = 0;

        while (instructions.Length > 0)
        {
            var delta = GetDelta(instructions[..1][0]);
            finalFloor += delta;
            instructions = instructions[1..];
        }

        return finalFloor;
    }

    public static int IndexWhenFirstEnteringBasement(string instructions)
    {
        return IndexWhenFirstEnteringBasement(instructions, 0, 0);
    }

    private static int IndexWhenFirstEnteringBasement(string instructions, int startingFloor, int instructionsProcessed)
    {
        var currentFloor = GetCurrentFloor(startingFloor, instructions);
        if (currentFloor < 0)
        {
            return instructionsProcessed + 1;
        }

        return IndexWhenFirstEnteringBasement(instructions[2..], currentFloor, instructionsProcessed + 2);
    }

    private static int GetCurrentFloor(int startingFloor, string instructions)
    {
        if (IsAboutToMoveIntoTheBasement(startingFloor, instructions))
        {
            return -1;
        }

        var nextTwoFloorsDelta = GetFinalFloorFromInstructions(instructions[..2]);
        return startingFloor + nextTwoFloorsDelta;
    }

    private static bool IsAboutToMoveIntoTheBasement(int startingFloor, string instructions)
    {
        var floorDelta = GetFinalFloorFromInstructions(instructions[..1]);
        return floorDelta + startingFloor < 0;
    }

    private static int GetDelta(char character)
    {
        if (character == '(')
        {
            return 1;
        }

        if (character == ')')
        {
            return -1;
        }

        return 0;
    }
}
