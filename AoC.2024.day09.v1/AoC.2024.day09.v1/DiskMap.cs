using System.Linq.Expressions;
using System.Text;

namespace AoC._2024.day09.v1;

public class DiskMap
{
    private readonly string _input;

    public DiskMap(string input)
    {
        _input = input;
    }

    public string AsBlocks()
    {
        if (_input == string.Empty) return string.Empty;

        var individualBlocks = new StringBuilder();

        if (_input.Length > 0)
        {
            individualBlocks.Append(GetIndividualBlocksFor(_input[0], 0));
        }

        if (_input.Length > 1)
        {
            individualBlocks.Append(GetIndividualBlocksFor(_input[1], 1));
        }

        if (_input.Length > 2)
        {
            individualBlocks.Append(GetIndividualBlocksFor(_input[2], 2));
        }

        return individualBlocks.ToString();
    }

    private static string GetIndividualBlocksFor(char blockRepresentation, int representationIndex) {
        var block = new Block(blockRepresentation, representationIndex);
        var blockCount = int.Parse(blockRepresentation.ToString());
        return block.Repeat(blockCount);
    }
}