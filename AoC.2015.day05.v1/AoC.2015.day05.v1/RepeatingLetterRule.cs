namespace AoC._2015.day05.v1;

public class RepeatingLetterRule : StringRule
{
    private int _gapBetweenRepeatingLetters = 0;

    public RepeatingLetterRule() { }

    public RepeatingLetterRule(int gapBetweenRepeatingLetters)
    {
        _gapBetweenRepeatingLetters = gapBetweenRepeatingLetters;
    }

    public override bool IsNice(string initialValue)
    {
        if (ContainsSubstringThatStartsAndEndsInTheSameLetter(initialValue))
        {
            return true;
        }

        return false;
    }

    private bool ContainsSubstringThatStartsAndEndsInTheSameLetter(string initialInput)
    {
        var substrings = Splitter.GetAllSubstrings(initialInput, 2 + _gapBetweenRepeatingLetters);

        return substrings.Any(s => s[0] == s[^1]);
    }
}