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
        var substrings = Splitter.GetAllSubstrings(initialValue, 2 + _gapBetweenRepeatingLetters);
        var substringStartsAndEndsWithTheSameLetter = substrings.Any(s => s[0] == s[^1]);
        return substringStartsAndEndsWithTheSameLetter;
    }
}