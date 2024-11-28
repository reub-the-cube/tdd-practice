namespace AoC._2015.day05.v1
{
    public class SantaStringCheckerPartTwo : SantaStringChecker
    {
        public SantaStringCheckerPartTwo()
        {
            _rules = [
                new RepeatingStringWithoutOverlapRule(),
                new RepeatingLetterRule(1)
            ];
        }
    }
}
