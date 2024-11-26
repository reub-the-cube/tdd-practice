namespace AoC._2015.day05.v1
{
    public class SantaStringCheckerPartOne : SantaStringChecker
    {
        public SantaStringCheckerPartOne()
        {
            _rules = [
                new ForbiddenSequenceRule(),
            new RepeatingLetterRule(),
            new ThreeVowelsRule()
            ];
        }
    }
}
