namespace Wordle;

internal class CharacterMatcher
{
    private readonly char value;

    internal CharacterMatcher(char thisCharacter)
    {
        value = thisCharacter;
    }

    internal int GetMatchedScoreAgainst(char targetChar, string targetString)
    {
        int score = 0;

        if (value == targetChar)
        {
            score += 1;
        }

        if (targetString.Contains(value))
        {
            score += 1;
        }

        return score;
    }

}