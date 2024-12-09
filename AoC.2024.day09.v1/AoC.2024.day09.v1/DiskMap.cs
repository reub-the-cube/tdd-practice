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

        var blocks = new List<Block>();

        var indexesRepresentingBlocks = Enumerable.Range(0, _input.Length).ToList();
        indexesRepresentingBlocks.ForEach(i => blocks.AddRange(GetBlocksForRepresentation(_input[i], i)));

        return string.Concat(blocks.Select(b => b.ToString()));
    }

    private static IEnumerable<Block> GetBlocksForRepresentation(char blockRepresentation, int representationIndex)
    {
        var block = new Block(blockRepresentation, representationIndex);
        var blockCount = int.Parse(blockRepresentation.ToString());
        return Enumerable.Repeat(block, blockCount);
    }
}