namespace AoC._2015.day05.v1;

public abstract class SantaStringChecker : StringRule
{
    protected List<StringRule> _rules;

    public SantaStringChecker()
    {
        _rules = [
            new ForbiddenSequenceRule(),
            new RepeatingLetterRule(),
            new ThreeVowelsRule()
        ];
    }

    public override bool IsNice(string initialValue)
    {
        if (_rules.All(r => r.IsNice(initialValue)))
        {
            return true;
        }

        return false;
    }
}