namespace Wordle;

public class Checker
{
    private string unmatchedCharactersFromTargetWord = string.Empty;
    private char targetCharacter = '_';
    private string? target;
    private char guessCharacter = '_';

    public string HowCloseIsTheWord(string target, string guess)
    {
        unmatchedCharactersFromTargetWord = target;

        return BuildWordMatch(target, guess);
    }

    private string BuildWordMatch(string remainingTarget, string remainingGuess)
    {
        if (remainingTarget.Length == 0) return "";

        targetCharacter = remainingTarget[0];
        guessCharacter = remainingGuess[0];
        return MatchCharacter() + MatchRemainingString(remainingTarget, remainingGuess);
    }

    private string MatchCharacter()
    {
        var guessMatcher = new CharacterMatcher(guessCharacter);
        int characterScore = guessMatcher.GetMatchedScoreAgainst(targetCharacter, unmatchedCharactersFromTargetWord);

        if (characterScore > 0)
        {
            var indexOfGuess = unmatchedCharactersFromTargetWord.IndexOf(guessCharacter);
            unmatchedCharactersFromTargetWord = unmatchedCharactersFromTargetWord.Remove(indexOfGuess, 1);
        }

        return characterScore.ToString();
    }

    private string MatchRemainingString(string remainingTarget, string remainingGuess)  
    {
        return BuildWordMatch(remainingTarget[1..], remainingGuess[1..]);
    }
}
