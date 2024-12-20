namespace AoC._2024.day09.v1;

public class DiskMap
{
    private readonly string _blockRepresentation;
    private readonly List<Block> _indvidialBlocks = [];

    public DiskMap(string input)
    {
        _blockRepresentation = input;
        ExpandBlockRepresentation();
    }

    public string AsBlocks()
    {
        return string.Concat(_indvidialBlocks.Select(b => b.ToString()));
    }

    public long Checksum()
    {
        long checksum = 0;
        for (int i = 0; i < _indvidialBlocks.Count; i++)
        {
            checksum += _indvidialBlocks[i].Checksum(i);
        }

        return checksum;
    }

    public string ShiftFilesLeftFromFarRight()
    {
        Block.ShiftFilesLeftFromFarRight(_indvidialBlocks);
        return string.Concat(_indvidialBlocks.Select(b => b.ToString()));
    }

    public string ShiftFullFilesLeftInDecreasingOrder()
    {
        Block.GetFullFileBlocksAsStringInDecreasingFileIdOrder(_indvidialBlocks);
        var allBlocksAsString = string.Concat(_indvidialBlocks.Select(b => b.ToString()));

        return allBlocksAsString;
    }

    private void ExpandBlockRepresentation()
    {
        _indvidialBlocks.Clear();
        if (_blockRepresentation == string.Empty) return;

        var indexesRepresentingBlocks = Enumerable.Range(0, _blockRepresentation.Length).ToList();
        indexesRepresentingBlocks.ForEach(i => _indvidialBlocks.AddRange(GetBlocksForRepresentation(_blockRepresentation[i], i)));
    }

    private static IEnumerable<Block> GetBlocksForRepresentation(char blockRepresentation, int representationIndex)
    {
        var block = new Block(representationIndex);
        var blockCount = int.Parse(blockRepresentation.ToString());
        return Enumerable.Repeat(block, blockCount);
    }
}