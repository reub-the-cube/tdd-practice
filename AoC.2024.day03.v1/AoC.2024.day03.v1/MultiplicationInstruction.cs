namespace AoC._2024.day03.v1
{
    public record MultiplicationInstruction(int NumberOne, int NumberTwo)
    {
        public int Result => NumberOne * NumberTwo;
    }
}
