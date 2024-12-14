namespace AoC._2024.day11.v1;

public record Stone(int Value)
{
    private IEnumerable<Stone> OnFirstBlinkStones => OnFirstBlink();
    private string ValueAsString => Value.ToString();

    public IEnumerable<Stone> OnBlink(int numberOfBlinks)
    {
        return OnFirstBlinkStones;
    }

    private IEnumerable<Stone> OnFirstBlink()
    {
        if (Value == 0)
        {
            return [new Stone(1)];
        }

        if (ValueAsString.Length % 2 == 0)
        {
            var halfLength = ValueAsString.Length / 2;
            return [new Stone(int.Parse(ValueAsString[..halfLength])), new Stone(int.Parse(ValueAsString[halfLength..]))];
        }

        return [new Stone(Value * 2024)];
    }
}