namespace AoC._2024.day09.v1;

public class Block(char blockRepresentation, int index)
{
    private readonly char _blockRepresentation = blockRepresentation;
    private readonly string _blockValue = GetBlockValue(index);

    internal string Repeat(int times) {

            return new string(_blockValue[0], times);
    }
    private static string GetBlockValue(int index)
    {
        if (index % 2 == 0) {
            return (index / 2).ToString();
        }

        return ".";
    }

    public override string ToString()
    {
        return _blockValue;
    }
}