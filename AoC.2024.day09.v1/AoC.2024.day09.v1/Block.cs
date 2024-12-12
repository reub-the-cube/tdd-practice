namespace AoC._2024.day09.v1;

public class Block(int index)
{
    private readonly string _blockValue = GetBlockValue(index);
    private readonly bool _isEmpty = GetBlockValue(index) == ".";

    internal int Checksum(int multiplier)
    {
        if (_isEmpty) return 0;

        return int.Parse(_blockValue) * multiplier;
    }

    internal string Repeat(int times)
    {
        return new string(_blockValue[0], times);
    }

    internal static void ShiftFilesLeftFromFarRight(List<Block> blocks)
    {
        while (AFileWasJustSwapped(blocks))
        {
        }
    }

    internal static Dictionary<string, int> GetFullFileBlocksAsStringInDecreasingFileIdOrder(List<Block> blocks)
    {
        var fullFileBlocks = blocks
            .Where(b => !b._isEmpty)
            .GroupBy(g => g._blockValue)
            .OrderByDescending(k => int.Parse(k.Key))
            .ToDictionary(g => g.Key, g => g.Count());

        DoSwaps(fullFileBlocks, blocks);
        return fullFileBlocks;
    }

    private static void DoSwaps(Dictionary<string, int> fullFilesInDecreasingIdOrder, List<Block> blocks)
    {
        foreach (var fullFileBlock in fullFilesInDecreasingIdOrder)
        {
            var emptyIndexes = Enumerable.Range(0, blocks.Count).Where(i => blocks[i]._isEmpty && i + fullFileBlock.Value < blocks.Count);
            var emptySpaceIndex = emptyIndexes.Where(i => blocks.GetRange(i, fullFileBlock.Value).All(b => b._isEmpty)).ToList();
            if (emptySpaceIndex.Count == 0) continue;

            var fileIdIndex = blocks.FindIndex(b => b._blockValue == fullFileBlock.Key);
            if (emptySpaceIndex.First() > fileIdIndex) continue;

            blocks.RemoveRange(emptySpaceIndex.First(), fullFileBlock.Value);
            blocks.InsertRange(emptySpaceIndex.First(), Enumerable.Repeat(new Block(int.Parse(fullFileBlock.Key) * 2), fullFileBlock.Value));
            blocks.RemoveRange(fileIdIndex, fullFileBlock.Value);
            blocks.InsertRange(fileIdIndex, Enumerable.Repeat(new Block(-1), fullFileBlock.Value));
        }
    }

    private static bool AFileWasJustSwapped(List<Block> blocks)
    {
        var indexOfFirstEmptyBlock = blocks.FindIndex(b => b._isEmpty);
        if (indexOfFirstEmptyBlock == -1) return false;

        var indexOfLastFileBlock = blocks.FindLastIndex(b => !b._isEmpty);
        if (indexOfFirstEmptyBlock > indexOfLastFileBlock) return false;

        (blocks[indexOfLastFileBlock], blocks[indexOfFirstEmptyBlock]) = (blocks[indexOfFirstEmptyBlock], blocks[indexOfLastFileBlock]);
        return true;
    }

    private static string GetBlockValue(int index)
    {
        if (index % 2 == 0)
        {
            return (index / 2).ToString();
        }

        return ".";
    }

    public override string ToString()
    {
        return _blockValue;
    }
}