namespace AoC._2015.day05.v1;

public class RepeatingLetterRule : StringRule
{
    public override bool IsNice(string initialValue)
    {
        if (ContainsSubstringThatStartsAndEndsInTheSameLetter(initialValue))
        {
            return true;
        }

        return false;
    }

    private static bool ContainsSubstringThatStartsAndEndsInTheSameLetter(string initialInput)
    {
        var substrings = Splitter.GetAllSubstrings(initialInput, 2);

        return substrings.Any(s => s[0] == s[1]);
    }
}