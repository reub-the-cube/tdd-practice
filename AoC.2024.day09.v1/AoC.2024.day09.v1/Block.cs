namespace AoC._2024.day09.v1;

public class Block(int index)
{
    private readonly string _blockValue = GetBlockValue(index);
    private readonly bool _isEmpty = GetBlockValue(index) == ".";

    internal int Checksum(int multiplier) {
        if (_isEmpty) return 0;

        return int.Parse(_blockValue) * multiplier;
    }

    internal string Repeat(int times)
    {
        return new string(_blockValue[0], times);
    }

    internal static void ShiftFilesLeftFromFarRight(List<Block> blocks)
    {
        while (AFileWasJustSwapped(blocks)) {
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